namespace Battleships.Core
{
    public class DateTimeProvider : IDateTimeProvider
    {
        /// <inheritdoc />
        public double GetUtcNowMilliseconds()
        {
            return (double)DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond;
        }
    }
}