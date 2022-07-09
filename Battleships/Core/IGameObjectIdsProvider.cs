namespace Battleships.Core
{
    public interface IGameObjectIdsProvider
    {
        Guid New
        {
            get;
        }
    }
}