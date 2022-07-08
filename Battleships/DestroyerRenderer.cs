namespace Battleships;

public class DestroyerRenderer : GameObjectRenderer<Destroyer>
{
    /// <inheritdoc />
    protected override void Render(Destroyer gameObject, IRenderer renderer)
    {
        var isHorizontal = gameObject.Size.X > 0;
        var limit = isHorizontal ? gameObject.Size.X : gameObject.Size.Y;
        var current = GameGlobals.ColumnWidth + gameObject.Origin * GameGlobals.ColumnWidth;
        for (var i = 0; i < limit; i++, current += isHorizontal ? GameGlobals.ColumnWidth : Vector2DInt.Down)
        {
            renderer.Draw(current, "[D]", gameObject.ShipParts.ElementAt(i).status == ShipPartStatus.Hit ? ConsoleColor.Red : null);
        }
    }
}