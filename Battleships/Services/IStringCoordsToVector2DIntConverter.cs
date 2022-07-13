namespace Battleships.Services
{
    public interface IStringCoordsToVector2DIntConverter
    {
        bool TryConvert(string input, out Vector2DInt result);
    }
}