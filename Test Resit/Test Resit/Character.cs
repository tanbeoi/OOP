using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Resit
{
    public abstract class Character
    {
        string _name;

        public Character(string name)
        {
            _name = name;
        }

        public abstract void GetHit(int damage);

        public string Name
        {
            get { return _name; }
        }
    }
}
