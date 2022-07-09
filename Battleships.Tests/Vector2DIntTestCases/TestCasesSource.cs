using System.Collections;
using Battleships.Core;

namespace Battleships.Tests.Vector2DIntTestCases
{
    public class TestCasesSource
    {
        public static readonly VectorsAreEqualSource AreEqualSource = new();
        public static readonly VectorsAreNotEqualSource AreNotEqualSource = new();
        public static readonly VectorsAddSource AddSource = new();
        public static readonly VectorsSubtractSource SubtractSource = new();
    }

    public class VectorsAddSource : IEnumerable
    {
        /// <inheritdoc />
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                Vector2DInt.Zero, Vector2DInt.Zero, Vector2DInt.Zero,
            };

            yield return new object[]
            {
                Vector2DInt.Up, Vector2DInt.Down, Vector2DInt.Zero,
            };

            yield return new object[]
            {
                Vector2DInt.Left, Vector2DInt.Right, Vector2DInt.Zero,
            };

            yield return new object[]
            {
                Vector2DInt.Up, Vector2DInt.Up, new Vector2DInt(0, -2),
            };

            yield return new object[]
            {
                new Vector2DInt(3, 5), new Vector2DInt(5, 3), new Vector2DInt(8, 8),
            };
        }
    }

    public class VectorsSubtractSource : IEnumerable
    {
        /// <inheritdoc />
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                Vector2DInt.Zero, Vector2DInt.Zero, Vector2DInt.Zero,
            };

            yield return new object[]
            {
                Vector2DInt.Up, Vector2DInt.Down, new Vector2DInt(0, -2),
            };

            yield return new object[]
            {
                Vector2DInt.Left, Vector2DInt.Right, new Vector2DInt(-2, 0),
            };

            yield return new object[]
            {
                Vector2DInt.Up, Vector2DInt.Up, Vector2DInt.Zero,
            };

            yield return new object[]
            {
                new Vector2DInt(3, 5), new Vector2DInt(5, 3), new Vector2DInt(-2, 2),
            };
        }
    }
}
