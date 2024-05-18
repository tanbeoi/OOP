using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    internal class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] { "move, go, head, leave" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length != 2)
            {
                return "I don't know how to move like that";
            }
            else if (text[0].ToLower() != "move" && text[0].ToLower() != "go" && text[0].ToLower() != "head" && text[0].ToLower() != "leave")
            {
                return "Error in move input";
            }
            else if (text[1].ToLower() != "north" && text[1].ToLower() != "south" && text[1].ToLower() != "east" && text[1].ToLower() != "west")
            {
                return "I don't know how to move like that";
            }
            else
            {
                if (text[1].ToLower() == "north" || text[1].ToLower() == "n")
                {
                    return p.Move(Direction.North);
                }
                else if (text[1].ToLower() == "south" || text[1].ToLower() == "s")
                {
                    return p.Move(Direction.South);
                }
                else if (text[1].ToLower() == "east" || text[1].ToLower() == "e")
                {
                    return p.Move(Direction.East);
                }
                else if (text[1].ToLower() == "west" || text[1].ToLower() == "w")
                {
                    return p.Move(Direction.West);

                } else if (text[1].ToLower() == "northeast" || text[1].ToLower() == "ne")
                {
                    return p.Move(Direction.NorthEast);

                } else if (text[1].ToLower() == "northwest" || text[1].ToLower() == "nw")
                {
                    return p.Move(Direction.NorthWest);

                } else if (text[1].ToLower() == "southeast" || text[1].ToLower() == "se")
                {
                    return p.Move(Direction.SouthEast);

                } else if (text[1].ToLower() == "southwest" || text[1].ToLower() == "sw")
                {
                    return p.Move(Direction.SouthWest);

                } else if (text[1].ToLower() == "up")
                {
                    return p.Move(Direction.Up);

                } else if (text[1].ToLower() == "down")
                {
                    return p.Move(Direction.Down);

                } else
                {
                    return "I don't know how to move like that";
                }
            }
        }
    }
}
