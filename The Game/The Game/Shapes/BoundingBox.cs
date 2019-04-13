﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Confusing_Hobo_Unleashed.Shapes;

namespace Confusing_Hobo_Unleashed.UI
{
    public class BoundingBox
    {
        protected Position position;
        protected readonly int width;
        protected readonly int height;

        public BoundingBox(BoundingBox copy)
        {
            if (copy.position != null)
            {
                this.position = new Position(copy.position);
            }

            this.width = copy.width;
            this.height = copy.height;
        }

        public BoundingBox(Position position, int width, int height)
        {
            this.position = position;
            this.width = width;
            this.height = height;
        }

        public BoundingBox(int width, int height)
        {
            this.position = null;
            this.width = width;
            this.height = height;
        }

        public Position getGeometricCenter()
        {
            return new Position(this.width / 2, this.height / 2);
        }

        public Position getPositionalCenter()
        {
            if (position == null)
            {
                throw new NullReferenceException();
            }

            return new Position(this.position.x + this.width / 2, this.position.y + this.height / 2);
        }

        public Position getPosition()
        {
            return position;
        }

        public int getWidth()
        {
            return width;
        }

        public int getHeight()
        {
            return height;
        }

        public bool isPointInside(Position position)
        {
            return this.isPointInside(position.x, position.y);
        }

        public bool isPointInside(int x, int y)
        {
            if (x < this.position.x)
            {
                return false;
            }

            if (y < this.position.y)
            {
                return false;
            }

            if (x > this.position.x + this.width)
            {
                return false;
            }

            if (y > this.position.y + this.height)
            {
                return false;
            }

            return true;
        }

        public BoundingBox grow(BoundingBox boundingBox)
        {
            int minX = Math.Min(this.position.x, boundingBox.position.x);
            int minY = Math.Min(this.position.y, boundingBox.position.y);
            int maxX = Math.Max(this.position.x + this.width, boundingBox.position.x + boundingBox.width);
            int maxY = Math.Max(this.position.y + this.height, boundingBox.position.y + boundingBox.height);
            return new BoundingBox(new Position(minX, minY), maxX - minX, maxY - minY);
        }

        public BoundingBox grow(int padding)
        {
            return new BoundingBox(new Position(this.position.x-padding, this.position.y-padding),this.width+padding, this.height+padding);
        }
    }
}