using System.Diagnostics.CodeAnalysis;
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
            ThrowIfAnyPlayerIsNull();

            while (true)
            {
                Render();
                if (winner is not null)
                {
                    break;
                }

                ProcessInput();
            }

            Console.Clear();

            Console.WriteLine($"{(winner == player1 ? "You" : "AI")} won!");
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
            ThrowIfAnyPlayerIsNull();

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
            if (gameObject == null)
            {
                throw new ArgumentNullException(nameof(gameObject));
            }

            if (gameObjects.Any(x => x.Id == gameObject.Id))
            {
                throw new Exception($"Game object with id {gameObject.Id} already added.");
            }

            gameObjects.Add(gameObject);
        }

        public void AddPlayer(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            if (player1 is null)
            {
                player1 = player;
            }
            else if (player2 is null)
            {
                player2 = player;
            }
        }

        [MemberNotNull(nameof(player1))]
        [MemberNotNull(nameof(player2))]
        private void ThrowIfAnyPlayerIsNull()
        {
            if (player1 is null || player2 is null)
            {
                throw new Exception("Game cannot run without 2 players set. You can add player using Game.AddPlayer method.");
            }
        }
    }
}