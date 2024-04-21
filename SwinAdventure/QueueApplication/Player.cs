using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SwinAdventure.LookCommand;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory = new Inventory();

        public Player(string name, string desc) : base(new string[] { "me", "inventory" }, name, desc)
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
            else
            {
                return _inventory.Fetch(id);
            }
        }

        public override string FullDescription
        {
            get
            {
                return "You are " + Name + " " + Description + "\nYou are carrying:\n" + _inventory.ItemList;
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