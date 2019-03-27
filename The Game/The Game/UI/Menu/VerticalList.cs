﻿using System;
using System.Collections.Generic;
using Confusing_Hobo_Unleashed.Colors;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.Tools;
using Confusing_Hobo_Unleashed.UI.UIElements;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed.UI
{
    internal class VerticalList : AbstractList
    {
        public VerticalList( CircularList<UIObject> items, Shape shape): base(items,shape)
        {
        }

        public VerticalList(CircularList<UIObject> items, Shape activeShape, Shape inactiveShape): base(items,activeShape,inactiveShape)
        {
        }

        public override bool IsActive()
        {
            throw new NotImplementedException();
        }

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
                case Input.UP:
                     items.decrement();
                     break;
                case Input.DOWN:
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
    }
}