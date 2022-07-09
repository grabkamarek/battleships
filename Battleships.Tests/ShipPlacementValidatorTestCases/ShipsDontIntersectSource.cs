using System.Collections;
using Battleships.Core;

namespace Battleships.Tests.ShipPlacementValidatorTestCases;

public class ShipsDontIntersectSource : IEnumerable
{
    /// <inheritdoc />
    public IEnumerator GetEnumerator()
    {
        yield return new object[]
        {
            new List<Vector2DInt>
            {
                new Vector2DInt(5, 5)
            },
            new List<Vector2DInt>
            {
                new Vector2DInt(8, 8)
            }
        };

        yield return new object[]
        {
            new List<Vector2DInt>
            {
                new Vector2DInt(5, 5),
                new Vector2DInt(5, 6),
                new Vector2DInt(5, 7),
                new Vector2DInt(5, 8),
                new Vector2DInt(5, 9)
            },
            new List<Vector2DInt>
            {
                new Vector2DInt(1, 5),
                new Vector2DInt(1, 6),
                new Vector2DInt(1, 7),
                new Vector2DInt(1, 8),
                new Vector2DInt(1, 9)
            }
        };

        yield return new object[]
        {
            new List<Vector2DInt>
            {
                new Vector2DInt(5, 5),
                new Vector2DInt(5, 6),
                new Vector2DInt(5, 7),
                new Vector2DInt(5, 8),
                new Vector2DInt(5, 9)
            },
            new List<Vector2DInt>
            {
                new Vector2DInt(3, 1),
                new Vector2DInt(4, 1),
                new Vector2DInt(5, 1),
                new Vector2DInt(6, 1),
                new Vector2DInt(7, 1)
            }
        };
    }
}