using Battleships.Core;
using Battleships.GameObjects.Ships;

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

        private readonly List<Ship> ships = new List<Ship>();

        public IReadOnlyCollection<Ship> Ships => ships;

        public void AddShip(Ship ship)
        {
            if (ships.Any(x => x.Id == ship.Id))
            {
                throw new Exception($"Ship with id {ship.Id} already added.");
            }

            ships.Add(ship);
        }
    }
}