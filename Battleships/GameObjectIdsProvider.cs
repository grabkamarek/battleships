namespace Battleships
{
    public class GameObjectIdsProvider : IGameObjectIdsProvider
    {
        /// <inheritdoc />
        public Guid New => Guid.NewGuid();
    }
}