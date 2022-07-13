using Battleships.Battle;
using Battleships.Battle.Strategies;
using Battleships.GameObjects;
using Battleships.GameObjects.Ships;
using Battleships.Services;

namespace Battleships
{
    public class Player : IPlayer
    {
        private readonly ITargetSelectionStrategy targetSelectionStrategy;
        private readonly FogOfWar fogOfWar;
        private readonly List<Vector2DInt> hits = new();

        public Player(ITargetSelectionStrategy targetSelectionStrategy, IReadOnlyCollection<Ship> ships,
            FogOfWar fogOfWar)
        {
            Ships = ships;
            this.targetSelectionStrategy = targetSelectionStrategy;
            this.fogOfWar = fogOfWar;
        }

        /// <inheritdoc />
        public bool AllShipsDestroyed => Ships.All(x => x.Destroyed);

        /// <inheritdoc />
        public IReadOnlyCollection<Ship> Ships
        {
            get;
        }

        /// <inheritdoc />
        public Vector2DInt SelectTarget()
        {
            var selectionArgs = new TargetSelectionStrategyArguments
            {
                BoardSize = fogOfWar.Size,
                FogOfWar = fogOfWar.Coordinates,
                Hits = hits
            };
            return targetSelectionStrategy.SelectTarget(selectionArgs);
        }

        /// <inheritdoc />
        public void ShotResultNotification(Vector2DInt position, ShotEvaluationResult result)
        {
            switch (result.Result)
            {
                case ShotResult.Unknown:
                    break;
                case ShotResult.Miss:
                    fogOfWar.RemoveCoordinate(position);
                    break;
                case ShotResult.Hit:
                    fogOfWar.RemoveCoordinate(position);
                    hits.Add(position);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(result), result, null);
            }

            if (result.DestroyedShipCoords is not (not null or { Count: 0 }))
            {
                return;
            }

            foreach (var shipCoord in result.DestroyedShipCoords)
            {
                hits.Remove(shipCoord);
            }
        }

        /// <inheritdoc />
        public ShotEvaluationResult EvaluateShot(Vector2DInt target)
        {
            var ship = Ships.Where(x => !x.Destroyed).SingleOrDefault(x =>
                x.ShipParts.Any(p => p.position == target && p.status == ShipPartStatus.Ok));
            if (ship is null)
            {
                return new ShotEvaluationResult(ShotResult.Miss, null);
            }

            var shotResult = ship.EvaluateShot(target);
            return new ShotEvaluationResult(shotResult,
                ship.Destroyed ? ship.ShipParts.Select(x => x.position).ToList() : null);
        }
    }
}
