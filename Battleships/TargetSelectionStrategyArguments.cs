using Battleships.Core;

namespace Battleships;

public class TargetSelectionStrategyArguments
{
    public Vector2DInt BoardSize { get; set; }
    public IReadOnlyCollection<Vector2DInt>? FogOfWar { get; set; }
    public IReadOnlyCollection<Vector2DInt>? Hits { get; set; }
}