using System.Collections;
using Battleships.Services;

namespace Battleships.Tests.Vector2DIntTestCases;

public class VectorsAreEqualSource : IEnumerable
{
    /// <inheritdoc />
    public IEnumerator GetEnumerator()
    {
        yield return new object[]
        {
            Vector2DInt.Zero, new Vector2DInt
            {
                X = 0, Y = 0
            }
        };

        yield return new object[]
        {
            Vector2DInt.Up, new Vector2DInt(0, -1)
        };

        yield return new object[]
        {
            Vector2DInt.Down, new Vector2DInt(0, 1)
        };

        yield return new object[]
        {
            Vector2DInt.Left, new Vector2DInt(-1, 0)
        };

        yield return new object[]
        {
            Vector2DInt.Right, new Vector2DInt(1, 0)
        };

        yield return new object[]
        {
            new Vector2DInt(5, 5), new Vector2DInt(5, 5)
        };
    }
}