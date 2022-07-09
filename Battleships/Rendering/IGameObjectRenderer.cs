using Battleships.GameObjects;

namespace Battleships.Rendering
{
    public interface IGameObjectRenderer
    {
        void Render(IGameObject gameObject, IRenderer renderer);
    }
}