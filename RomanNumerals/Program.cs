using System;
using System.Text;

namespace RomanNumeralsCsharpImplementation
{
    public static class RomanNumeralsCsharp
    {
        public static string ToRoman(this int value)
        {
            if (value < 1 || value > 3999)
            {
                throw new ArgumentOutOfRangeException("value", "Roman numerals can only represent numbers from 1 to 3999.");
            }

            int[] arabicValues = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] romanSymbols = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            StringBuilder romanNumeral = new StringBuilder();

            int remainingValue = value;

            for (int i = 0; i < arabicValues.Length; i++)
            {
                while (remainingValue >= arabicValues[i])
                {
                    romanNumeral.Append(romanSymbols[i]);
                    remainingValue -= arabicValues[i];
                }
            }

            return romanNumeral.ToString();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            RunTests();
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }

        public static void RunTests()
        {
            TestToRoman(1, "I");
            TestToRoman(2, "II");
            TestToRoman(4, "IV");
            TestToRoman(9, "IX");
            TestToRoman(25, "XXV");
            TestToRoman(49, "XLIX");
            TestToRoman(273, "CCLXXIII");
            TestToRoman(1024, "MXXIV");
            TestToRoman(1444, "MCDXLIV");
        }

        public static void TestToRoman(int number, string expectedRomanNumeral)
        {
            string romanNumeral = number.ToRoman();

            if (romanNumeral == expectedRomanNumeral)
            {
                Console.WriteLine($"Test passed: {number} => {expectedRomanNumeral}");
            }
            else
            {
                Console.WriteLine($"Test failed: {number} => Expected: {expectedRomanNumeral}, Actual: {romanNumeral}");
            }
        }
    }
}
