namespace Battleships
{
    public class Battleship : Ship
    {
        /// <inheritdoc />
        public Battleship(Guid id, Board board, Vector2DInt origin, Vector2DInt size)
            : base(id, board, origin, ShipType.Battleship, size, 'B')
        {
        }
    }
}