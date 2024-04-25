using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemTest
{
    internal class Batch : Thing
    {
        List<Thing> _things = new List<Thing>();

        public Batch(string number, string name) : base(number, name)
        {
        }

        public void Add(Thing thing)
        {
            _things.Add(thing);
        }

        public override void Print()
        {
            Console.WriteLine($"Batch sale: #{Number}, {Name}");
            if (_things.Count == 0)
            {
                Console.WriteLine("Empty order.");
            } else {
                foreach (var thing in _things)
                {
                    thing.Print();
                }
                Console.WriteLine($"Total: ${Total()}");
            }
        }

        public override decimal Total()
        {
            decimal total = 0;
            foreach (var thing in _things)
            {
                total += thing.Total();
            }
            return total;
        }


    }
}
