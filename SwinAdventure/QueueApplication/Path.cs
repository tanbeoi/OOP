using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{   
    public enum Direction
    {
        North, NorthEast, East, SouthEast, South, SouthWest, West, NorthWest, Up, Down
    }
    public class Path : IdentifiableObject
    {
        private Direction Direction;
        private Location Destination;
        private string Description;

        public bool IsLocked { get; set; } = false;

        public Path(Direction direction, Location destination, string description) : base(new string[] { direction.ToString()})
        {
            Direction = direction;
            Destination = destination;
            Description = description;
        }
        
        public Location DestinationLocation
        {
            get
            {
                return Destination;
            }
        }

        public string FullDescription
        {
            get
            {
                return Description;
            }
        }

        public Direction PathDirection
        {
            get
            {
                return Direction;
            }
        }

        public bool CanMove()
        {
            return !IsLocked;
        }
    }
}
