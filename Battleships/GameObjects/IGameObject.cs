using Battleships.Services;

namespace Battleships.GameObjects
{
    public interface IGameObject
    {
        Guid Id { get; }
        Vector2DInt Origin { get; }
        Vector2DInt Size { get; }
        bool NeedsRender
        {
            get;
            set;
        }
    }
}