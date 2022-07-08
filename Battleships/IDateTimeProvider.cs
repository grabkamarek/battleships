namespace Battleships
{
    public interface IDateTimeProvider
    {
        double GetUtcNowMilliseconds();
    }
}