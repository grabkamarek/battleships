namespace Battleships
{
    public abstract class Ship : GameObject
    {
        public Board Board
        {
            get;
        }

        public ShipType ShipType
        {
            get;
        }

        public char Marker
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
        protected Ship(Guid id, Board board, Vector2DInt origin, ShipType shipType, Vector2DInt size, char marker)
            : base(id, origin, size)
        {
            Board = board;
            ShipType = shipType;
            Marker = marker;
            Orientation = size.X > 0 ? ShipOrientation.Horizontal : ShipOrientation.Vertical;
            shipParts = new ShipPart[Orientation == ShipOrientation.Horizontal ? Size.X : Size.Y];
            var current = BoardGridCoords2Absolute(Origin);
            for (var i = 0; i < shipParts.Length; i++, current += Orientation == ShipOrientation.Horizontal ? GameGlobals.ColumnWidth : Vector2DInt.Down)
            {
                shipParts[i] = new ShipPart(current, ShipPartStatus.Ok);
            }
        }

        private Vector2DInt BoardGridCoords2Absolute(Vector2DInt boardGridCoords)
        {
            return Board.PlayAreaOrigin + new Vector2DInt(boardGridCoords.X * GameGlobals.ColumnWidth.X,
                boardGridCoords.Y * Vector2DInt.Down.Y);
        }
    }
}