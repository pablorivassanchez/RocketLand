namespace RocketLand
{
    public class LandingSquare
    {
        public Coordinate Coordinate { get; private set; }
        public LandingCondition LandingCondition { get; private set; }

        public LandingSquare(uint y, uint x, LandingCondition landingCondition)
        {
            Coordinate = new Coordinate(y, x);
            LandingCondition = landingCondition;
        }

        public void SetLandingCondition(LandingCondition landingCondition)
        {
            LandingCondition = landingCondition;
        }
    }
}
