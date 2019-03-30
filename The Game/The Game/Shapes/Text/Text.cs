using System;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed.UI.UIElements
{
    public class Text : ShapeDecorator
    {
        private readonly string text;

        public Text(Text copy) : base(copy)
        {
            this.text = copy.text;
        }

        public Text(string text,  Shape decoratedShape, Pixel pixel, Position position, Window window) : base(
            decoratedShape,pixel, position, new Rectangle(position, text.Length, 1), window)
        {
            this.position = position;
            this.text = text;
        }

        public void centerText(Rectangle bounds) //TODO
        {
            if (bounds.getWidth() < text.Length)
            {
                throw new Exception(); //TODO
            }

            int x = position.x + (bounds.getWidth() - text.Length) / 2;
            int y = position.y + bounds.getHeight() / 2;
            this.position = new Position(x, y);
        }

        public override void Draw()
        {
            for (int x = 0; x < text.Length; x++)
            {
                drawToWindow(new Position(x, 0), this.pixel);
            }
        }

        public override Shape Clone()
        {
            return new Text(this);
        }
    }
}