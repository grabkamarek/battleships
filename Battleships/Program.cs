using Battleships.GameObjects;
using Battleships.GameObjects.Ships;
using Battleships.Rendering;

using System.Text;
using Battleships.Battle.Strategies;
using Battleships.Services;

namespace Battleships
{
    internal class Program
    {
        private static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            var game = CreateGame();
            SetupGame(game, new GameObjectIdsProvider(), StandardRandom.Create());

            game.Run();

            Console.ReadKey();
        }

        private static Game CreateGame()
        {
            return new Game(new ConsoleRenderer(), new Dictionary<Type, IGameObjectRenderer>
            {
                {
                    typeof(Label), new LabelRenderer()
                },
                {
                    typeof(Board), new BoardRenderer()
                },
                {
                    typeof(Ship), new ShipRenderer()
                },
                {
                    typeof(FogOfWar), new FogOfWarRenderer()
                }
            });
        }

        private static IEnumerable<Ship> CreateShips(Board board, IGameObjectIdsProvider gameObjectIdsProvider, IRandom randomizer)
        {
            var buildOrders = new[]
            {
                ShipType.Battleship, ShipType.Destroyer, ShipType.Destroyer
            };
            var ships = new List<Ship>();
            var otherShipsCoords = new List<Vector2DInt>();
            var placementProvider = new ShipPlacementProvider(randomizer, new ShipPlacementValidator());
            foreach (var shipType in buildOrders)
            {
                var isHorizontal = randomizer.CoinFlip();
                var shipLength = shipType == ShipType.Battleship ? 5 : 4;
                var shipCoords = placementProvider.FindValidShipCoords(
                    board.PlayAreaSize,
                    isHorizontal,
                    shipLength,
                    otherShipsCoords);
                otherShipsCoords.AddRange(shipCoords);
                ships.Add(
                    new Ship(
                        gameObjectIdsProvider.New,
                        board,
                        shipType,
                        shipCoords,
                        isHorizontal,
                        shipType == ShipType.Battleship ? ShipMarkers.Battleship : ShipMarkers.Destroyer));
            }

            return ships;
        }

        private static IEnumerable<Label> CreateLabels(IGameObjectIdsProvider gameObjectIdsProvider)
        {
            return new List<Label>
            {
                new Label(gameObjectIdsProvider.New, new Vector2DInt(18, 2), "Your board"),
                new Label(gameObjectIdsProvider.New, new Vector2DInt(55, 2), "Opponent's board"),
            };
        }

        private static void SetupGame(Game game, IGameObjectIdsProvider gameObjectIdsProvider, IRandom randomizer)
        {
            var gameObjects = new List<IGameObject>();
            gameObjects.AddRange(CreateLabels(gameObjectIdsProvider));

            for (var i = 0; i < 2; i++)
            {
                var boardOrigin = new Vector2DInt(i == 0 ? 5 : 45, 4);
                const int boardPlayAreaSideLength = 10;
                var board = new Board(gameObjectIdsProvider.New, boardOrigin, boardPlayAreaSideLength, boardPlayAreaSideLength);
                gameObjects.Add(board);
                var ships = CreateShips(board, gameObjectIdsProvider, randomizer).ToList();
                gameObjects.AddRange(ships);

                ITargetSelectionStrategy strategy;
                if (i == 0)
                {
                    strategy = new ManualTargetSelectionStrategy(new UserPrompt(game.Renderer), new StringCoordsToVector2DIntConverter());
                }
                else
                {
                    strategy = new AiTargetSelectionStrategy(new SeekingStrategy(randomizer),
                        new PrecisionStrategy(randomizer));
                }

                var fogOfWarOrigin = new Vector2DInt(i == 1 ? 5 : 45, 4) + GameConstants.ColumnWidth + Vector2DInt.Down;
                var fogOfWar = new FogOfWar(gameObjectIdsProvider.New, fogOfWarOrigin, new Vector2DInt(boardPlayAreaSideLength, boardPlayAreaSideLength));
                if (i == 0)
                {
                    gameObjects.Add(fogOfWar);
                }

                game.AddPlayer(new Player(strategy, ships, fogOfWar));
            }

            gameObjects.ForEach(game.AddGameObject);
        }
    }
}