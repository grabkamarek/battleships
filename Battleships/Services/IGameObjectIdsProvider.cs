namespace Battleships.Services
{
    public interface IGameObjectIdsProvider
    {
        Guid New
        {
            get;
        }
    }
}