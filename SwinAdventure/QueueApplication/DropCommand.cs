using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class DropCommand : Command
    {
        public DropCommand() : base(new string[] { "put", "drop" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length != 2 && text.Length != 4)
            {
                return "I don't know how to drop like that";
            }
            else if (text[0].ToLower() != "drop" && text[0].ToLower() != "put")
            {
                return "Error in drop input";
            }
            else if (text.Length == 2)
            {
                Item? thing = DropIn(text[1], p);
                if (thing == null)
                {
                    return "I can't find the " + text[1];
                }
                else
                {
                    p.Inventory.Take((Item)thing);
                    p.Location.Inventory.Put(thing);
                    return "You have dropped the " + thing.Name;
                }
            }
            else if (text.Length == 4)
            {
                if (text[2].ToLower() != "in")
                {
                    return "Where do you want to drop this item?";

                }
                else if (text[3].ToLower() == "room")
                {
                    Item? thing = DropIn(text[1], p);
                    if (thing == null)
                    {
                        return "I can't find the " + text[1] + "to drop";
                    }
                    else
                    {
                        p.Inventory.Take((Item)thing);
                        p.Location.Inventory.Put(thing);
                        return "You have dropped the " + thing.Name + " in the room";
     
                    }
                }
                else
                {
                    IHaveInventory? container = FetchContainer(p, text[3]) as IHaveInventory;

                    // Check if container is null after the cast
                    if (container == null)
                    {
                        return "I can't find the " + text[4];
                    }
                    else
                    {
                        Item? thing = DropIn(text[1], p);
                        if (thing == null)
                        {
                            return "I can't find the " + text[1] + "to drop";
                        }
                        else
                        {
                            p.Inventory.Take((Item)thing);
                            container.Inventory.Put(thing);
                            return "You have dropped the " + thing.Name + " in the " + container.Name;
                        }

                    }
                }
            }
            //default return
            return "I don't know how to drop like that";
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

        public Item? DropIn(string thingId, IHaveInventory containerId)
        {
            Item? thing = (Item?)containerId.Locate(thingId);

            if (thing == null)
            {
                return null;
            }
            else
            {
                return thing;
            }
        }
    }
}

