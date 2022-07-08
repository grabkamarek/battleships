namespace Battleships
{
    public interface IGameObjectIdsProvider
    {
        Guid New
        {
            get;
        }
    }
}