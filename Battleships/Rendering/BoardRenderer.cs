using Battleships.GameObjects;

using System.Text;
using Battleships.Core;

namespace Battleships.Rendering
{
    public class BoardRenderer : GameObjectRenderer<Board>
    {
        /// <inheritdoc />
        protected override void Render(Board gameObject, IRenderer renderer)
        {
            DrawColumnHeaders(gameObject, renderer);
            DrawRowsHeaders(gameObject, renderer);
            DrawWater(gameObject, renderer);
            if (gameObject.FogOfWarActive)
            {
                DrawFogOfWar(gameObject, renderer);
            }
        }

        private static void DrawColumnHeaders(IGameObject gameObject, IRenderer renderer)
        {
            var rowLetter = 'A';
            var current = gameObject.Origin + GameGlobals.ColumnWidth;
            for (var i = 0; i < gameObject.Size.X; i++, current += GameGlobals.ColumnWidth)
            {
                renderer.Draw(current, $"[{rowLetter++}]");
            }
        }

        private static void DrawRowsHeaders(IGameObject gameObject, IRenderer renderer)
        {
            var current = gameObject.Origin + Vector2DInt.Down;
            for (var i = 0; i < gameObject.Size.Y; i++, current += Vector2DInt.Down)
            {
                renderer.Draw(current, $"[{i}]");
            }
        }

        private const string Water = "~~~";
        private static void DrawWater(IGameObject gameObject, IRenderer renderer)
        {
            var current = gameObject.Origin + Vector2DInt.Down + GameGlobals.ColumnWidth;
            var waterRow = MakeBetterWater(CreateRowOf(Water, gameObject.Size.X));
            for (var i = 0; i < gameObject.Size.Y; i++, current += Vector2DInt.Down)
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

        private static string Fog = "\u2591\u2591\u2591";
        private static void DrawFogOfWar(IGameObject gameObject, IRenderer renderer)
        {
            var current = gameObject.Origin + Vector2DInt.Down + GameGlobals.ColumnWidth;
            var waterRow = CreateRowOf(Fog, gameObject.Size.X);
            for (var i = 0; i < gameObject.Size.Y; i++, current += Vector2DInt.Down)
            {
                renderer.Draw(current, waterRow);
            }
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