using Battleships.Core;
using Battleships.Tests.Vector2DIntTestCases;
using NUnit.Framework;

namespace Battleships.Tests;

public class Vector2DIntTests
{
    [TestCaseSource(typeof(TestCasesSource), nameof(TestCasesSource.AreEqualSource))]
    public void Equal(Vector2DInt v1, Vector2DInt v2)
    {
        Assert.Multiple(() =>
        {
            Assert.That(v2, Is.EqualTo(v1));
            Assert.That(v1, Is.EqualTo(v2));
        });
        Assert.Multiple(() =>
        {
            Assert.That(v1 == v2, Is.True);
            Assert.That(v2 == v1, Is.True);
        });
        Assert.Multiple(() =>
        {
            Assert.That(v1 != v2, Is.False);
            Assert.That(v2 != v1, Is.False);
        });
    }

    [TestCaseSource(typeof(TestCasesSource), nameof(TestCasesSource.AreNotEqualSource))]
    public void NotEqual(Vector2DInt v1, Vector2DInt v2)
    {
        Assert.Multiple(() =>
        {
            Assert.That(v2, Is.Not.EqualTo(v1));
            Assert.That(v1, Is.Not.EqualTo(v2));
        });
        Assert.That(v1 == v2, Is.False);
        Assert.That(v2 == v1, Is.False);
        Assert.That(v1 != v2);
        Assert.That(v2 != v1);
    }

    [TestCaseSource(typeof(TestCasesSource), nameof(TestCasesSource.AddSource))]
    public void Add(Vector2DInt v1, Vector2DInt v2, Vector2DInt expected)
    {
        Assert.Multiple(() =>
        {
            Assert.That(v1 + v2, Is.EqualTo(expected));
            Assert.That(v2 + v1, Is.EqualTo(expected));
        });
    }

    [TestCaseSource(typeof(TestCasesSource), nameof(TestCasesSource.SubtractSource))]
    public void Subtract(Vector2DInt v1, Vector2DInt v2, Vector2DInt expected)
    {
        Assert.That(v1 - v2, Is.EqualTo(expected));
    }
}