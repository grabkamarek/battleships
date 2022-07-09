using System.Text;

namespace Battleships
{
    internal class Program
    {
        private static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            var game = CreateGame();
            var gameObjects = CreateGameObjects();
            foreach (var gameObject in gameObjects)
            {
                game.AddGameObject(gameObject);
            }

            game.Run();

            Console.ReadKey();
        }

        private static Game CreateGame()
        {
            var shipRenderer = new ShipRenderer();
            return new Game(new DateTimeProvider(), new ConsoleRenderer(), new Dictionary<Type, IGameObjectRenderer>
            {
                {
                    typeof(Label), new LabelRenderer()
                },
                {
                    typeof(Board), new BoardRenderer()
                },
                {
                    typeof(Battleship), shipRenderer
                },
                {
                    typeof(Destroyer), shipRenderer
                },
            });
        }

        private static IEnumerable<Ship> CreateShips(Board board)
        {
            var ships = new List<Ship>();

            var shipSize = GameGlobals.Random.Next() % 2 == 0 ? new Vector2DInt(5, 0) : new Vector2DInt(0, 5);
            var shipOrigin = GameGlobals.ShipPlacementProvider.FindValidOrigin(board.PlayAreaSize, shipSize,
                ships.Select(x => x.ShipParts.Select(p => p.position).ToList()).ToList());
            ships.Add(new Battleship(GameGlobals.IdsProvider.New, board, shipOrigin, shipSize));

            shipSize = GameGlobals.Random.Next() % 2 == 0 ? new Vector2DInt(3, 0) : new Vector2DInt(0, 3);
            shipOrigin = GameGlobals.ShipPlacementProvider.FindValidOrigin(board.PlayAreaSize, shipSize,
                ships.Select(x => x.ShipParts.Select(p => p.position).ToList()).ToList());
            ships.Add(new Destroyer(GameGlobals.IdsProvider.New, board, shipOrigin, shipSize));

            shipSize = GameGlobals.Random.Next() % 2 == 0 ? new Vector2DInt(3, 0) : new Vector2DInt(0, 3);
            shipOrigin = GameGlobals.ShipPlacementProvider.FindValidOrigin(board.PlayAreaSize, shipSize,
                ships.Select(x => x.ShipParts.Select(p => p.position).ToList()).ToList());
            ships.Add(new Destroyer(GameGlobals.IdsProvider.New, board, shipOrigin, shipSize));

            return ships;
        }

        private static IReadOnlyCollection<Board> CreateBoards()
        {
            return new List<Board>
            {
                new Board(GameGlobals.IdsProvider.New, new Vector2DInt(5, 4), 10, 10),
                new Board(GameGlobals.IdsProvider.New, new Vector2DInt(45, 4), 10, 10)
                {
                    FogOfWarActive = true
                }
            };
        }

        private static IEnumerable<Label> CreateLabels()
        {
            return new List<Label>
            {
                new Label(GameGlobals.IdsProvider.New, new Vector2DInt(18, 2), "Your board"),
                new Label(GameGlobals.IdsProvider.New, new Vector2DInt(55, 2), "Opponent's board"),
            };
        }

        private static IEnumerable<IGameObject> CreateGameObjects()
        {
            var gameObjects = new List<IGameObject>();
            gameObjects.AddRange(CreateLabels());
            var boards = CreateBoards();
            gameObjects.AddRange(boards);

            foreach (var board in boards)
            {
                gameObjects.AddRange(CreateShips(board));
            }
            
            return gameObjects;
        }
    }
}