namespace Battleships.Core
{
    public static class GameGlobals
    {
        public static readonly Vector2DInt ColumnWidth = Vector2DInt.Right * 3;
        public static readonly IGameObjectIdsProvider IdsProvider = new GameObjectIdsProvider();
        public const double MillisecondsPerUpdate = 1.0 / 5;

        public static readonly IRandom Random =
            new StandardRandom((int)(DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond));

        public static readonly IShipPlacementValidator ShipPlacementValidator = new ShipPlacementValidator();

        public static readonly IShipPlacementProvider ShipPlacementProvider =
            new ShipPlacementProvider(Random, ShipPlacementValidator);
    }
}