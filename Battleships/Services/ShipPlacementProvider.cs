namespace Battleships.Services
{
    public class ShipPlacementProvider : IShipPlacementProvider
    {
        private readonly IRandom random;
        private readonly IShipPlacementValidator validator;

        public ShipPlacementProvider(IRandom random, IShipPlacementValidator validator)
        {
            this.random = random ?? throw new ArgumentNullException(nameof(random));
            this.validator = validator;
        }

        /// <inheritdoc />
        public IReadOnlyCollection<Vector2DInt> FindValidShipCoords(Vector2DInt boundsSize, bool isHorizontal, int shipLength,
            IReadOnlyCollection<Vector2DInt> otherShipsCoords)
        {
            while (true)
            {
                var x = random.Next(boundsSize.X);
                var y = random.Next(boundsSize.Y);
                var possibleOrigin = new Vector2DInt(x, y);

                var coords = CalculateShipCoords(possibleOrigin, shipLength, isHorizontal);
                if (validator.Intersect(coords, otherShipsCoords))
                {
                    continue;
                }

                if (validator.OutOfBounds(boundsSize, coords))
                {
                    continue;
                }

                return coords;
            }
        }

        private static IReadOnlyCollection<Vector2DInt> CalculateShipCoords(Vector2DInt origin, int shipLength, bool isHorizontal)
        {
            var shipCoords = new List<Vector2DInt>
            {
                origin
            };
            for (var i = 1; i < shipLength; i++)
            {
                shipCoords.Add(shipCoords[i - 1] + (isHorizontal ? Vector2DInt.Right : Vector2DInt.Down));
            }

            return shipCoords;
        }
    }
}