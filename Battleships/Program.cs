namespace Battleships
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game.Renderer.DrawText(new Vector2DInt(18, 2), "Your board");
            var playerBoard = new Board(new Vector2DInt(5, 4), new Vector2DInt(10, 10));
            playerBoard.Render();

            Game.Renderer.DrawText(new Vector2DInt(55, 2), "Opponent's board");
            var aiBoard = new Board(new Vector2DInt(45, 4), new Vector2DInt(10, 10));
            aiBoard.Render();

            Console.ReadKey();
        }
    }

    public interface IRenderable
    {
        void Render();
    }

    public interface IGameObject
    {
        Vector2DInt Origin { get; }
        Vector2DInt Size { get; }
        Vector2DInt TopLeft { get; }
        Vector2DInt TopRight { get; }
        Vector2DInt BottomLeft { get; }
        Vector2DInt BottomRight { get; }
    }

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
    }

    public class Board : IGameObject, IRenderable
    {
        public Board(Vector2DInt origin, Vector2DInt size)
        {
            Origin = origin;
            Size = size;
            TopLeft = Origin;
            TopRight = Origin + Vector2DInt.Right * Size.X;
            BottomLeft = Origin + Vector2DInt.Down * Size.Y;
            BottomRight = Origin + Size;
        }

        /// <inheritdoc />
        public Vector2DInt Origin
        {
            get;
        }

        /// <inheritdoc />
        public Vector2DInt Size
        {
            get;
        }

        /// <inheritdoc />
        public Vector2DInt TopLeft
        {
            get;
        }

        /// <inheritdoc />
        public Vector2DInt TopRight
        {
            get;
        }

        /// <inheritdoc />
        public Vector2DInt BottomLeft
        {
            get;
        }

        /// <inheritdoc />
        public Vector2DInt BottomRight
        {
            get;
        }

        /// <inheritdoc />
        public void Render()
        {
            DrawColumnHeaders();
            DrawRowsHeaders();
            DrawWater();
        }

        private Vector2DInt columnWidth = Vector2DInt.Right * 3;
        private void DrawColumnHeaders()
        {
            
            var current = Origin + columnWidth;
            var last = Origin + columnWidth + columnWidth * Size.X;
            var columnNumber = 0;
            while (current != last)
            {
                Game.Renderer.Draw(current, '[');
                current += Vector2DInt.Right;
                Game.Renderer.Draw(current, (char)(48 + columnNumber++));
                current += Vector2DInt.Right;
                Game.Renderer.Draw(current, ']');
                current += Vector2DInt.Right;
            }
        }

        private void DrawRowsHeaders()
        {
            var current = Origin + Vector2DInt.Down;
            var last = BottomLeft + Vector2DInt.Down;
            var rowLetter = 'A';
            while (current != last)
            {
                Game.Renderer.Draw(current, '[');
                Game.Renderer.Draw(current + Vector2DInt.Right, rowLetter++);
                Game.Renderer.Draw(current + Vector2DInt.Right * 2, ']');
                current += Vector2DInt.Down;
            }
        }

        private const char Water = '~';
        private void DrawWater()
        {
            var current = Origin + columnWidth + Vector2DInt.Down;
            var last = current + Size with
            {
                X = Size.X * columnWidth.X
            };
            var firstColumnX = (Origin + columnWidth).X;
            while (current.Y < last.Y)
            {
                Game.Renderer.Draw(current + Vector2DInt.Right, Water);
                current += columnWidth;
                if (current.X == last.X)
                {
                    current = new Vector2DInt(firstColumnX, current.Y + 1);
                }
            }
        }
    }

    public static class Game
    {
        public static IRenderer<char> Renderer = new ConsoleRenderer();
    }

    public class ConsoleRenderer : IRenderer<char>
    {
        /// <inheritdoc />
        public void FillRect(Vector2DInt origin, Vector2DInt size, char renderUnit)
        {
            Console.SetCursorPosition(origin.X, origin.Y);
            Console.Write(renderUnit);
        }

        /// <inheritdoc />
        public void Draw(Vector2DInt position, char renderUnit)
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write(renderUnit);
        }

        /// <inheritdoc />
        public void DrawText(Vector2DInt position, string text)
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write(text);
        }
    }

    public interface IRenderer<in T>
    {
        void FillRect(Vector2DInt origin, Vector2DInt size, T renderUnit);
        void Draw(Vector2DInt position, T renderUnit);
        void DrawText(Vector2DInt position, string text);
    }
}