using System;

namespace RationalNumbers
{
    class Program
    {
        static void Main()
        {
            IRationalNumber r1 = new RationalNumber(6, 18);
            IRationalNumber r2 = new RationalNumber(24, 120);


            
            Console.WriteLine(r1.Divide(r2));
        }
    }
}
