namespace Battleships;

public interface IGameObjectRenderer
{
    void Render(IGameObject gameObject, IRenderer renderer);
}