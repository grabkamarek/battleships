using Battleships.Core;

namespace Battleships.Rendering
{
    public class ConsoleRenderer : IRenderer
    {
        /// <inheritdoc />
        public void Draw(Vector2DInt position, string toRender, ConsoleColor? color = null)
        {
            var prevColor = Console.ForegroundColor;
            if (color is not null)
            {
                Console.ForegroundColor = color.Value;
            }

            Console.SetCursorPosition(position.X, position.Y);
            Console.Write(toRender);
            Console.ForegroundColor = prevColor;
        }
    }
}