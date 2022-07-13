namespace Battleships.Services
{
    public class StandardRandom : IRandom
    {
        private readonly Random random;
        private StandardRandom(int seed)
        {
            random = new Random(seed);
        }

        public static IRandom Create(int? seed = null)
        {
            return new StandardRandom(seed ?? (int)(DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond));
        }

        /// <inheritdoc />
        public int Next()
        {
            return random.Next();
        }

        /// <inheritdoc />
        public int Next(int maxValue)
        {
            return random.Next(maxValue);
        }

        /// <inheritdoc />
        public int Next(int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue);
        }

        /// <inheritdoc />
        public bool CoinFlip()
        {
            return random.Next() % 2 == 0;
        }
    }
}