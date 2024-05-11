using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length != 3 && text.Length != 5)
            {
                return "I don't know how to look like that";
            }
            else if (text[0] != "look")
            {
                return "Error in look input";
            }
            else if (text[1] != "at")
            {
                return "What do you want to look at?";
            }
            else if (text.Length == 3)
            {
                return LookAtIn(text[2], p);
            }
            else if (text.Length == 5)
            {
                if (text[3] != "in")
                {
                    return "What do you want to look in?";
                }
                else
                {
                    IHaveInventory container = FetchContainer(p, text[4]) as IHaveInventory;

                    // Check if container is null after the cast
                    if (container == null)
                    {
                        return "I can't find the " + text[4];
                    }
                    else
                    {
                        // Look at the thing in the container
                        return LookAtIn(text[2], container);
                    }
                }
            }
            //default return
            return "I don't know how to look like that";
        }

        public IHaveInventory? FetchContainer(Player p, string containerId)
        {
            if (p.Locate(containerId) != null)
            {
                return p.Locate(containerId) as IHaveInventory;
            }
            else
            {
                return null;
            }
        }

        public string LookAtIn(string thingId, IHaveInventory containerId)
        {
            GameObject? thing = containerId.Locate(thingId);

            if (thing == null)
            {
                return "I can't find the " + thingId + " in the " + containerId.Name;
            }
            else
            {
                return thing.FullDescription;
            }
        }

        public interface IHaveInventory
        {
            GameObject? Locate(string id);

            string Name { get; }
        }


    }
}
