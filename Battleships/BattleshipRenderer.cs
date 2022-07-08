namespace Battleships;

public class BattleshipRenderer : GameObjectRenderer<Battleship>
{
    /// <inheritdoc />
    protected override void Render(Battleship gameObject, IRenderer renderer)
    {
        var isHorizontal = gameObject.Size.X > 0;
        var limit = isHorizontal ? gameObject.Size.X : gameObject.Size.Y;
        var current = gameObject.Origin;
        for (var i = 0; i < limit; i++, current += isHorizontal ? GameGlobals.ColumnWidth : Vector2DInt.Down)
        {
            renderer.Draw(current, "[B]", gameObject.ShipParts.ElementAt(i).status == ShipPartStatus.Hit ? ConsoleColor.Red : null);
        }
    }
}