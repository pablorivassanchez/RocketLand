using NUnit.Framework;

namespace RocketLand.Testing
{
    public class CoordinateShould
    {

        [Test]
        public void Create_Coordinate()
        {
            var coordinate = new Coordinate(5, 1);

            Assert.AreEqual(coordinate.X, 1);
            Assert.AreEqual(coordinate.Y, 5);
        }

        [Test]
        public void Coordinate_Equals()
        {
            var coordinate1 = new Coordinate(1, 1);

            var coordinate2 = new Coordinate(1, 1);

            Assert.IsTrue(coordinate1 == coordinate2);
        }

        [Test]
        public void Coordinate_Equals_Method()
        {
            var coordinate1 = new Coordinate(1, 1);

            var coordinate2 = new Coordinate(1, 1);

            Assert.IsTrue(coordinate1.Equals(coordinate2));
        }

        [Test]
        public void Coordinate_NotEquals()
        {
            var coordinate1 = new Coordinate(1, 1);

            var coordinate2 = new Coordinate(1, 2);

            Assert.IsTrue(coordinate1 != coordinate2);
        }

        [Test]
        public void Coordinate_Sum()
        {
            var coordinate1 = new Coordinate(1, 1);

            var coordinate2 = new Coordinate(1, 1);

            var expectedResult = new Coordinate(2, 2);

            Assert.AreEqual(coordinate1 + coordinate2, expectedResult);
        }

        [Test]
        public void Coordinate_subtraction()
        {
            var coordinate1 = new Coordinate(1, 1);

            var coordinate2 = new Coordinate(2, 2);

            var expectedResult = new Coordinate(1, 1);

            Assert.AreEqual(coordinate2 - coordinate1, expectedResult);
        }

    }
}
