using Battleships.GameObjects;

namespace Battleships.Rendering
{
    public abstract class GameObjectRenderer<T> : IGameObjectRenderer
        where T : IGameObject
    {
        /// <inheritdoc />
        public void Render(IGameObject gameObject, IRenderer renderer)
        {
            if (!gameObject.NeedsRender)
            {
                return;
            }

            Render((T)gameObject, renderer);
            gameObject.NeedsRender = false;
        }

        protected abstract void Render(T gameObject, IRenderer renderer);
    }
}