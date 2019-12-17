using System;
using NUnit.Framework;
using Shapes;
using Shapes.Exceptions;

namespace ShapesTest
{
    [TestFixture]
    [DefaultFloatingPointTolerance(0.0000001)]
    public class ShapesTest
    {
        private Triangle triangle345;
        private Triangle triangle6810;
        private Triangle triangle22;
        private Triangle triangle565;

        private Circle circle3;
        private Circle circle5;


        /// <summary>
        /// Initialize Shapes test objects
        /// </summary>
        [SetUp]
        protected void SetUp()
        {
            triangle345 = new Triangle(3, 4, 5);
            triangle6810 = new Triangle(6, 8, 10);
            triangle22 = new Triangle(2, 2, Math.Sqrt(8));
            triangle565 = new Triangle(5, 6, 5);

            circle3 = new Circle(3);
            circle5 = new Circle(5);
        }

        /// <summary>
        /// Assert that Area is calculated correctly
        /// </summary>
        [Test]
        public void AreaCalculation()
        {
            Assert.AreEqual(triangle345.Area, 6);
            Assert.AreEqual(triangle6810.Area, 24);
            Assert.AreEqual(triangle22.Area, 2);
            Assert.AreEqual(triangle565.Area, 12);

            Assert.AreEqual(circle3.Area, Math.PI * 9);
            Assert.AreEqual(circle5.Area, Math.PI * 25);
        }

        /// <summary>
        /// Assert that IsRight works correctly
        /// </summary>
        [Test]
        public void RightTriangleCheck()
        {
            Assert.IsTrue(triangle345.IsRight);
            Assert.IsTrue(triangle6810.IsRight);
            Assert.IsTrue(triangle22.IsRight);
            Assert.IsFalse(triangle565.IsRight);
        }

        /// <summary>
        /// Assert that impossible triangles throw an exception
        /// </summary>
        [Test]
        public void NoImpossibleValues()
        {
            Assert.Catch(
                typeof(ImpossibleShapeException),
                () => { new Triangle(2, 3, 10); });
            Assert.Catch(
                typeof(ImpossibleShapeException),
                () => { new Triangle(6, 2, 2); });
            Assert.Catch(
                typeof(ImpossibleShapeException),
                () => { triangle345.A = 20; });
        }
        
        /// <summary>
        /// Assert that shapes with non-positive sides throw an exception
        /// </summary>
        [Test]
        public void NoNonPositiveValues()
        {
            Assert.Catch(
                typeof(InvalidSideException),
                () => { new Triangle(2, 3, 0); });
            Assert.Catch(
                typeof(InvalidSideException),
                () => { new Triangle(-5, 3, 4); });
            Assert.Catch(
                typeof(InvalidSideException),
                () => { triangle565.A = 0; });
            Assert.Catch(
                typeof(InvalidSideException),
                () => { new Circle(0); });
            Assert.Catch(
                typeof(InvalidSideException),
                () => { circle3.R = -3; });
        }
        
        
    }
}