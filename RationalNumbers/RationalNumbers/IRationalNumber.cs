using System;
namespace RationalNumbers
{
    /// <summary>
    /// Rational Number interface
    /// </summary>
    /// 
    public interface IRationalNumber
    {
        
        int Numerator { get; }
        
        int Denominator { get; }
        IRationalNumber Add(IRationalNumber number);
        IRationalNumber Subtract(IRationalNumber number);
        IRationalNumber Multiply(IRationalNumber number);
        IRationalNumber Divide(IRationalNumber number);
        IRationalNumber Abs();
        IRationalNumber ExpRational(int power);
        double ExpReal(int baseNumber);
        





      
    }
}
