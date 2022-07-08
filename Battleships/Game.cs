namespace Battleships
{
    public class Game
    {
        private readonly IDateTimeProvider dateTimeProvider;

        public readonly IRenderer renderer;
        private readonly Dictionary<Type, IGameObjectRenderer> gameObjectRenderers;

        public Game(IDateTimeProvider dateTimeProvider, IRenderer renderer, Dictionary<Type, IGameObjectRenderer> gameObjectRenderers)
        {
            this.dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
            this.renderer = renderer ?? throw new ArgumentNullException(nameof(renderer));
            this.gameObjectRenderers = gameObjectRenderers ?? throw new ArgumentNullException(nameof(gameObjectRenderers));
        }

        public void Run()
        {
            var previous = dateTimeProvider.GetUtcNowMilliseconds();
            var lag = 0.0;
            while (true)
            {
                var current = dateTimeProvider.GetUtcNowMilliseconds();
                var elapsed = current - previous;
                previous = current;
                lag += elapsed;

                ProcessInput();

                while (lag >= GameGlobals.MillisecondsPerUpdate)
                {
                    Update(elapsed);
                    lag -= GameGlobals.MillisecondsPerUpdate;
                }

                Render();
            }
        }

        private void Update(double deltaTime)
        {
            foreach (var gameObject in gameObjects)
            {
                gameObject.Update(deltaTime);
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
                    gameObjectRenderer.Render(gameObject, renderer);
                }
            }
        }

        private void ProcessInput()
        {
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
    }
}