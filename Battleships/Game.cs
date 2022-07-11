using Battleships.GameObjects;
using Battleships.Rendering;

namespace Battleships
{
    public class Game
    {
        public IRenderer Renderer
        {
            get;
        }

        private readonly Dictionary<Type, IGameObjectRenderer> gameObjectRenderers;
        private IPlayer? player1;
        private IPlayer? player2;
        private IPlayer? winner;

        public Game(IRenderer renderer, Dictionary<Type, IGameObjectRenderer> gameObjectRenderers)
        {
            Renderer = renderer ?? throw new ArgumentNullException(nameof(renderer));
            this.gameObjectRenderers = gameObjectRenderers ?? throw new ArgumentNullException(nameof(gameObjectRenderers));
        }

        public void Run()
        {
            if (player1 is null || player2 is null)
            {
                throw new Exception("Cannot start game without 2 players.");
            }

            while (winner is null)
            {
                Render();
                ProcessInput();
            }
        }

        private void Render()
        {
            var byType = gameObjects.GroupBy(x => x.GetType()).Select(g => (g.Key, g.ToList())).ToList();
            foreach (var group in byType)
            {
                if (!gameObjectRenderers.TryGetValue(group.Key, out var gameObjectRenderer))
                {
                    continue;
                }

                foreach (var gameObject in group.Item2)
                {
                    gameObjectRenderer.Render(gameObject, Renderer);
                }
            }
        }

        private void ProcessInput()
        {
            if (Shoot(player1, player2))
            {
                winner = player1;
                return;
            }

            if (!Shoot(player2, player1))
            {
                return;
            }

            winner = player2;
        }

        private static bool Shoot(IPlayer shootingPlayer, IPlayer shotAtPlayer)
        {
            var target = shootingPlayer.SelectTarget();
            var result = shotAtPlayer.EvaluateShot(target);
            shootingPlayer.ShotResultNotification(target, result);
            return shotAtPlayer.AllShipsDestroyed;
        }

        private readonly List<IGameObject> gameObjects = new ();

        public void AddGameObject(IGameObject gameObject)
        {
            if (gameObjects.Any(x => x.Id == gameObject.Id))
            {
                throw new Exception($"Game object with id {gameObject.Id} already added.");
            }

            gameObjects.Add(gameObject);
        }

        public void AddPlayer(IPlayer player)
        {
            if (player1 is null)
            {
                player1 = player;
            }
            else if (player2 is null)
            {
                player2 = player;
            }
        }
    }
}