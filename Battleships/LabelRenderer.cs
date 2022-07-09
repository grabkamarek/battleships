namespace Battleships
{
    public class LabelRenderer : GameObjectRenderer<Label>
    {
        /// <inheritdoc />
        protected override void Render(Label gameObject, IRenderer renderer)
        {
            renderer.Draw(gameObject.Origin, gameObject.Text);
        }
    }
}