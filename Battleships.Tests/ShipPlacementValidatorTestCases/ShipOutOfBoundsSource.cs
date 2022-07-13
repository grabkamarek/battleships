using System.Collections;
using Battleships.Services;

namespace Battleships.Tests.ShipPlacementValidatorTestCases;

public class ShipOutOfBoundsSource : IEnumerable
{
    /// <inheritdoc />
    public IEnumerator GetEnumerator()
    {
        yield return new object[]
        {
            new Vector2DInt(10, 10), new List<Vector2DInt>
            {
                new(-1, 0), new(0, 0), new(1, 0)
            }
        };

        yield return new object[]
        {
            new Vector2DInt(10, 10), new List<Vector2DInt>
            {
                new(7, 5), new(8, 5), new(9, 5), new(10, 5), new(11, 5)
            }
        };

        yield return new object[]
        {
            new Vector2DInt(10, 10), new List<Vector2DInt>
            {
                new(0, -1), new(0, 0), new(0, 1)
            }
        };

        yield return new object[]
        {
            new Vector2DInt(10, 10), new List<Vector2DInt>
            {
                new(7, 7), new(7, 8), new(7, 9), new(7, 10), new(7, 11)
            }
        };
    }
}