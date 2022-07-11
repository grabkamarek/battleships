using Battleships.Core;

namespace Battleships;

public interface IStringCoordsToVector2DIntConverter
{
    bool TryConvert(string input, out Vector2DInt result);
}