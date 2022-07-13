using Battleships.Battle;
using Battleships.Services;

namespace Battleships.GameObjects.Ships
{
    public class Ship : GameObject
    {
        public Board Board
        {
            get;
        }

        public ShipType ShipType
        {
            get;
        }

        public char Marker
        {
            get;
        }

        public bool Destroyed => shipParts.All(x => x.status == ShipPartStatus.Hit);

        protected readonly ShipPart[] shipParts;

        public IReadOnlyCollection<ShipPart> ShipParts => shipParts;

        /// <inheritdoc />
        public Ship(Guid id, Board board, ShipType shipType, IReadOnlyCollection<Vector2DInt> shipCoords, bool isHorizontal, char marker)
            : base(id, shipCoords.ElementAt(0), isHorizontal ? new Vector2DInt(shipCoords.Count, 0) : new Vector2DInt(0, shipCoords.Count))
        {
            Board = board;
            ShipType = shipType;
            Marker = marker;
            shipParts = shipCoords.Select(x => new ShipPart(x, ShipPartStatus.Ok)).ToArray();
        }

        public ShotResult EvaluateShot(Vector2DInt target)
        {
            for (var i = 0; i < shipParts.Length; i++)
            {
                if (shipParts[i].position != target)
                {
                    continue;
                }

                if (shipParts[i].status == ShipPartStatus.Hit)
                {
                    return ShotResult.Miss;
                }

                shipParts[i] = new ShipPart(target, ShipPartStatus.Hit);
                NeedsRender = true;
                return ShotResult.Hit;
            }

            return ShotResult.Miss;
        }
    }
}