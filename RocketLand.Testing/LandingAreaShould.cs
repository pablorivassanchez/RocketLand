using NUnit.Framework;
using System;

namespace RocketLand.Testing
{
    public class LandingAreaShould
    {

        [Test]
        public void Create_LandingArea()
        {
            var landingArea = new LandingArea(100, 100, new Coordinate(1, 1), 5, 5);

            Assert.AreEqual(landingArea.AreaDimension, 100 * 100);
        }

        [Test]
        public void Create_LandingArea_With_LandPlatform_Out_Throw_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var landingArea = new LandingArea(100, 100, new Coordinate(1, 3), 100, 100);
            });
        }

        [Test]
        public void Create_LandingArea_With_0_Size()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var landingArea = new LandingArea(0, 0, new Coordinate(1, 3), 100, 100);
            });
        }

        [Test]
        public void AskForPosition_Return_OkForLanding()
        {
            var landingArea = new LandingArea(100, 100, new Coordinate(5, 5), 10, 10);

            var result = landingArea.AskForPosition(5, 5);

            Assert.AreEqual(result, LandingCondition.OkForLanding);
        }

        [Test]
        public void AskForPosition_Return_OutOfPlatform()
        {
            var landingArea = new LandingArea(100, 100, new Coordinate(5, 5), 10, 10);

            var result = landingArea.AskForPosition(15, 16);

            Assert.AreEqual(result, LandingCondition.OutOfPlatform);
        }

        [Test]
        public void TwoRockets_AskForSamePosition_Return_Crash()
        {
            var landingArea = new LandingArea(100, 100, new Coordinate(5, 5), 10, 10);

            var result = landingArea.AskForPosition(5, 5);
            var result2 = landingArea.AskForPosition(5, 5);

            Assert.AreEqual(result2, LandingCondition.Clash);
        }

        [Test]
        public void TwoRockets_AskForAdjacentPosition_Return_Crash()
        {
            var landingArea = new LandingArea(100, 100, new Coordinate(5, 5), 10, 10);

            var result = landingArea.AskForPosition(7, 7);
            var result2 = landingArea.AskForPosition(8, 7);

            Assert.AreEqual(result2, LandingCondition.Clash);
        }
    }
}