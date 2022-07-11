using Battleships.Core;

namespace Battleships;

public interface ITargetSelectionStrategy
{
    Vector2DInt SelectTarget(TargetSelectionStrategyArguments args);
}