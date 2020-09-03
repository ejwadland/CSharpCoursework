using System;

namespace RationalNumbers
{
    public struct RationalNumber : IRationalNumber
    {
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }

        /// <summary>
        /// Given just a numerator.
        /// </summary>
        /// <param name="numerator"></param>
        /// <returns>A whole number as just the numerator is given.</returns>
   
        public RationalNumber(int numerator) 
        {
            Numerator = numerator;
            Denominator = 1;
        }
        /// <summary>
        /// Given a numerator and denominator
        /// </summary>
        /// <param name="numerator"></param>
        /// <param name="denominator"></param>
        /// <returns> If denominator is 0, an error is returned. If numerator is 0, then denominator = 1 (thus 0/1 = 0).
        /// Else numerator and denominator set normally.</returns>
        
        public RationalNumber(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Denominator cannot be 0!", nameof(denominator));
            }
            if (numerator == 0)
            {
                denominator = 1;

            }

            Numerator = numerator;
            Denominator = denominator;
            

        }
        /// <summary>
        /// Implements the plus (+) operator
        /// </summary>
        /// <param name="r1">Rational number 1</param>
        /// <param name="r2">Rational number 2</param>
        /// <returns> returns r1 + r2 </returns>

        public static IRationalNumber operator +(RationalNumber r1, RationalNumber r2) => r1.Add(r2);

        /// <summary>
        /// Implements the subtraction (-) operator
        /// </summary>
        /// <param name="r1">Rational number 1</param>
        /// <param name="r2">Rational number 2</param>
        /// <returns> returns r1 - r2 </returns>

        public static IRationalNumber operator -(RationalNumber r1, RationalNumber r2) => r1.Subtract(r2);

        /// <summary>
        /// Implements multiply (*) opperator
        /// </summary>
        /// <param name="r1">Rational number 1</param>
        /// <param name="r2">Rational number 2</param>
        /// <returns> returns r1 * r2 </returns>

        public static IRationalNumber operator *(RationalNumber r1, RationalNumber r2) => r1.Multiply(r2);

        /// <summary>
        /// Implements divide (/) operator
        /// </summary>
        /// <param name="r1">Rational number 1</param>
        /// <param name="r2">Rational number 2</param>
        /// <returns> returns r1 / r2 </returns>

        public static IRationalNumber operator /(RationalNumber r1, RationalNumber r2) => r1.Divide(r2);

        /// <summary>
        /// Gets the absolute of a rational number
        /// </summary>
        /// <returns> returns absolute of Numerator and Denominator (never < 0) </returns>

        public IRationalNumber Abs()
        {
            return new RationalNumber(Math.Abs(Numerator), Math.Abs(Denominator));
        }

        /// <summary>
        /// Finds greatest common divisor between Numerator and Denominator. Divides each to get a reduced rational number
        /// </summary>
        /// <returns> If numerator = 0 - will return 0.
        /// if denominator is < 0 - turns rational number into a positive.
        /// else - reduces rational number to smallest possible form</returns>
        
        public IRationalNumber Reduce()
        {
            int gcd = GreatestCommonDiv(Numerator, Denominator);

            if (Numerator == 0)
            {
                Denominator = 1;
                return new RationalNumber(0, 1);
            }

            if (Denominator < 0)
            {
                Numerator = -Numerator;
                Denominator = -Denominator;

            }

            return new RationalNumber((Numerator / gcd), (Denominator / gcd));

        }

        /// <summary>
        /// Raises the rational number to the power that 
        /// </summary>
        /// <param name="power">int number that power will be raised to</param>
        /// <returns> Rational number raised to the mentioned power</returns>

        public IRationalNumber ExpRational(int power)
        {
            double pow = (double)power;
            double num = (double)Numerator;
            double den = (double)Denominator;

            return new RationalNumber((int)Math.Pow(num, pow), (int)Math.Pow(den, pow));
            
        }

        /// <summary>
        ///  exponentiation of a real number to a rational number
        /// </summary>
        /// <param name="baseNumber">Base number given</param>
        /// <returns></returns>

        public double ExpReal(int baseNumber)
        {
            return Math.Pow(Math.Pow(baseNumber, Numerator), 1.0 / Denominator);
        }

        /// <summary>
        /// Creating Add function linked to + operator
        /// </summary>
        /// <param name="number"></param>
        /// <returns>The sum of two rational numbers</returns>

        public IRationalNumber Add(IRationalNumber number)
        {
            // = (a1 * b2 + a2 * b1) / (b1 * b2)

            return new RationalNumber((Numerator * number.Denominator) + (number.Numerator * Denominator), (Denominator * number.Denominator)).Reduce();


        }

        /// <summary>
        /// Creating Subtract function linked to - operator
        /// </summary>
        /// <param name="number"></param>
        /// <returns>The subtraction of two rational numbers</returns>

        public IRationalNumber Subtract(IRationalNumber number)
        {
            // = (a1 * b2 - a2 * b1) / (b1 * b2)

            return new RationalNumber((Numerator * number.Denominator) - (number.Numerator * Denominator), (Denominator * number.Denominator)).Reduce();
        }

        /// <summary>
        /// Creating Multiply function linked to * operator
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Multiplication of two rational numbers</returns>

        public IRationalNumber Multiply(IRationalNumber number)
        {
            // = (a1 * a2) / (b1 * b2)

            return new RationalNumber((Numerator * number.Numerator), (Denominator * number.Denominator)).Reduce();
        }

        /// <summary>
        /// Creating Divide function linked to / operator
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Division of two rational numbers. If either numerator or denominator = 0 - an exception is thrown</returns>

        public IRationalNumber Divide(IRationalNumber number)
        {
            // = (a1 * b2) / (a2 * b1) (if a2 and b1 are not 0)

            if (number.Numerator == 0 || Denominator == 0)
            {
                throw new ArgumentException("Cannot divide by 0!");
            }
            else
            {
                return new RationalNumber((Numerator * number.Denominator), (number.Numerator * Denominator)).Reduce();
            }
        }

        /// <summary>
        /// Create string 
        /// </summary>
        /// <returns> Rational number turned into a string </returns>
        
        public override string ToString()
        {
            return $"{this.Numerator}/{this.Denominator}";
        }


        /// <summary>
        /// Find greatest common divisor between two ints
        /// </summary>
        /// <param name="a">first int</param>
        /// <param name="b">second int</param>
        /// <returns>the greatest common divisor of two given integers. Later used to reduce rational numbers</returns>
     
        static int GreatestCommonDiv(int a, int b)
        {
            return b == 0 ? Math.Abs(a) : GreatestCommonDiv(Math.Abs(b), Math.Abs(a) % Math.Abs(b));
        }

       
    }


    public static class IntNumberExtension
    {
        // exponentiate real number to the rational number power
        public static double ExpReal(this int intNumber, RationalNumber r)
        {
            return r.ExpReal(intNumber);
        }
    }
}
