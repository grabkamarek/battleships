using Battleships.Core;

namespace Battleships;

class StringCoordsToVector2DIntConverter : IStringCoordsToVector2DIntConverter
{
    private const string AcceptableLetters = "ABCDEFGHIJ";

    /// <inheritdoc />
    public bool TryConvert(string input, out Vector2DInt result)
    {
        result = Vector2DInt.Zero;

        if (string.IsNullOrWhiteSpace(input))
        {
            return false;
        }

        if (input.Length != 2)
        {
            return false;
        }

        var upper = input.ToUpperInvariant();
        if (!char.IsLetter(upper[0]) || !AcceptableLetters.Contains(upper[0]))
        {
            return false;
        }

        if (!char.IsDigit(upper[1]))
        {
            return false;
        }

        
        result = new Vector2DInt(AcceptableLetters.IndexOf(upper[0]), int.Parse(upper[1].ToString()));
        return true;
    }
}