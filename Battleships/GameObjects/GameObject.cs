using Battleships.Services;

namespace Battleships.GameObjects
{
    public abstract class GameObject : IGameObject
    {
        protected GameObject(Guid id, Vector2DInt origin, Vector2DInt size)
        {
            Id = id;
            Origin = origin;
            Size = size;
            NeedsRender = true;
        }

        /// <inheritdoc />
        public Guid Id
        {
            get;
        }

        /// <inheritdoc />
        public Vector2DInt Origin
        {
            get;
        }

        /// <inheritdoc />
        public Vector2DInt Size
        {
            get;
            protected set;
        }

        public bool NeedsRender
        {
            get;
            set;
        }
    }
}