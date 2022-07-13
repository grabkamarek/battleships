using Battleships.GameObjects;

using System.Text;
using Battleships.Services;

namespace Battleships.Rendering
{
    public class BoardRenderer : GameObjectRenderer<Board>
    {
        /// <inheritdoc />
        protected override void Render(Board board, IRenderer renderer)
        {
            DrawColumnHeaders(board.Origin, board.Size.X, renderer);
            DrawColumnHeaders(board.Origin + Vector2DInt.Down * (board.Size.Y + 1), board.Size.X, renderer);
            DrawRowsHeaders(board.Origin, board.Size.Y, renderer);
            DrawRowsHeaders(board.Origin + GameConstants.ColumnWidth * (board.Size.X + 1), board.Size.Y, renderer);
            DrawWater(board, renderer);
        }

        private static void DrawColumnHeaders(Vector2DInt position, int columnCount, IRenderer renderer)
        {
            var rowLetter = 'A';
            var current = position + GameConstants.ColumnWidth;
            for (var i = 0; i < columnCount; i++, current += GameConstants.ColumnWidth)
            {
                renderer.Draw(current, $"[{rowLetter++}]");
            }
        }

        private static void DrawRowsHeaders(Vector2DInt position, int rowsCount, IRenderer renderer)
        {
            var current = position + Vector2DInt.Down;
            for (var i = 0; i < rowsCount; i++, current += Vector2DInt.Down)
            {
                renderer.Draw(current, $"[{i}]");
            }
        }

        private const string Water = "~~~";
        private static void DrawWater(IGameObject board, IRenderer renderer)
        {
            var current = board.Origin + Vector2DInt.Down + GameConstants.ColumnWidth;
            var waterRow = MakeBetterWater(CreateRowOf(Water, board.Size.X));
            for (var i = 0; i < board.Size.Y; i++, current += Vector2DInt.Down)
            {
                renderer.Draw(current, waterRow);
            }
        }

        private static string MakeBetterWater(string waterRow)
        {
            var chars = waterRow.ToCharArray();
            for (var i = 0; i < chars.Length; i += 2)
            {
                chars[i] = ' ';
            }

            return new string(chars);
        }

        private static string CreateRowOf(string text, int length)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < length; i++)
            {
                sb.Append(text);
            }

            return sb.ToString();
        }
    }
}