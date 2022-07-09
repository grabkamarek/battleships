namespace Battleships.Tests.ShipPlacementValidatorTestCases;

public class TestCasesSource
{
    public static readonly ShipsIntersectSource IntersectSource = new();
    public static readonly ShipsDontIntersectSource DontIntersectSource = new();
    public static readonly ShipOutOfBoundsSource OutOfBoundsSource = new();
    public static readonly ShipNotOfBoundsSource NotOutOfBoundsSource = new();
}