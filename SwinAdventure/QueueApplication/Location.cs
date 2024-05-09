using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static SwinAdventure.LookCommand;

namespace SwinAdventure
{
    public class Location : IdentifiableObject, IHaveInventory
    {
        private string _description;
        private Inventory _inventory = new Inventory();

        public Location(string[] ids, string description) : base(ids)
        {
            _description = description;
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }
        public string Description
        {
            get
            {
                return _description;
            }
        }

        public GameObject? Locate(string id)
        {
                return _inventory.Fetch(id);
        }

        public string FullDescription
        {
            get
            {
                return "You are in a small" + FirstId + "\n" + Description + "\n" + "In this room you can see:\n" + _inventory.ItemList;
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
                return FirstId;
            }
        }
    }
}
