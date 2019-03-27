using Confusing_Hobo_Unleashed.UI;

namespace Confusing_Hobo_Unleashed.Shapes
{
    public abstract class Shape: Drawable
    {
        protected Position position;
        protected Rectangle boundingBox;

        protected Shape(Position position, Rectangle boundingBox)
        {
            this.position = position;
            this.boundingBox = boundingBox;
        }

        public Position getPosition()
        {
            return this.position;
        }

        public abstract void Draw();
    }
}