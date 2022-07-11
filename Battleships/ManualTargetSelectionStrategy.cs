using Battleships.Core;

namespace Battleships;

public class ManualTargetSelectionStrategy : ITargetSelectionStrategy
{
    private readonly UserPrompt userPrompt;
    private readonly IStringCoordsToVector2DIntConverter converter;

    public ManualTargetSelectionStrategy(UserPrompt userPrompt, IStringCoordsToVector2DIntConverter converter)
    {
        this.userPrompt = userPrompt;
        this.converter = converter;
    }

    /// <inheritdoc />
    public Vector2DInt SelectTarget(TargetSelectionStrategyArguments args)
    {
        if (args.FogOfWar is null or { Count: 0 })
        {
            throw new Exception("Manual target selection needs at least one Fog of War coordinate.");
        }

        do
        {
            var input = userPrompt.GetInput();
            if (!converter.TryConvert(input, out var target))
            {
                continue;
            }

            if (!args.FogOfWar.Contains(target))
            {
                continue;
            }

            return target;

        } while (true);
    }
}