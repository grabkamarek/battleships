using Battleships.GameObjects;
using Battleships.GameObjects.Ships;
using Battleships.Rendering;

using System.Text;
using Battleships.Core;

namespace Battleships
{
    internal class Program
    {
        private static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            var game = CreateGame();
            SetupGame(game);

            game.Run();

            Console.ReadKey();
        }

        private static Game CreateGame()
        {
            var shipRenderer = new ShipRenderer();
            return new Game(new ConsoleRenderer(), new Dictionary<Type, IGameObjectRenderer>
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

        private static void SetupGame(Game game)
        {
            var gameObjects = new List<IGameObject>();
            gameObjects.AddRange(CreateLabels());
            var boards = CreateBoards();
            gameObjects.AddRange(boards);

            foreach (var board in boards)
            {
                var ships = CreateShips(board).ToList();
                gameObjects.AddRange(ships);

                ITargetSelectionStrategy strategy;
                if (board.FogOfWarActive)
                {
                    strategy = new AiTargetSelectionStrategy(new SeekingStrategy(GameGlobals.Random),
                        new PrecisionStrategy(GameGlobals.Random));
                }
                else
                {
                    //var promptLabel = new Label(GameGlobals.IdsProvider.New, new Vector2DInt(5, 20), "Select target: ");
                    //var prompt = new UserPrompt(promptLabel);
                    //gameObjects.Add(prompt);
                    strategy = new ManualTargetSelectionStrategy(new UserPrompt(game.Renderer), new StringCoordsToVector2DIntConverter());
                }

                game.AddPlayer(new Player(strategy, ships, board.PlayAreaSize));
            }

            gameObjects.ForEach(game.AddGameObject);
        }
    }
}