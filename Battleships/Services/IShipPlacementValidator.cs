namespace Battleships.Services
{
    public interface IShipPlacementValidator
    {
        bool Intersect(IReadOnlyCollection<Vector2DInt> shipA, IReadOnlyCollection<Vector2DInt> shipB);
        bool OutOfBounds(Vector2DInt boundsSize, IEnumerable<Vector2DInt> shipCoords);
    }
}