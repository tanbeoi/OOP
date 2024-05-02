using _3._1;


namespace TestProject2
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        Clock clock = new Clock();

        [Test]
        public void Test1()
        {
            clock.Reset();
            Assert.That(clock.Display, Is.EqualTo("00: 00: 00"));
        }

        [Test]
        public void Test2()
        {
            clock.Reset();
            clock.Tick();
            Assert.That(clock.Display, Is.EqualTo("00: 00: 01"));
        }

        [Test]
        public void Test3()
        {
            clock.Reset();
            for (int i = 0; i < 60; i++)
            {
                clock.Tick();
            }
            Assert.That(clock.Display, Is.EqualTo("00: 01: 00"));
        }

        [Test]
        public void Test4()
        {
            clock.Reset();
            for (int i = 0; i < 3600; i++)
            {
                clock.Tick();
            }
            Assert.That(clock.Display, Is.EqualTo("01: 00: 00"));
        }

        [Test]
        public void Test5()
        {
            clock.Reset();
            for (int i = 0; i < 86400; i++)
            {
                clock.Tick();
            }
            Assert.That(clock.Display, Is.EqualTo("00: 00: 00"));
        }
    }
}