using Battleships.Core;
using Battleships.GameObjects;
using Battleships.Rendering;

namespace Battleships;

public class UserPrompt
{
    private readonly IRenderer renderer;

    public UserPrompt(IRenderer renderer)
    {
        this.renderer = renderer;
    }

    public string GetInput()
    {
        renderer.Draw(new Vector2DInt(5, 20), "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", Console.BackgroundColor);
        renderer.Draw(new Vector2DInt(5, 20), "Select target position: ", ConsoleColor.White);
        var input = string.Empty;
        while(true)
        {
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
            {
                break;
            }

            if (input == string.Empty && char.IsLetter(key.KeyChar) || input.Length == 1 && char.IsDigit(key.KeyChar))
            {
                input += key.KeyChar;
                continue;
            }

            break;
        }

        
        return input;
    }
}