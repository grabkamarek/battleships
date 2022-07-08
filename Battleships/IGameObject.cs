namespace Battleships
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

        void Update(double deltaTime);
    }
}