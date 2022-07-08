namespace Battleships;

public class Battleship : Ship
{
    /// <inheritdoc />
    public Battleship(Guid id, Vector2DInt origin, Vector2DInt size)
        : base(id, origin, ShipType.Battleship, size)
    {
    }
}