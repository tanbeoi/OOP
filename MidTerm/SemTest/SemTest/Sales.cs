using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemTest
{
    internal class Sales
    {
        List<Thing> _orders = new List<Thing>();

        public Sales()
        {
        }

        public void Add(Thing order)
        {
            _orders.Add(order);
        }

        public void Print()
        {
            decimal total = 0;
            foreach (var order in _orders)
            {
                total += order.Total();
            }

            if (_orders.Count == 0)
            {
                Console.WriteLine("No sales.");
            }
            else
            {
                Console.WriteLine("Sales:");
                foreach (var order in _orders)
                {
                    order.Print();
                    Console.Write("\n");
                }
                Console.WriteLine($"Sales total: ${total}");
            }
        }




    }
}
