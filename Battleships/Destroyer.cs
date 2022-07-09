namespace Battleships
{
    public class Destroyer : Ship
    {
        /// <inheritdoc />
        public Destroyer(Guid id, Board board, Vector2DInt origin, Vector2DInt size)
            : base(id, board, origin, ShipType.Destroyer, size, 'D')
        {
        }
    }
}