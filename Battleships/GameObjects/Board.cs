using Battleships.Core;

namespace Battleships.GameObjects
{
    public class Board : GameObject
    {
        public Board(Guid id, Vector2DInt origin, int width, int height)
            : base(id, origin, new Vector2DInt(width, height))
        {
            PlayAreaOrigin = Origin + GameGlobals.ColumnWidth + Vector2DInt.Down;
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