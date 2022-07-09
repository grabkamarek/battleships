using Battleships.Core;

namespace Battleships.GameObjects
{
    public class Label : GameObject
    {
        private string text;

        public Label(Guid id, Vector2DInt origin, string text)
            : base(id, origin, new Vector2DInt(0, text.Length))
        {
            this.text = text;
        }

        public string Text
        {
            get => text;
            set
            {
                text = value;
                if (text.Length <= Size.X)
                {
                    return;
                }

                Size = new Vector2DInt(0, text.Length);
                NeedsRender = true;
            }
        }
    }
}