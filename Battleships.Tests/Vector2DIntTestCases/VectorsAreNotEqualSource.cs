using System.Collections;
using Battleships.Core;

namespace Battleships.Tests.Vector2DIntTestCases;

public class VectorsAreNotEqualSource : IEnumerable
{
    /// <inheritdoc />
    public IEnumerator GetEnumerator()
    {
        yield return new object[]
        {
            Vector2DInt.Zero, new Vector2DInt(1, 1)
        };

        yield return new object[]
        {
            Vector2DInt.Up, Vector2DInt.Down
        };

        yield return new object[]
        {
            Vector2DInt.Down, Vector2DInt.Up
        };

        yield return new object[]
        {
            Vector2DInt.Left, Vector2DInt.Right
        };

        yield return new object[]
        {
            Vector2DInt.Right, Vector2DInt.Left
        };

        yield return new object[]
        {
            new Vector2DInt(5, 5), new Vector2DInt(5, 6)
        };
    }
}