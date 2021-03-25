using System;
using System.Collections.Generic;
using System.Linq;

namespace RocketLand
{
    public class LandingArea
    {
        private List<LandingSquare> Area { get; set; }
        private Coordinate StartLandingPlatform { get; set; }
        public long AreaDimension { get { return Area.Count; } }

        public LandingArea(uint landingAreaSizeX,
                           uint landingAreaSizeY,
                           Coordinate startLandingPlatform,
                           uint landingPlatformSizeX,
                           uint landingPlatformSizeY)
        {
            if (landingAreaSizeX < 1)
            {
                throw new ArgumentException("landingAreaSizeX should be greater than 0");
            }
            if (landingAreaSizeY < 1)
            {
                throw new ArgumentException("landingAreaSizeY should be greater than 0");
            }

            CreateLandingArea(landingAreaSizeX, landingAreaSizeY);

            var endofLandingPlatform = startLandingPlatform + new Coordinate(landingPlatformSizeY - 1, landingPlatformSizeX - 1);

            if (!Area.Any(x => x.Coordinate == startLandingPlatform) ||
                !Area.Any(x => x.Coordinate == endofLandingPlatform))
            {
                throw new ArgumentException("Landing Platorm Area is not valid");
            }

            CreateLandingPlatform(landingPlatformSizeX, landingPlatformSizeY, startLandingPlatform);
        }

        private void CreateLandingPlatform(uint landingAreaSizeX, uint landingAreaSizeY, Coordinate startLandingPlatform)
        {
            StartLandingPlatform = startLandingPlatform;

            var sizeX = startLandingPlatform.X + landingAreaSizeX - 1;
            var sizeY = startLandingPlatform.Y + landingAreaSizeY - 1;

            for (uint x = startLandingPlatform.X; x <= sizeX; x++)
            {
                for (uint y = startLandingPlatform.Y; y <= sizeY; y++)
                {
                    var landingSquare = Area.Single(area => area.Coordinate == new Coordinate(y, x));
                    landingSquare.SetLandingCondition(LandingCondition.OkForLanding);
                }
            }
        }

        private void CreateLandingArea(uint landingAreaSizeX, uint landingAreaSizeY)
        {
            Area = new List<LandingSquare>();

            for (uint x = 1; x <= landingAreaSizeX; x++)
            {
                for (uint y = 1; y <= landingAreaSizeY; y++)
                {
                    Area.Add(new LandingSquare(y, x, LandingCondition.OutOfPlatform));
                }
            }
        }

        public LandingCondition AskForPosition(uint x, uint y)
        {
            var position = new Coordinate(y, x);

            var landingAreaPosition = position + (StartLandingPlatform - new Coordinate(1, 1));

            var proposalLandingPosition = Area.SingleOrDefault(x => x.Coordinate == landingAreaPosition);

            if (proposalLandingPosition == null)
            {
                return LandingCondition.OutOfPlatform;
            }

            if (proposalLandingPosition.LandingCondition == LandingCondition.OutOfPlatform)
            {
                return LandingCondition.OutOfPlatform;
            }

            var returnObject = proposalLandingPosition.LandingCondition;

            CleanCrashPositions();

            SetCrashPositions(landingAreaPosition);

            return returnObject;
        }

        private void SetCrashPositions(Coordinate coordinate)
        {
            SetCrashPosition(coordinate);
            SetCrashPosition(coordinate + new Coordinate(0, 1));
            SetCrashPosition(coordinate - new Coordinate(0, 1));
            SetCrashPosition(coordinate + new Coordinate(1, 0));
            SetCrashPosition(coordinate - new Coordinate(1, 0));
            SetCrashPosition(coordinate + new Coordinate(1, 1));
            SetCrashPosition(coordinate - new Coordinate(1, 1));
            SetCrashPosition((coordinate - new Coordinate(1, 0)) + new Coordinate(0, 1));
            SetCrashPosition((coordinate - new Coordinate(1, 0)) - new Coordinate(0, 1));
        }

        private void SetCrashPosition(Coordinate coordinate)
        {
            var crashPosition = Area.SingleOrDefault(x => x.Coordinate == coordinate);
            if (crashPosition != null && crashPosition.LandingCondition == LandingCondition.OkForLanding)
            {
                crashPosition.SetLandingCondition(LandingCondition.Clash);
            }
        }

        private void CleanCrashPositions()
        {
            Area.Where(x => x.LandingCondition == LandingCondition.Clash).ToList()
                .ForEach(x => x.SetLandingCondition(LandingCondition.OkForLanding));
        }
    }
}
