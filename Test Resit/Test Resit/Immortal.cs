using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Resit
{
    internal class Immortal : Character
    {

        public Immortal(string name) : base(name)
        {
        }

        public override void GetHit(int damage)
        {
            Console.WriteLine($"{Name}: Ha, Nice try.");
        }
    }
}
