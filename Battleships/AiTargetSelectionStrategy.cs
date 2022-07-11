using Battleships.Core;

namespace Battleships;

public class AiTargetSelectionStrategy : ITargetSelectionStrategy
{
    private readonly ITargetSelectionStrategy seekingStrategy;
    private readonly ITargetSelectionStrategy precisionStrategy;

    public AiTargetSelectionStrategy(
        ITargetSelectionStrategy seekingStrategy,
        ITargetSelectionStrategy precisionStrategy)
    {
        this.seekingStrategy = seekingStrategy;
        this.precisionStrategy = precisionStrategy;
    }

    /// <inheritdoc />
    public Vector2DInt SelectTarget(TargetSelectionStrategyArguments args)
    {
        return args.Hits is not null && args.Hits is not { Count: 0 }
            ? precisionStrategy.SelectTarget(args)
            : seekingStrategy.SelectTarget(args);
    }
}