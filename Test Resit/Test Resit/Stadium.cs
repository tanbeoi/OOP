using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Resit
{
    internal class Stadium
    {
        List<Character> _npcs = new List<Character>();

        public Stadium() { }

        public void AddCharacter(Character character)
        {
            _npcs.Add(character);
        }

        public void Attack(int damage)
        {
            if (_npcs.Count == 0)
            {
                Console.WriteLine("Not very effective...");
            } else
            {
                Console.WriteLine("Bring it on!");
                _npcs[0].GetHit(damage);
            }
        }

        public void AttackAll(int damage)
        {
            if (_npcs.Count == 0)
            {
                Console.WriteLine("Why?");
            } else
            {
                Console.WriteLine("Charge!");
                foreach (Character npc in _npcs)
                {
                    npc.GetHit(damage);
                }
            }
          
        }
    }
}
