using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SwinAdventure.LookCommand;

namespace SwinAdventure
{
    public class Bag : Item, IHaveInventory
    {
        private Inventory _inventory = new Inventory();

        public Bag(string[] idents, string name, string desc) : base(idents, name, desc)
        {
        }

        public Item? Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
           else 
                return _inventory.Fetch(id);
        }

        public override string FullDescription
        {
            get
            {
                return "In the " + Name + " you can see:\n" + _inventory.ItemList;
            }
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
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
