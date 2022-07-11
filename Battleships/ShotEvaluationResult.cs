using Battleships.Core;

namespace Battleships;

public record ShotEvaluationResult(ShotResult Result, IReadOnlyCollection<Vector2DInt>? DestroyedShipCoords);