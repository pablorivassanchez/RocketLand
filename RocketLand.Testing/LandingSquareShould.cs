using NUnit.Framework;

namespace RocketLand.Testing
{
    public class LandingSquareShould
    {
        [Test]
        public void Create_LandingSquare()
        {
            var coordinate = new Coordinate(5, 1);

            var landingSquare = new LandingSquare(5, 1, LandingCondition.OkForLanding);

            Assert.AreEqual(coordinate, landingSquare.Coordinate);
            Assert.AreEqual(LandingCondition.OkForLanding, landingSquare.LandingCondition);
        }

        [Test]
        public void SetLandingCondition_LandingSquare()
        {
            var coordinate = new Coordinate(5, 1);

            var landingSquare = new LandingSquare(5, 1, LandingCondition.OkForLanding);

            landingSquare.SetLandingCondition(LandingCondition.Clash);

            Assert.AreEqual(LandingCondition.Clash, landingSquare.LandingCondition);
        }
    }
}
