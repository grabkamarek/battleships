using Battleships.Core;
using Battleships.GameObjects.Ships;

namespace Battleships;

public interface IPlayer
{
    bool AllShipsDestroyed { get; }

    IReadOnlyCollection<Ship> Ships { get; }

    Vector2DInt SelectTarget();
    void ShotResultNotification(Vector2DInt position, ShotEvaluationResult result);
    ShotEvaluationResult EvaluateShot(Vector2DInt target);
}