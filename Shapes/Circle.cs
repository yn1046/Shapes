using System;
using Shapes.Exceptions;

namespace Shapes
{
    public class Circle : Polygon
    {
        private double _r;

        public double R
        {
            get => _r;
            set
            {
                if (value <= 0)
                    throw new InvalidSideException("Radius must be greater than 0");
                _r = value;
            }
        }

        public double Area => Math.PI * R * R;

        public Circle(double r)
        {
            if (r <= 0)
                throw new InvalidSideException("Radius must be greater than 0");
            R = r;
        }
    }
}