namespace Battleships.Core
{
    public interface IShipPlacementProvider
    {
        Vector2DInt FindValidOrigin(
            Vector2DInt boundsSize,
            Vector2DInt shipSize,
            IReadOnlyCollection<IReadOnlyCollection<Vector2DInt>> otherShips);
    }
}