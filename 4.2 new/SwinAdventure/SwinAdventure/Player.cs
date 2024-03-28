using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Player : GameObject
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
                return "You are " + Name + " " + FullDescription + "\nYou are carrying:\n" + _inventory.ItemList;
            }
        }
    }
}