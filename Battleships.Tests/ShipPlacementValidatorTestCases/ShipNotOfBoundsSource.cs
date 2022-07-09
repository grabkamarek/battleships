using System.Collections;
using Battleships.Core;

namespace Battleships.Tests.ShipPlacementValidatorTestCases;

public class ShipNotOfBoundsSource : IEnumerable
{
    /// <inheritdoc />
    public IEnumerator GetEnumerator()
    {
        yield return new object[]
        {
            new Vector2DInt(10, 10), new List<Vector2DInt>
            {
                new Vector2DInt(5, 5),
                new Vector2DInt(5, 6),
                new Vector2DInt(5, 7),
                new Vector2DInt(5, 8),
                new Vector2DInt(5, 9),
            }
        };

        yield return new object[]
        {
            new Vector2DInt(10, 10), new List<Vector2DInt>
            {
                new Vector2DInt(5, 5),
                new Vector2DInt(6, 5),
                new Vector2DInt(7, 5),
                new Vector2DInt(8, 5),
                new Vector2DInt(9, 5),
            }
        };
    }
}