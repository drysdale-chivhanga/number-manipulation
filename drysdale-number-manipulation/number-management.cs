using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drysdale.Number.Manipulation
{
    #region Class.NumberManipulation...
    /// <summary>
    /// Class.NumberManipulation
    /// </summary>
    public class NumberManip
    {
        #region Static-Method.GetRandomNumber...
        /// <summary>
        /// Static-Method.GetRandomNumber
        /// </summary>
        /// <param name="minVal">The Minimum-Included-Value</param>
        /// <param name="maxVal">The Maximum Not-INCLUDED-Value!!!</param>
        /// <returns>The Interger-Value</returns>
        public static int GetNumber(int minVal, int maxVal) => new Random().Next(minVal, maxVal);
        #endregion

        #region Static-Method.GetRandomNumbers...
        /// <summary>
        /// Static-Method.GetRandomNumbers
        /// </summary>
        /// <param name="sizeOfList">How Many Numbers Are Needed</param>
        /// <param name="minVal">The Minimum-Included-Value</param>
        /// <param name="maxVal">The Maximum Not-INCLUDED-Value!!!</param>
        /// <returns>The Integer-Values</returns>
        public static List<int> GetNumbers(int sizeOfList, int minVal, int maxVal)
        {
            int i = 0;
            List<int> numbers = new List<int>();
            while (i < sizeOfList)
            {
                int newNumber = GetNumber(minVal, maxVal);
                if (numbers.Contains(newNumber))
                    continue;
                numbers.Add(newNumber);
                i++;

            }
            return numbers;
        }
        #endregion

        #region Static-Method.Get-Decimal-Placed Value...
        /// <summary>
        /// Static-Method.Get-Four-Decimal-Placed Value
        /// </summary>
        /// <param name="incomingNumber">The Incoming Value (Number)</param>
        /// <param name="digitsAfterComma">The Number-Of-Didigits-After-Comma (Decimal-Places)</param>
        /// <returns>Decimal Placed Value</returns>
        public static string GetDecimalPlacedValue(object incomingNumber, int digitsAfterComma)
        {
            double answer = Math.Round(value: (Convert.ToDouble(incomingNumber) + 0.00000000000000000001), digits: digitsAfterComma);
            string ansEquivalent = answer.ToString();
            StringBuilder sufixBuilder = new StringBuilder();
            string suffix;
            string prefix;
            if (ansEquivalent.Contains('.'))
            {
                string[] fullValue = ansEquivalent.Split('.');
                prefix = fullValue[0];
                string suffixValue = fullValue[1];
                if (suffixValue.Length < digitsAfterComma)
                {
                    sufixBuilder.Append(suffixValue);
                    int difference = digitsAfterComma - suffixValue.Length;
                    int i = 0;
                    while (i < difference)
                    {
                        sufixBuilder.Append("0");
                        i++;
                    }
                    suffix = sufixBuilder.ToString();
                }
                else
                {
                    suffix = suffixValue.Substring(0, digitsAfterComma);
                }

            }
            else
            {
                prefix = ansEquivalent;
                int i = 0;
                while (i < digitsAfterComma)
                {
                    sufixBuilder.Append("0");
                    i++;
                }
                suffix = sufixBuilder.ToString();
            }
            return $"{(prefix.Length > 3 ? GetThreeDigitsFormater(prefix) : prefix)}.{suffix}";
        }
        #endregion

        #region Static-Method.Get-Decimal-Placed
        /// <summary>
        /// Static-Method.Get-Decimal-Placed
        /// </summary>
        /// <param name="incomingNumber">The Incoming-Number</param>
        /// <param name="digitsAfterComma">The Decimal-Places Requested</param>
        /// <returns>The Decimal-Rounded-Equivalent-Value</returns>
        public static decimal GetDecimalPlaced(object incomingNumber, int digitsAfterComma)
            => (decimal)Math.Round(value: Convert.ToDouble(incomingNumber), digits: digitsAfterComma);
        #endregion

        #region Static-Method.GetDoubleTotal...
        /// <summary>
        /// Static-Method.GetDoubleTotal
        /// </summary>
        /// <param name="incomingArray">The Incoming-Double-Array</param>
        /// <returns>The Double-Sum</returns>
        public static double GetDoubleTotal(double[] incomingArray) => incomingArray.Sum();
        #endregion

        /// <summary>
        /// GetThreeDigitsFormater
        /// </summary>
        /// <param name="fulValue"></param>
        /// <returns></returns>
        static string GetThreeDigitsFormater(string fulValue)
        {
            string formatedValue = "";
            int fulValueLength = fulValue.Length;
            switch (fulValueLength)
            {
                case 4:
                    string a4 = fulValue.Substring(0, 1);
                    string b4 = fulValue.Substring(1);
                    formatedValue = $"{a4},{b4}";
                    break;
                case 5:
                    string a5 = fulValue.Substring(0, 2);
                    string b5 = fulValue.Substring(2);
                    formatedValue = $"{a5},{b5}";
                    break;
                case 6:
                    string a6 = fulValue.Substring(0, 3);
                    string b6 = fulValue.Substring(3);
                    formatedValue = $"{a6},{b6}";
                    break;
                case 7:
                    string a7 = fulValue.Substring(0, 1);
                    string b7 = fulValue.Substring(1, 3);
                    string c7 = fulValue.Substring(4);
                    formatedValue = $"{a7},{b7},{c7}";
                    break;
                case 8:
                    string a8 = fulValue.Substring(0, 2);
                    string b8 = fulValue.Substring(2, 3);
                    string c8 = fulValue.Substring(5);
                    formatedValue = $"{a8},{b8},{c8}";
                    break;
                case 9:
                    string a9 = fulValue.Substring(0, 3);
                    string b9 = fulValue.Substring(3, 3);
                    string c9 = fulValue.Substring(6);
                    formatedValue = $"{a9},{b9},{c9}";
                    break;
                case 10:
                    string a10 = fulValue.Substring(0, 1);
                    string b10 = fulValue.Substring(1, 3);
                    string c10 = fulValue.Substring(4, 3);
                    string d10 = fulValue.Substring(7);
                    formatedValue = $"{a10},{b10},{c10},{d10}";
                    break;
                default:
                    break;
            }
            return formatedValue;
        }
        /// <summary>
        /// GetQuotientAndRemainder
        /// </summary>
        /// <param name="incNumertor">The Incoming-Numerator</param>
        /// <param name="incDenominator">The Incoming-Denominator</param>
        /// <param name="Quotient">The Returned-Quotient After-Dividing</param>
        /// <param name="Remainder">The Returned-Remainder After-Dividing</param>
        public static void GetQuotientAndRemainder(int incNumertor, int incDenominator, out int Quotient, out int Remainder)
        {
            Quotient = incNumertor / incDenominator;
            Remainder = incNumertor % incDenominator;
        }
    }
    #endregion
}
