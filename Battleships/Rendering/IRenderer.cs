using Battleships.Services;

namespace Battleships.Rendering
{
    public interface IRenderer
    {
        void Draw(Vector2DInt position, string toRender, ConsoleColor? color = null);
    }
}