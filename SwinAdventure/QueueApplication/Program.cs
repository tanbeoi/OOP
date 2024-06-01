namespace SwinAdventure
{
    internal class Program
    {
        static string GetNonEmptyInput(string prompt)
        {
            string? input;
            do
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine();

                // Trim the input to remove any leading or trailing white spaces
                input = input?.TrimEnd();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input cannot be empty. Please enter a valid value.");
                }
            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }

        static void Main(string[] args)
        {
            //SET UP PLAYER
            string playerName = GetNonEmptyInput("Enter the player's name:");
            string playerDescription = GetNonEmptyInput("Enter the player's description:");
            Player player = new Player(playerName, playerDescription);


            //SET UP EACH LOCATIONS
            

            //Home - Starting Location of the player, South of Park, West of AbandonedHighschool, East of Museum, North of Supermarket
            Location home = new Location(new string[] { "home" }, "Home", "Your cozy home.");
            player.Location = home;
            
            Item shiba = new Item(new string[] { "shiba", "dog" }, "Shiba", "Your cute companion");
            Item nitendo = new Item(new string[] { "switch", "nitendo" }, "Nitendo Switch", "A gaming console");
            home.Inventory.Put(shiba);
            home.Inventory.Put(nitendo);
   

            //Park - North of Home, West of Dungeon
            Location park = new Location(new string[] { "park" }, "Park", "A beautiful park");
            home.AddPath(new Path(Direction.North, "North", "A path to the park", park));
            park.AddPath(new Path(Direction.South, "South", "A path to home", home));
            Item pinkPlant = new Item(new string[] { "plant", "pink" }, "Pink Plant", "A pink plant that seems to be poisonous");
            Item shovel = new Item(new string[] { "shovel" }, "Shovel", "A rusted shovel");
            park.Inventory.Put(pinkPlant);
            park.Inventory.Put(shovel);
      

            //Dungeon - East of Park, North of AbandonedHighschool
            Location dungeon = new Location(new string[] { "dungeon" }, "Dungeon", "A dark and scary dungeon");
            park.AddPath(new Path(Direction.East, "East", "A path to the dungeon", dungeon));
            dungeon.AddPath(new Path(Direction.West, "West", "A path to the park", park));
            Item sword = new Item(new string[] { "sword" }, "Sword", "A shiny sword");
            Item staff = new Item(new string[] { "staff", "stick" }, "Staff", "A wooden (magical?) staff");
            Bag chest = new Bag(new string[] { "chest" }, "Chest", "A wooden chest");
            chest.Inventory.Put(sword);
            chest.Inventory.Put(staff);
            dungeon.Inventory.Put(chest);

            //AbandonedHighschool - South of Dungeon, West of Home, South of Dungeon 
            Location abandonedHighschool = new Location(new string[] { "abandoned highschool" }, "Abandoned Highschool", "An abandoned highschool");
            dungeon.AddPath(new Path(Direction.South, "South", "You pass through trees and trees and trees.", abandonedHighschool));
            abandonedHighschool.AddPath(new Path(Direction.North, "North", "You pass through trees and trees and trees.", dungeon));
            home.AddPath(new Path(Direction.East, "East", "You pass through an empty wasteland.", abandonedHighschool));
            abandonedHighschool.AddPath(new Path(Direction.West, "West", "You pass through an empty wasteland.", home));
            Item pen = new Item(new string[] { "pen" }, "Pen", "A pen");
            Item oldUniform = new Item(new string[] { "uniform" }, "Old Uniform", "An old school uniform");
            Item gold = new Item(new string[] { "gold" }, "Gold", "A shiny gold ingot");
            Bag mysteryBox = new Bag(new string[] { "mysteryBox" }, "Mystery Box", "A mysterious box");
            mysteryBox.Inventory.Put(gold);
            abandonedHighschool.Inventory.Put(pen);
            abandonedHighschool.Inventory.Put(oldUniform);
            abandonedHighschool.Inventory.Put(mysteryBox);

       
            //Nuclear Plant - SouthEast of AbandonedHighschool
            Location nuclearPlant = new Location(new string[] { "nuclear plant" }, "Nuclear Plant", "An old and abandoned nuclear plant");
            abandonedHighschool.AddPath(new Path(Direction.SouthEast, "SouthEast", "You pass through an ongoing battlefield.", nuclearPlant));
            nuclearPlant.AddPath(new Path(Direction.NorthWest, "NorthWest", "You pass through an ongoing battlefield.", abandonedHighschool));
            Item uranium = new Item(new string[] { "uranium" }, "Uranium", "A radioactive material");
            Item gasMask = new Item(new string[] { "gasMask" }, "Gas Mask", "A gas mask");
            nuclearPlant.Inventory.Put(uranium);
            nuclearPlant.Inventory.Put(gasMask);

            //Supermarket - South of Home, East of AmusementPark
            Location supermarket = new Location(new string[] { "supermarket" }, "Supermarket", "An abandoned supermarket");
            home.AddPath(new Path(Direction.South, "South", "You pass through a road with many cars, but nobody's in them.", supermarket));
            supermarket.AddPath(new Path(Direction.North, "North", "You pass through a road with many cars, but nobody's in them.", home));
            Bag shoppingBag = new Bag(new string[] { "shoppingBag" }, "Shopping Bag", "A shopping bag");
            Item apple = new Item(new string[] { "apple" }, "Apple", "A fresh apple");
            Item oreo = new Item(new string[] { "oreo" }, "Oreo", "A pack of oreo");
            shoppingBag.Inventory.Put(apple);
            shoppingBag.Inventory.Put(oreo);
            supermarket.Inventory.Put(shoppingBag);

            //Museum - West of Home, North of AmusementPark 
            Location museum = new Location(new string[] { "museum" }, "Museum", "An old museum");
            home.AddPath(new Path(Direction.West, "West", "You pass through an underground tunnel. When you come out, the sky has turned dark.", museum));
            museum.AddPath(new Path(Direction.East, "East", "You pass through an underground tunnel. When you come out, it's daylight.", home));
            Item statue = new Item(new string[] { "statue" }, "Statue", "A statue of a famous person. You feel like it's looking at you.");
            Item painting = new Item(new string[] { "painting" }, "Painting", "A painting of a beautiful landscape");
            Bag crate = new Bag(new string[] { "crate" }, "Crate", "A metal crate");
            crate.Inventory.Put(painting);

            //Amusement Park - South of Museum, West of Supermarket
            Location amusementPark = new Location(new string[] { "amusement park" }, "Amusement Park", "An abandoned amusement park");
            museum.AddPath(new Path(Direction.South, "South", "You pass through a neverending grass field.", amusementPark));
            amusementPark.AddPath(new Path(Direction.North, "North", "You pass through a bridge that looks like Golden Gate Bridge.", museum));
            supermarket.AddPath(new Path(Direction.West, "West", "You pass through a road with many cars, but nobody's in them.", amusementPark));
            amusementPark.AddPath(new Path(Direction.East, "East", "You pass through a neverending grass field.", supermarket));
            Item ticket = new Item(new string[] { "ticket" }, "Ticket", "A ticket to the amusement park");
            Item cottonCandy = new Item(new string[] { "cottonCandy" }, "Cotton Candy", "A cotton candy");
            Bag mysteriousBag = new Bag(new string[] { "mysteriousBag" }, "Mysterious Bag", "A mysterious bag");
            Item clownMask = new Item(new string[] { "clownMask" }, "Clown Mask", "A clown mask with blood stains");
            mysteriousBag.Inventory.Put(clownMask);
            amusementPark.Inventory.Put(ticket);
            amusementPark.Inventory.Put(cottonCandy);
            amusementPark.Inventory.Put(mysteriousBag);



            //PROGRAM LOOP
            while (true)
            {
                Console.WriteLine("Enter a command:");
                string? command = Console.ReadLine();
            
                CommandProcessor commandProcessor = new CommandProcessor();

                if (string.IsNullOrWhiteSpace(command))
                {
                    Console.WriteLine("Please enter a command");
                }
                else if (command.ToLower() == "exit")
                {
                    break;
                }
                else if (command.ToLower() == "inv" || command.ToLower() == "inventory")
                {
                    Console.WriteLine("\n" + player.FullDescription + "\n");
                }
                else
                {
                    Console.WriteLine("\n" + commandProcessor.ExecuteCommand(player, command) + "\n");
                }
            }
        }
    }
}
