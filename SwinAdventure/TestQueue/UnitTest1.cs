using SwinAdventure;

namespace TestQueue
{
    public class Tests
    {
        Item item1 = new Item(new string[] { "sword" }, "sword", "a sword");
        Item item2 = new Item(new string[] { "shield" }, "shield", "a shield");
        Item item3 = new Item(new string[] { "shiba" }, "shiba", "a shiba");
        Item item4 = new Item(new string[] { "gem" }, "gem", "a gem");

        [SetUp]
        public void Setup()
        {
        }

        // Test the Item class
        [Test]
        public void ItemIdentifiable()
        {
            Assert.IsTrue(item1.AreYou("sword"));
        }

        [Test]
        public void ShortDescription()
        {
            Assert.That(item1.ShortDescription, Is.EqualTo("a sword (sword)"));
        }

        [Test]
        public void FullDescription()
        {
            Assert.That(item1.FullDescription, Is.EqualTo("a sword"));
        }

        // Test the Inventory class
        [Test]
        public void FindItem()
        {
            Inventory inventory = new Inventory();
            inventory.Put(item1);

            Assert.IsTrue(inventory.HasItem("sword"));
        }

        [Test]
        public void NoItem()
        {
            Inventory inventory = new Inventory();
            Assert.IsFalse(inventory.HasItem("sword"));
        }

        [Test]
        public void FetchItem()
        {
            Inventory inventory = new Inventory();
            inventory.Put(item1);

            Assert.That(item1, Is.EqualTo(inventory.Fetch("sword")));
            Assert.IsTrue(inventory.HasItem("sword"));
        }

        [Test]
        public void TakeItem()
        {
            Inventory inventory = new Inventory();
            inventory.Put(item1);

            Assert.That(item1, Is.EqualTo(inventory.Take("sword")));
            Assert.IsFalse(inventory.HasItem("sword"));
        }

        [Test]
        public void ItemList()
        {

            Inventory inventory = new Inventory();
            inventory.Put(item1);
            inventory.Put(item2);

            //the list string below is the expected output, consisting of every item in the following format: name ( first id)
            Assert.That(inventory.ItemList, Is.EqualTo("\t a sword (sword)\n\t a shield (shield)\n"));

        }

        // Test the Player class
        [Test]
        public void PlayerIdentifiable()
        {
            Player player = new Player("Tan", "A player");

            Assert.IsTrue(player.AreYou("me"));
            Assert.IsTrue(player.AreYou("inventory"));
        }


        [Test]
        public void PlayerLocate()
        {
            Player player = new Player("Tan", "A player");
            player.Inventory.Put(item1);

            Assert.That(item1, Is.EqualTo(player.Locate("sword")));
        }

        [Test]
        public void PlayerLocateItself()
        {
            Player player = new Player("Tan", "A player");
            Assert.That(player, Is.EqualTo(player.Locate("me")));
            Assert.That(player, Is.EqualTo(player.Locate("inventory")));
        }

        [Test]
        public void PlayerLocateNothing()
        {
            Player player = new Player("Tan", "A player");
            Assert.That(player.Locate("sword"), Is.Null);
        }

        [Test]
        public void PlayerFullDescription()
        {
            Player player = new Player("Tan", "A player");
            player.Inventory.Put(item1);
            player.Inventory.Put(item2);

            //the list string below is the expected output, consisting of every item in the following format: name ( first id)
            Assert.That(player.FullDescription, Is.EqualTo("You are Tan A player\nYou are carrying:\n\t a sword (sword)\n\t a shield (shield)\n"));
        }

        //Test the Bag class
        [Test]
        public void BagLocate()
        {
            Bag backpack = new Bag(new string[] { "backpack" }, "backpack", "a backpack");
            backpack.Inventory.Put(item1);
            backpack.Inventory.Put(item2);
            backpack.Inventory.Put(item3);

            //ask to return item and item stays in backpack
            Assert.That(item3, Is.EqualTo(backpack.Locate("shiba")));
            Assert.IsTrue(backpack.Inventory.HasItem("shiba"));

        }

        [Test]
        public void BagLocatesItself()
        {
            Bag backpack = new Bag(new string[] { "backpack" }, "backpack", "a backpack");
            Assert.That(backpack, Is.EqualTo(backpack.Locate("backpack")));
        }

        [Test]
        public void BagLocateNothing()
        {
            Bag backpack = new Bag(new string[] { "backpack" }, "backpack", "a backpack");
            Assert.That(backpack.Locate("sword"), Is.Null);
        }

        [Test]
        public void BagFullDescription()
        {
            Bag backpack = new Bag(new string[] { "backpack" }, "backpack", "A backpack");
            backpack.Inventory.Put(item1);
            backpack.Inventory.Put(item2);
            backpack.Inventory.Put(item3);

            //the list string below is the expected output, consisting of every item in the following format: name ( first id)
            Assert.That(backpack.FullDescription, Is.EqualTo("A backpack\nYou look in the backpack and see:\n\t a sword (sword)\n\t a shield (shield)\n\t a shiba (shiba)\n"));
        }

        [Test]
        public void BagInBag()
        {
            Bag backpack = new Bag(new string[] { "backpack" }, "backpack", "a backpack");
            Bag satchel = new Bag(new string[] { "satchel" }, "satchel", "a satchel");

            backpack.Inventory.Put(satchel);

            Assert.That(satchel, Is.EqualTo(backpack.Locate("satchel")));
        }

        //Test for the LookCommand class
        [Test]
        public void LookAtMe()
        {
            Player player = new Player("Tan", "A player");
            player.Inventory.Put(item1);
            player.Inventory.Put(item2);
            LookCommand LookCommand = new LookCommand();

            string expectedDescription = "You are Tan A player\nYou are carrying:\n\t a sword (sword)\n\t a shield (shield)\n";
            string testDescription = LookCommand.Execute(player, new string[] { "look", "at", "me" });
            Assert.That(testDescription, Is.EqualTo(expectedDescription));

        }

        [Test]
        public void LookAtGem()
        {
            Player player = new Player("Tan", "A player");
            player.Inventory.Put(item4);
            LookCommand LookCommand = new LookCommand();

            string expectedDescription = "a gem";
            string testDescription = LookCommand.Execute(player, new string[] { "look", "at", "gem" });
            Assert.That(testDescription, Is.EqualTo(expectedDescription));
        }

        [Test]
        public void LookAtUnk()
        {
            Player player = new Player("Tan", "A player");
            LookCommand LookCommand = new LookCommand();

            string expectedDescription = "I can't find the gem in the Tan";
            string testDescription = LookCommand.Execute(player, new string[] { "look", "at", "gem" });
            Assert.That(testDescription, Is.EqualTo(expectedDescription));
        }

        [Test]
        public void LookAtGemInBag()
        {
            Player player = new Player("Tan", "A player");
            Bag backpack = new Bag(new string[] { "backpack" }, "backpack", "a backpack");
            player.Inventory.Put(backpack);
            backpack.Inventory.Put(item4);
            LookCommand LookCommand = new LookCommand();

            string expectedDescription = "a gem";
            string testDescription = LookCommand.Execute(player, new string[] { "look", "at", "gem", "in", "backpack" });
            Assert.That(testDescription, Is.EqualTo(expectedDescription));
        }

        [Test]
        public void LookAtBag()
        {
            Player player = new Player("Tan", "A player");
            Bag backpack = new Bag(new string[] { "backpack" }, "backpack", "A backpack");
            backpack.Inventory.Put(item1);
            backpack.Inventory.Put(item2);
            player.Inventory.Put(backpack);
            LookCommand LookCommand = new LookCommand();

            string expectedDescription = "A backpack\nYou look in the backpack and see:\n\t a sword (sword)\n\t a shield (shield)\n";
            string testDescription = LookCommand.Execute(player, new string[] { "look", "at", "backpack" });
            Assert.That(testDescription, Is.EqualTo(expectedDescription));
        }

        [Test]
        public void LookAtGemInNoBag()
        {
            Player player = new Player("Tan", "A player");
            LookCommand LookCommand = new LookCommand();

            string expectedDescription = "I can't find the backpack";
            string testDescription = LookCommand.Execute(player, new string[] { "look", "at", "gem", "in", "backpack" });
            Assert.That(testDescription, Is.EqualTo(expectedDescription));
        }

        [Test]
        public void LookAtNoGemInBag()
        {
            Player player = new Player("Tan", "A player");
            Bag backpack = new Bag(new string[] { "backpack" }, "backpack", "a backpack");
            player.Inventory.Put(backpack);
            LookCommand LookCommand = new LookCommand();

            string expectedDescription = "I can't find the gem in the backpack";
            string testDescription = LookCommand.Execute(player, new string[] { "look", "at", "gem", "in", "backpack" });
            Assert.That(testDescription, Is.EqualTo(expectedDescription));
        }

        [Test]
        public void InvalidLookCommand()
        {
            Player player = new Player("Tan", "A player");
            LookCommand LookCommand = new LookCommand();

            string expectedDescription = "I don't know how to look like that";

            //only 2 arguments
            string testDescription = LookCommand.Execute(player, new string[] { "look", "at" });
            Assert.That(testDescription, Is.EqualTo(expectedDescription));

            //4 arguments
            string testDescription2 = LookCommand.Execute(player, new string[] { "look", "at", "gem", "in" });
            Assert.That(testDescription2, Is.EqualTo(expectedDescription));

            //5 arguments but the 4th argument is not "in"
            string testDescription3 = LookCommand.Execute(player, new string[] { "look", "at", "a", "at", "b" });
            string expectedDescription2 = "What do you want to look in?";
            Assert.That(testDescription3, Is.EqualTo(expectedDescription2));

            //5 arguments but the 2nd argument is not "at"
            string testDescription4 = LookCommand.Execute(player, new string[] { "look", "in", "a", "in", "b" });
            string expectedDescription3 = "What do you want to look at?";
            Assert.That(testDescription4, Is.EqualTo(expectedDescription3));
        }

        //Test for Location
        [Test]
        public void LookInPlayerLocationForItem()
        {
            Player player = new Player("Tan", "A player");
            player.Location = new Location(new string[] { "Garden" }, "A garden filled with butterflies");
            player.Location.Inventory.Put(item1);

            LookCommand LookCommand = new LookCommand();
            string textDescription = LookCommand.Execute(player, new string[] { "look", "at", "sword" });
            string expectedDescription = "a sword";
            Assert.That(textDescription, Is.EqualTo(expectedDescription));
        }

        [Test]
        public void LookInPlayerLocationForBag()
        {
            Player player = new Player("Tan", "A player");
            player.Location = new Location(new string[] { "Garden" }, "A garden filled with butterflies");

            Bag backpack = new Bag(new string[] { "backpack" }, "backpack", "a backpack");
            backpack.Inventory.Put(item1);

            player.Location.Inventory.Put(backpack);
            

            LookCommand LookCommand = new LookCommand();
            string textDescription = LookCommand.Execute(player, new string[] { "look", "at", "sword", "in", "backpack" });
            string expectedDescription = "a sword";
            Assert.That(textDescription, Is.EqualTo(expectedDescription));
        }

        [Test]
        public void LocationIdentifyItself()
        {
            Location location = new Location(new string[] { "Garden" }, "A garden filled with butterflies");
            Assert.IsTrue(location.AreYou("Garden"));
        }

        [Test]
        public void PlayerLocateItemInLocation()
        {
            Player player = new Player("Tan", "A player");
            player.Location = new Location(new string[] { "Garden" }, "A garden filled with butterflies");
            player.Location.Inventory.Put(item1);

            Assert.That(item1, Is.EqualTo(player.Location.Locate("sword")));
        }
    }
}