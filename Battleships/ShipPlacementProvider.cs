namespace Battleships;

public class ShipPlacementProvider : IShipPlacementProvider
{
    private readonly IRandom random;

    public ShipPlacementProvider(IRandom random)
    {
        this.random = random ?? throw new ArgumentNullException(nameof(random));
    }

    private static bool Intersect(IReadOnlyCollection<Vector2DInt> shipA, IReadOnlyCollection<Vector2DInt> shipB)
    {
        return shipA.Any(shipB.Contains);
    }

    /// <inheritdoc />
    public Vector2DInt FindValidOrigin(
        Vector2DInt boundsOrigin,
        Vector2DInt boundsSize,
        Vector2DInt shipSize,
        IReadOnlyCollection<IReadOnlyCollection<Vector2DInt>> otherShips)
    {
        var taken = new List<Vector2DInt>(otherShips.SelectMany(x => x));
        while (true)
        {
            var x = random.Next(boundsOrigin.X, boundsOrigin.X + boundsSize.X);
            var y = random.Next(boundsOrigin.Y, boundsOrigin.Y + boundsSize.Y);
            var possibleOrigin = new Vector2DInt(x, y);

            var coords = CalculateShipCoords(possibleOrigin, shipSize);
            if (Intersect(coords, taken))
            {
                continue;
            }

            if (OutOfBounds(boundsOrigin, boundsSize, coords))
            {
                continue;
            }

            return possibleOrigin;
        }
    }

    private static bool OutOfBounds(
        Vector2DInt boundsOrigin,
        Vector2DInt boundsSize,
        IEnumerable<Vector2DInt> shipCoords)
    {
        foreach (var pos in shipCoords)
        {
            if (pos.X < boundsOrigin.X || pos.Y < boundsOrigin.Y)
            {
                return true;
            }

            if (pos.X > boundsOrigin.X + boundsSize.X || pos.Y > boundsOrigin.Y + boundsSize.Y)
            {
                return true;
            }
        }

        return false;
    }

    private static IReadOnlyCollection<Vector2DInt> CalculateShipCoords(Vector2DInt origin, Vector2DInt size)
    {
        var shipParts = new List<Vector2DInt>
        {
            origin
        };
        var isHorizontal = size.X > 0;
        for (var i = 1; i < (isHorizontal ? size.X : size.Y); i++)
        {
            shipParts.Add(shipParts[i - 1] + (isHorizontal ? Vector2DInt.Right : Vector2DInt.Down));
        }

        return shipParts;
    }
}