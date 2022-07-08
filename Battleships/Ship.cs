namespace Battleships;

public abstract class Ship : GameObject
{
    public ShipType ShipType
    {
        get;
    }

    public ShipOrientation Orientation
    {
        get;
    }

    protected readonly ShipPart[] shipParts;

    public IReadOnlyCollection<ShipPart> ShipParts => shipParts;

    /// <inheritdoc />
    protected Ship(Guid id, Vector2DInt origin, ShipType shipType, Vector2DInt size)
        : base(id, origin, size)
    {
        ShipType = shipType;
        Orientation = size.X > 0 ? ShipOrientation.Horizontal : ShipOrientation.Vertical;
        shipParts = new ShipPart[Orientation == ShipOrientation.Horizontal ? Size.X : Size.Y];
        for (var i = 0; i < shipParts.Length; i++)
        {
            shipParts[i] =
                new ShipPart(
                    Origin + (Orientation == ShipOrientation.Horizontal ? Vector2DInt.Right : Vector2DInt.Down) * i,
                    ShipPartStatus.Ok);
        }
    }
}