using System.Diagnostics;

namespace Test_Resit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stadium stadium = new Stadium();
            stadium.Attack(10);
            stadium.AttackAll(5);

            Mortal mortal1 = new Mortal("Tan", 15);
            Mortal mortal2 = new Mortal("Quang", 15);
            Mortal mortal3 = new Mortal("Bo Duong", 15);
            Immortal immortal = new Immortal("Son");
            stadium.AddCharacter(mortal1);
            stadium.AddCharacter(mortal2);
            stadium.AddCharacter(mortal3);
            stadium.AddCharacter(immortal);

            stadium.AttackAll(8);
            stadium.Attack(10);
            stadium.AttackAll(9);
        }
    }
}
