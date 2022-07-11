namespace Battleships.Core;

public class ShipPlacementValidator : IShipPlacementValidator
{
    /// <inheritdoc />
    public bool Intersect(IReadOnlyCollection<Vector2DInt> shipA, IReadOnlyCollection<Vector2DInt> shipB)
    {
        return shipA.Any(shipB.Contains);
    }

    /// <inheritdoc />
    public bool OutOfBounds(Vector2DInt boundsSize, IEnumerable<Vector2DInt> shipCoords)
    {
        foreach (var pos in shipCoords)
        {
            if (pos.X < 0 || pos.Y < 0)
            {
                return true;
            }

            if (pos.X >= boundsSize.X || pos.Y >= boundsSize.Y)
            {
                return true;
            }
        }

        return false;
    }
}