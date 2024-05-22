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
    public class Path : GameObject
    {
        private Direction Direction;    
        private Location Destination;

        public bool IsLocked { get; set; } = false;

        public Path(Direction direction, string name, string description, Location destination) : base(new string[] { direction.ToString()}, name, description)
        {
            Direction = direction;
            Destination = destination;
        }
        
        public Location DestinationLocation
        {
            get
            {
                return Destination;
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

        public void Move(Player p)
        {
            p.Location = DestinationLocation;
        }
    }
}
