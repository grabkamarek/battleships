namespace Battleships.Core
{
    public class GameObjectIdsProvider : IGameObjectIdsProvider
    {
        /// <inheritdoc />
        public Guid New => Guid.NewGuid();
    }
}