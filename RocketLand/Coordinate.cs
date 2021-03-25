using System;

namespace RocketLand
{
    public class Coordinate : IEquatable<Coordinate>
    {
        public uint Y { get; set; }
        public uint X { get; set; }

        public Coordinate(uint y, uint x)
        {
            Y = y;
            X = x;
        }

        public bool Equals(Coordinate other)
        {
            if (Y == other.Y && X == other.X) return true;
            return false;
        }

        public static Coordinate operator +(Coordinate obj1, Coordinate obj2)
        {
            return new Coordinate(obj1.Y + obj2.Y, obj1.X + obj2.X);
        }

        public static Coordinate operator -(Coordinate obj1, Coordinate obj2)
        {
            return new Coordinate(obj1.Y - obj2.Y, obj1.X - obj2.X);
        }

        public static bool operator ==(Coordinate obj1, Coordinate obj2)
        {
            if (ReferenceEquals(obj1, obj2))
            {
                return true;
            }
            if (ReferenceEquals(obj1, null))
            {
                return false;
            }
            if (ReferenceEquals(obj2, null))
            {
                return false;
            }

            return obj1.Equals(obj2);
        }

        public static bool operator !=(Coordinate obj1, Coordinate obj2)
        {
            return !(obj1 == obj2);
        }

        public override int GetHashCode()
        {
            return (Y, X).GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Coordinate);
        }
    }
}
