using Battleships.Services;

namespace Battleships.Battle.Strategies
{
    public class SeekingStrategy : ITargetSelectionStrategy
    {
        private readonly IRandom random;

        public SeekingStrategy(IRandom random)
        {
            this.random = random;
        }

        /// <inheritdoc />
        public Vector2DInt SelectTarget(TargetSelectionStrategyArguments args)
        {
            if (args.FogOfWar is null or { Count: 0 })
            {
                throw new Exception("Seeking strategy needs at least one Fog of War coordinate.");
            }

            return args.FogOfWar.ElementAt(random.Next(0, args.FogOfWar.Count));
        }
    }
}