using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory = new Inventory();
        private Location _location;

        public Player(string name, string desc) : base(new string[] { "me", "inventory" }, name, desc)
        {

        }

        public string Move (Direction direction)
        {
            Path? path = Location.GetPath(direction);

            if (path == null)
            {
                return "There is no path in that direction";
            }
            else
            {
                Location = path.DestinationLocation;
                return "You head " + path.PathDirection.ToString() + "\n" + path.FullDescription + "\nYou have arrived in a small " + path.DestinationLocation.Name;
            }
        }

        public Location Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
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
            else if (Inventory.HasItem(id))
            {
                return Inventory.Fetch(id);
            }
            else if (Location != null)
            {
                    return Location.Locate(id);   
            }
            else
            {
                return null;
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

        Inventory IHaveInventory.Inventory
        {
            get
            {
                return Inventory;
            }
        }
    }
}