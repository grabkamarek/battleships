using Battleships.Core;
using Battleships.GameObjects.Ships;

namespace Battleships;

public class AiPlayer : IPlayer
{
    private readonly Vector2DInt boardSize;
    private readonly ITargetSelectionStrategy targetSelectionStrategy;
    private readonly List<Vector2DInt> fogOfWar = new();
    private readonly List<Vector2DInt> misses = new();
    private readonly List<Vector2DInt> hits = new();
    private readonly List<Vector2DInt> destroyed = new();

    public AiPlayer(Vector2DInt boardSize, ITargetSelectionStrategy targetSelectionStrategy, IReadOnlyCollection<Ship> ships)
    {
        this.boardSize = boardSize;
        this.targetSelectionStrategy = targetSelectionStrategy;
        Ships = ships;
        for (var x = 0; x < boardSize.X; x++)
        {
            for (var y = 0; y < boardSize.Y; y++)
            {
                fogOfWar.Add(new Vector2DInt(x, y));
            }
        }
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
            BoardSize = boardSize,
            FogOfWar = fogOfWar,
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
                fogOfWar.Remove(position);
                misses.Add(position);
                break;
            case ShotResult.Hit:
                fogOfWar.Remove(position);
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

        destroyed.AddRange(result.DestroyedShipCoords);
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