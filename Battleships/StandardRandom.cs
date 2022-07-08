namespace Battleships;

public class StandardRandom : IRandom
{
    private readonly Random random;
    public StandardRandom(int seed)
    {
        random = new Random(seed);
    }

    public StandardRandom()
    {
        random = new Random();
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
}