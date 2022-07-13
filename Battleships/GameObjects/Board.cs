using Battleships.Services;

namespace Battleships.GameObjects
{
    public class Board : GameObject
    {
        public Board(Guid id, Vector2DInt origin, int width, int height)
            : base(id, origin, new Vector2DInt(width, height))
        {
            PlayAreaOrigin = Origin + GameConstants.ColumnWidth + Vector2DInt.Down;
            PlayAreaSize = Size;
        }

        public bool FogOfWarActive
        {
            get;
            set;
        }

        public Vector2DInt PlayAreaOrigin
        {
            get;
        }

        public Vector2DInt PlayAreaSize
        {
            get;
        }
    }
}