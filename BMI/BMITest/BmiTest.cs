using NUnit.Framework;


namespace BMI.Test
{

    public class BmiTest
    {
        [TestCase(1.80, 77, ExpectedResult = 23.77)]
        [TestCase(1.60, 77, ExpectedResult = 30.08)]
        public double CalculateBmi(double height, double weight)
            => Bmi.CalculateBmi(height, weight);

        [TestCase(23.77, ExpectedResult = BmiRange.Healthy)]
        [TestCase(30.08, ExpectedResult = BmiRange.Overweight)]
        public BmiRange ToBmiRange(double bmi) => bmi.ToBmiRange();


    }
    
    
}
