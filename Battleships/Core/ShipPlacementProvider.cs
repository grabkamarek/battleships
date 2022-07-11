namespace Battleships.Core
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
        public Vector2DInt FindValidOrigin(
            Vector2DInt boundsSize,
            Vector2DInt shipSize,
            IReadOnlyCollection<IReadOnlyCollection<Vector2DInt>> otherShips)
        {
            var taken = new List<Vector2DInt>(otherShips.SelectMany(x => x));
            while (true)
            {
                var x = random.Next(boundsSize.X);
                var y = random.Next(boundsSize.Y);
                var possibleOrigin = new Vector2DInt(x, y);

                var coords = CalculateShipCoords(possibleOrigin, shipSize);
                if (validator.Intersect(coords, taken))
                {
                    continue;
                }

                if (validator.OutOfBounds(boundsSize, coords))
                {
                    continue;
                }

                return possibleOrigin;
            }
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
}