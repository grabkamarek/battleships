namespace Battleships.Core
{
    public interface IDateTimeProvider
    {
        double GetUtcNowMilliseconds();
    }
}