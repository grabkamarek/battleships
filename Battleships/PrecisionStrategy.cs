using Battleships.Core;

namespace Battleships;

public class PrecisionStrategy : ITargetSelectionStrategy
{
    private readonly IRandom random;

    public PrecisionStrategy(IRandom random)
    {
        this.random = random;
    }

    /// <inheritdoc />
    public Vector2DInt SelectTarget(TargetSelectionStrategyArguments args)
    {
        if (args.Hits is null or { Count: 0 })
        {
            throw new Exception("Precise target selection needs at least one already hit target coordinate.");
        }

        var possibleTargets = BuildPossibleTargetLists(args.Hits);
        return possibleTargets.ElementAt(random.Next(0, possibleTargets.Count));
    }

    private static IReadOnlyCollection<Vector2DInt> BuildPossibleTargetLists(IReadOnlyCollection<Vector2DInt> successfulHits)
    {
        var result = new List<Vector2DInt>(successfulHits);
        foreach (var successfulHit in successfulHits)
        {
            result.Add(successfulHit + Vector2DInt.Up);
            result.Add(successfulHit + Vector2DInt.Down);
            result.Add(successfulHit + Vector2DInt.Left);
            result.Add(successfulHit + Vector2DInt.Right);
        }

        return result.Distinct().ToList().AsReadOnly();
    }
}