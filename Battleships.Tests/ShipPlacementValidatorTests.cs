using Battleships.Services;
using Battleships.Tests.ShipPlacementValidatorTestCases;
using NUnit.Framework;

namespace Battleships.Tests
{
    public class ShipPlacementValidatorTests
    {
        [TestCaseSource(typeof(TestCasesSource), nameof(TestCasesSource.IntersectSource))]
        public void ShipsIntersect(IReadOnlyCollection<Vector2DInt> shipA, IReadOnlyCollection<Vector2DInt> shipB)
        {
            var sut = new ShipPlacementValidator();
            Assert.That(sut.Intersect(shipA, shipB));
            Assert.That(sut.Intersect(shipB, shipA));
        }

        [TestCaseSource(typeof(TestCasesSource), nameof(TestCasesSource.DontIntersectSource))]
        public void ShipsDontIntersect(IReadOnlyCollection<Vector2DInt> shipA, IReadOnlyCollection<Vector2DInt> shipB)
        {
            var sut = new ShipPlacementValidator();
            Assert.That(sut.Intersect(shipA, shipB), Is.False);
            Assert.That(sut.Intersect(shipB, shipA), Is.False);
        }

        [TestCaseSource(typeof(TestCasesSource), nameof(TestCasesSource.OutOfBoundsSource))]
        public void ShipOutOfBounds(Vector2DInt boundsSize, IEnumerable<Vector2DInt> shipCoords)
        {
            var sut = new ShipPlacementValidator();
            Assert.That(sut.OutOfBounds(boundsSize, shipCoords));
        }

        [TestCaseSource(typeof(TestCasesSource), nameof(TestCasesSource.NotOutOfBoundsSource))]
        public void ShipNotOutOfBounds(Vector2DInt boundsSize, IEnumerable<Vector2DInt> shipCoords)
        {
            var sut = new ShipPlacementValidator();
            Assert.That(sut.OutOfBounds(boundsSize, shipCoords), Is.False);
        }
    }
}