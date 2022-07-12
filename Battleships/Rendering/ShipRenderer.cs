using Battleships.Core;
using Battleships.GameObjects.Ships;

namespace Battleships.Rendering
{
    public class ShipRenderer : GameObjectRenderer<Ship>
    {
        /// <inheritdoc />
        protected override void Render(Ship ship, IRenderer renderer)
        {
            var marker = $"[{ship.Marker}]";
            foreach (var part in ship.ShipParts)
            {
                var position = ship.Board.PlayAreaOrigin +
                               part.position with
                               {
                                   X = part.position.X * GameGlobals.ColumnWidth.X
                               };
                var color = part.status == ShipPartStatus.Hit ? ConsoleColor.Red : ConsoleColor.Cyan;
                renderer.Draw(position, marker, color);
            }
        }
    }
}