namespace _3._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();
            
            for (int i = 0; i < 90000; i++)
            {
                
                clock.Tick();
                if (i % 86400 == 0)
                {
                    clock.Reset();
                }
                clock.Display();
                
            }
        }
    }
}
