namespace Battleships
{
    public interface IRenderer
    {
        void Draw(Vector2DInt position, string toRender, ConsoleColor? color = null);
    }
}