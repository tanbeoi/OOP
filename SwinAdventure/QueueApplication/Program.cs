namespace SwinAdventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the player's name:");
            string? playerName = Console.ReadLine();

            Console.WriteLine("Enter the player's description:");
            string? playerDescription = Console.ReadLine();

            Player player = new Player(playerName, playerDescription);
            
            Item shiba = new Item(new string[] { "shiba", "dog" }, "Shiba", "A cute shiba inu");
            Item nitendo = new Item(new string[] { "switch", "nitendo" }, "Nitendo Switch", "A gaming console");

            player.Inventory.Put(shiba);
            player.Inventory.Put(nitendo);

            Bag container = new Bag(new string[] { "bag", "container" }, "Bag", "A metal container");
            player.Inventory.Put(container);

            Item staff = new Item(new string[] { "staff", "stick" }, "Staff", "A wooden (magical?) staff");
            Item glasses = new Item(new string[] { "glasses", "spectacles" }, "Glasses", "A pair of glasses");

            container.Inventory.Put(staff);
            container.Inventory.Put(glasses);

            while (true)
            {
                Console.WriteLine("Enter a command:");
                string? command = Console.ReadLine();
                // Split the command into an array of words contained within the command
                string[] convertedCommand = command.Split(' ');
                LookCommand lookCommand = new LookCommand();

                Console.WriteLine(lookCommand.Execute(player, convertedCommand));

            }
        }
    }
}
