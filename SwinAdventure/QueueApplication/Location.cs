using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static SwinAdventure.LookCommand;

namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory = new Inventory();

        public Location(string[] ids, string name, string description) : base(ids, name, description)
        {
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        public GameObject? Locate(string id)
        {
            if (AreYou(id))
            {
                   return this;
            }
            return _inventory.Fetch(id);
        }

        public override string FullDescription
        {
            get
            {
                return "You are in a small" + Name + "\n" + Description + "\n" + "In this room you can see:\n" + Inventory.ItemList;
            }
        }

        GameObject? IHaveInventory.Locate(string id)
        {
            return Locate(id);
        }

        string IHaveInventory.Name
        {
            get
            {
                return Name;
            }
        }
    }
}
