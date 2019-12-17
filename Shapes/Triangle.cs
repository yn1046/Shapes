using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using Shapes.Exceptions;

namespace Shapes
{
    public class Triangle : Polygon
    {
        private double _a;
        private double _b;
        private double _c;

        public double A
        {
            get => _a;
            set
            {
                Validate(value, B, C);
                _a = value;
            }
        }

        public double B
        {
            get => _b;
            set
            {
                Validate(A, value, C);
                _b = value;
            }
        }

        public double C
        {
            get => _c;
            set
            {
                Validate(A, B, value);
                _c = value;
            }
        }

        public double Area
        {
            get
            {
                var p = (A + B + C) / 2;
                return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
            }
        }

        /// <summary>
        /// Проверка на прямоугольность выполняется исходя из теоремы Пифагора.
        /// Сторона с максимальной длиной принимается за гипотенузу.
        /// Остальные две стороны — за катеты, они возводятся в квадрат и суммируются.
        /// Затем полученная сумма сравнивается с квадратом гипотенузы.
        /// Сравнение выполняется с точностью до 1/10000000 из-за арифметики с плавающей точкой.
        /// </summary>
        public bool IsRight
        {
            get
            {
                var sides = new List<double> {A, B, C};
                var max = sides.Max();
                var restSquareSum = sides
                    .Where((_, i) => i != sides.IndexOf(max))
                    .Select(p => p * p)
                    .Sum();

                return Math.Abs(max * max - restSquareSum) < 0.0000001;
            }
        }

        public Triangle(double a, double b, double c)
        {
            Validate(a, b, c);

            _a = a;
            _b = b;
            _c = c;
        }

        private bool WillBePossible(double a, double b, double c)
        {
            var sides = new List<double> {a, b, c};
            var max = sides.Max();
            var rest = sides.Where((_, i) => i != sides.IndexOf(max));

            return rest.Sum() > max;
        }

        private void Validate(double a, double b, double c)
        {
            if (a <= 0)
                throw new InvalidSideException("Side A must be greater than 0");
            if (b <= 0)
                throw new InvalidSideException("Side B must be greater than 0");
            if (c <= 0)
                throw new InvalidSideException("Side C must be greater than 0");
            if (!WillBePossible(a, b, c))
                throw new ImpossibleShapeException("Impossible triangle sides");
        }
    }
}