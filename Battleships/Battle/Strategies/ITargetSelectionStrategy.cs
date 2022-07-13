using Battleships.Services;

namespace Battleships.Battle.Strategies
{
    public interface ITargetSelectionStrategy
    {
        Vector2DInt SelectTarget(TargetSelectionStrategyArguments args);
    }
}