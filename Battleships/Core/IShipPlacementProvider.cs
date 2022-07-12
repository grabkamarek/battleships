namespace Battleships.Core
{
    public interface IShipPlacementProvider
    {
        IReadOnlyCollection<Vector2DInt> FindValidShipCoords(
            Vector2DInt boundsSize,
            bool isHorizontal,
            int shipLength,
            IReadOnlyCollection<Vector2DInt> otherShipsCoords);
    }
}