using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class PickupCommand : Command
    {
        public PickupCommand() : base(new string[] { "pickup", "take" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length != 2 && text.Length != 4)
            {
                return "I don't know how to pickup like that";
            }
            else if (text[0].ToLower() != "pickup" && text[0].ToLower() != "take")
            {
                return "Error in pickup input";
            }
            else if (text.Length == 2)
            {
                Item? thing = PickUpIn(text[1], p);
                if (thing == null)
                {
                    return "I can't find the " + text[1];
                }
                else if (p.Inventory.HasItem(thing.Name))
                {
                    return "You already have the " + thing.Name;
                } else
                {
                    p.Inventory.Put((Item)thing);
                    p.Location.Inventory.Take((Item)thing);
                    return "You have picked up the " + thing.Name;
                }
            }
            else if (text.Length == 4)
            {
                if (text[2].ToLower() != "from")
                {
                    return "Where is this item?";

                } else if (text[3].ToLower() == "room")
                {
                    IHaveInventory room = p.Location;
                    Item? thing = PickUpIn(text[1], room);

                    if (thing == null)
                    {
                        return "I can't find the " + text[1] + " in the room";
                    }
                    else if (p.Inventory.HasItem(thing.Name))
                    {
                        return "You already have the " + thing.Name;
                    }
                    else
                    {
                        p.Inventory.Put((Item)thing);
                        p.Location.Inventory.Take((Item)thing);
                        return "You have picked up the " + thing.Name + " from the room";
                    }
                } else
                {
                    IHaveInventory? container = FetchContainer(p, text[3]) as IHaveInventory;

                    // Check if container is null after the cast
                    if (container == null)
                    {
                        return "I can't find the " + text[4];
                    }
                    else
                    {
                        // Look at the thing in the container
                        Item? thing = PickUpIn(text[1], container);
                        if (thing == null)
                        {
                            return "I can't find the " + text[1] + " in the " + container.Name;
                        }
                        else if (p.Inventory.HasItem(thing.Name))
                        {
                            return "You already have the " + thing.Name;
                        }
                        else
                        {
                            p.Inventory.Put((Item)thing);
                            container.Inventory.Take((Item)thing);
                            return "You have picked up the " + thing.Name + " from the " + container.Name;
                        }
                    }
                }
            }
            //default return
            return "I don't know how to pickup like that";
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

        public Item? PickUpIn(string thingId, IHaveInventory containerId)
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
