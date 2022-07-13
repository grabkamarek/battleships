using Battleships.Services;

namespace Battleships.GameObjects;

public class FogOfWar : GameObject
{
    private readonly List<Vector2DInt> coordinates = new List<Vector2DInt>();

    public IReadOnlyCollection<Vector2DInt> Coordinates => coordinates;

    /// <inheritdoc />
    public FogOfWar(Guid id, Vector2DInt origin, Vector2DInt size)
        : base(id, origin, size)
    {
        for (var x = 0; x < size.X; x++)
        {
            for (var y = 0; y < size.Y; y++)
            {
                coordinates.Add(new Vector2DInt(x, y));
            }
        }
    }

    public void RemoveCoordinate(Vector2DInt position)
    {
        coordinates.Remove(position);
        NeedsRender = true;
    }
}