﻿using System.Collections.Generic;
using Confusing_Hobo_Unleashed.Colors;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.Tools;
using Confusing_Hobo_Unleashed.UI.UIElements;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed.UI
{
    public class HorizonalList : AbstractList
    {

        public override void HandleAction(Input action)
        {
            if (isActive)
            {
                HandleActiveAction(action);
            }
            else
            {
                HandleInactiveAction(action);
            }
        }

        private void HandleActiveAction(Input action)
        {
            switch (action)
            {
                case Input.BACK:
                    this.isActive = false;
                    break;
                case Input.LEFT:
                    items.decrement();
                    break;
                case Input.RIGHT:
                    items.increment();
                    break;
                default:
                    items.currentItem().HandleAction(action);
                    break;
            }
        }

        private void HandleInactiveAction(Input action)
        {
            switch (action)
            {
                case Input.A:
                    this.isActive = true;
                    break;
            }
        }

        public HorizonalList(CircularList<UIObject> items, int padding = 0) : base(items, padding)
        {
        }

        public HorizonalList(CircularList<UIObject> items, Image image) : base(items, image)
        {
        }

        public HorizonalList(CircularList<UIObject> items, Position position, Image image) : base(items, position, image)
        {
        }

        public HorizonalList(CircularList<UIObject> items, Position position, Image activeImage, Image inactiveImage) : base(items, position, activeImage, inactiveImage)
        {
        }
    }
}