namespace Battleships;

public class Destroyer : Ship
{
    /// <inheritdoc />
    public Destroyer(Guid id, Vector2DInt origin, Vector2DInt size)
        : base(id, origin, ShipType.Destroyer, size)
    {
    }
}