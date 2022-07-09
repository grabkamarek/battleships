namespace Battleships.Core
{
    public readonly record struct Vector2DInt(int X, int Y)
    {
        public static Vector2DInt Zero = new (0, 0);
        public static Vector2DInt Up = new(0, -1);
        public static Vector2DInt Down = new(0, 1);
        public static Vector2DInt Left = new(-1, 0);
        public static Vector2DInt Right = new(1, 0);

        public static Vector2DInt operator +(Vector2DInt a, Vector2DInt b)
        {
            return new Vector2DInt(a.X + b.X, a.Y + b.Y);
        }

        public static Vector2DInt operator -(Vector2DInt a, Vector2DInt b)
        {
            return new Vector2DInt(a.X - b.X, a.Y - b.Y);
        }

        public static Vector2DInt operator *(Vector2DInt a, int multiplier)
        {
            return new Vector2DInt(a.X * multiplier, a.Y * multiplier);
        }

        public static Vector2DInt operator *(int multiplier, Vector2DInt a)
        {
            return new Vector2DInt(a.X * multiplier, a.Y * multiplier);
        }

        public static Vector2DInt operator *(Vector2DInt a, Vector2DInt b)
        {
            return new Vector2DInt(a.X * a.X, a.Y * b.Y);
        }
    }
}