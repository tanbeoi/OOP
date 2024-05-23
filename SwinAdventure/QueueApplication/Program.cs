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
            

            //Home - Starting Location of the player
            Location home = new Location(new string[] { "home" }, "Home", "Your cozy home.");
            player.Location = home;
            
            Item shiba = new Item(new string[] { "shiba", "dog" }, "Shiba", "Your cute companion");
            Item nitendo = new Item(new string[] { "switch", "nitendo" }, "Nitendo Switch", "A gaming console");
            home.Inventory.Put(shiba);
            home.Inventory.Put(nitendo);
   

            //Park - North of Home
            Location park = new Location(new string[] { "park" }, "Park", "A beautiful park");
            home.AddPath(new Path(Direction.North, "North", "A path to the park", park));
            park.AddPath(new Path(Direction.South, "South", "A path to home", home));
            Item pinkPlant = new Item(new string[] { "plant", "pink" }, "Pink Plant", "A pink plant that seems to be poisonous");
            Item shovel = new Item(new string[] { "shovel" }, "Shovel", "A rusted shovel");
            park.Inventory.Put(pinkPlant);
            park.Inventory.Put(shovel);
      

            //Cave - East of Park
            Location dungeon = new Location(new string[] { "dungeon" }, "Dungeon", "A dark and scary dungeon");
            park.AddPath(new Path(Direction.East, "East", "A path to the dungeon", dungeon));
            dungeon.AddPath(new Path(Direction.West, "West", "A path to the park", park));
            Item sword = new Item(new string[] { "sword" }, "Sword", "A shiny sword");
            Item staff = new Item(new string[] { "staff", "stick" }, "Staff", "A wooden (magical?) staff");
            Bag chest = new Bag(new string[] { "chest" }, "Chest", "A wooden chest");
            chest.Inventory.Put(sword);
            chest.Inventory.Put(staff);
            dungeon.Inventory.Put(chest);

       
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
