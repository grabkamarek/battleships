using System.Collections;
using Battleships.Core;

namespace Battleships.Tests.ShipPlacementValidatorTestCases;

public class ShipsIntersectSource : IEnumerable
{
    /// <inheritdoc />
    public IEnumerator GetEnumerator()
    {
        yield return new object[]
        {
            new List<Vector2DInt>
            {
                new(5, 5)
            },
            new List<Vector2DInt>
            {
                new(5, 5)
            }
        };

        yield return new object[]
        {
            new List<Vector2DInt>
            {
                new(5, 5),
                new(5, 6),
                new(5, 7),
                new(5, 8),
                new(5, 9)
            },
            new List<Vector2DInt>
            {
                new(5, 5),
                new(5, 6),
                new(5, 7),
                new(5, 8),
                new(5, 9)
            }
        };

        yield return new object[]
        {
            new List<Vector2DInt>
            {
                new(5, 5),
                new(5, 6),
                new(5, 7),
                new(5, 8),
                new(5, 9)
            },
            new List<Vector2DInt>
            {
                new(3, 7),
                new(4, 7),
                new(5, 7),
                new(6, 7),
                new(7, 7)
            }
        };

        yield return new object[]
        {
            new List<Vector2DInt>
            {
                new(5, 5),
                new(5, 6),
                new(5, 7),
                new(5, 8),
                new(5, 9)
            },
            new List<Vector2DInt>
            {
                new(4, 7),
                new(5, 7),
                new(6, 7),
            }
        };

        yield return new object[]
        {
            new List<Vector2DInt>
            {
                new(5, 5),
                new(5, 6),
                new(5, 7),
                new(5, 8),
                new(5, 9)
            },
            new List<Vector2DInt>
            {
                new(5, 5),
                new(6, 5),
                new(7, 5),
            }
        };
    }
}