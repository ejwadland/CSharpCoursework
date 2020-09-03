using System;

namespace BMI
{
    using static Math;

    public enum Range
    {
        Underweight,
        Healthy,
        Overweight 
    }

    public static class Bmi

    {
        static void Main()
        {
            Run(Read, Write);
           
        }

        public static void Run(Func<string, double> read, Action<Range> write)
        {

            var weight = read("weight");
            var height = read("height");

            var bmiRange = CalculateBmi(height, weight).ToBmiRange();

            write(bmiRange);
        }

        public static double CalculateBmi(double height, double weight)
            => Round(weight / Pow(height, 2), 2);

        public static Range ToBmiRange(this double bmi)
            => bmi < 18.5 ? Range.Underweight
            : 25 <= bmi ? Range.Overweight
            : Range.Healthy;

        private static double Read(string answer)
        {
            Console.Write($"Please enter your {answer}: ");
            return double.Parse(Console.ReadLine() ?? "");
        }

        private static void Write(Range BmiRange)
            => Console.WriteLine($"Your BMI classes you as {BmiRange}");

    }
}
