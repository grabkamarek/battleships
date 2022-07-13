using Battleships.Rendering;

namespace Battleships.Services
{
    public class UserPrompt : IUserPrompt
    {
        private readonly IRenderer renderer;

        public UserPrompt(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public string GetInput()
        {
            renderer.Draw(new Vector2DInt(5, 20), "                                    ", Console.BackgroundColor);
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
}