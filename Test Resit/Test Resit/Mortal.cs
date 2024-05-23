using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Resit
{
    public class Mortal : Character
    {
        private int _health = 15;

        public Mortal(string name, int health) : base(name)
        {
            _health = health;
        }

        public override void GetHit(int damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                Console.WriteLine($"{Name}: You already got me!");
            } else
            {
                Console.WriteLine($"{Name}: Ow!");
            }
        }
    }
}
