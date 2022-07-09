using Battleships.GameObjects.Ships;

namespace Battleships.Rendering
{
    public class ShipRenderer : GameObjectRenderer<Ship>
    {
        /// <inheritdoc />
        protected override void Render(Ship gameObject, IRenderer renderer)
        {
            var marker = $"[{gameObject.Marker}]";
            foreach (var shipPart in gameObject.ShipParts)
            {
                renderer.Draw(shipPart.position, marker, shipPart.status == ShipPartStatus.Hit ? ConsoleColor.Red : ConsoleColor.Cyan);
            }
        }
    }
}