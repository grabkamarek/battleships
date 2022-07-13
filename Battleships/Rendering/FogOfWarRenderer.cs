using Battleships.GameObjects;
using Battleships.Services;

namespace Battleships.Rendering;

public class FogOfWarRenderer : GameObjectRenderer<FogOfWar>
{
    private static string Fog = "\u2591\u2591\u2591";

    /// <inheritdoc />
    protected override void Render(FogOfWar fogOfWar, IRenderer renderer)
    {
        for (var i = 0; i < fogOfWar.Coordinates.Count; i++)
        {
            var pos = fogOfWar.Coordinates.ElementAt(i);
            var position = fogOfWar.Origin + pos with
            {
                X = pos.X * GameConstants.ColumnWidth.X
            };
            renderer.Draw(position, Fog);
        }
    }
}