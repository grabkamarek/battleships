using Battleships.Services;

namespace Battleships.Battle
{
    public record ShotEvaluationResult(ShotResult Result, IReadOnlyCollection<Vector2DInt>? DestroyedShipCoords);
}