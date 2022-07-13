using Battleships.Services;

namespace Battleships.GameObjects.Ships
{
    public record ShipPart(Vector2DInt position, ShipPartStatus status);
}