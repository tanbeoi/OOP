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
        private List<Path> _paths = new List<Path>();

        public Location(string[] ids, string name, string description) : base(ids, name, description)
        {
        }
        
        public List<Path> Paths
        {
            get
            {
                return _paths;
            }
        }

        public void AddPath(Path path)
        {
            _paths.Add(path);
        }

        public Path? GetPath (Direction Direction)
        {
            foreach (Path path in Paths)
            {
                if (path.AreYou(Direction.ToString()))
                {
                    return path;
                }
            }
            return null;
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

        public string GetExits()
        {
            string exits = "";
            foreach (Path path in _paths)
            {
                exits += path.PathDirection.ToString() + ", ";
            }
            return exits;
        }

        public override string FullDescription
        {
            get
            {
                return "You are in a small" + Name + "\n" + Description + "\n" + "There are exits to the " + GetExits() +  ".\n\n" + "In this room you can see:\n" + Inventory.ItemList;
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
