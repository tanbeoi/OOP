using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemTest
{
    public abstract class Thing
    {
        private string _number, _name;

        public Thing(string number, string name)
        {
            _name = name;
            _number = number;
        }

        public abstract void Print();

        public abstract decimal Total();

        public string Number
        {
            get { return _number; }
        }

        public string Name
        {
            get { return _name; }
        }
    }
}
