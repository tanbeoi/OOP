using System.Transactions;

namespace SemTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sales sales = new Sales();

            //Add transactions 
            Transaction t1 = new Transaction("100", "Nitendo Switch", (decimal)300.50);
            Transaction t2 = new Transaction("101", "Ferrari", (decimal)10000.00);
            Transaction t3 = new Transaction("102", "PC", (decimal)3000.75);
            sales.Add(t1);
            sales.Add(t2);
            sales.Add(t3);

            //Add batch
            Batch b1 = new Batch("104", "Favourite CDs");
            Transaction t4 = new Transaction("103", "Avatar The Last Airbender", (decimal)100.00);
            Transaction t5 = new Transaction("104", "Chungking Express", (decimal)100.00);
            Transaction t6 = new Transaction("105", "Blade Runner 2099", (decimal)100.00);
            b1.Add(t4);
            b1.Add(t5);
            b1.Add(t6);
            sales.Add(b1);

            //Add nested batch
            Batch b2 = new Batch("105", "Favourite Media");
            Transaction t7 = new Transaction("106", "Harry Potter and the Half-blood Prince", (decimal)60.00);
            Transaction t8 = new Transaction("107", "The Perks of Being a Wallflower", (decimal)60.00);
            b2.Add(t7);
            b2.Add(t8);
            b2.Add(b1);
            sales.Add(b2);

            //Add empty batch
            Batch b3 = new Batch("106", "Favourite Books");
            sales.Add(b3);

            //Print Sales
            sales.Print();

        }
    }
}
