using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public enum NumberWordsType
    {
        Lacs = 0,
        Millions = 1
    }
    public class NumberWord
    {
        private static string[] baseTwenty = {"Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", 
            "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen",
            "Eighteen", "Ninteen"};
        private static string[] decades = {"", "", "Twenty", "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", 
            "Eighty", "Ninty"};

        /// <summary>
        ///< Method to get number in words.>       
        /// </summary>
        /// <Param number = input number ></Param>
        /// <returns> converted number in word string </returns>
        private static string GetNumberInWordsInLacs(string number)
        {
            string numberString = "";
            long num = long.Parse(number);

            if (number.Length < 3)
            {
                if (num < 20)
                {
                    numberString = baseTwenty[(int)num];
                }
                else
                {
                    numberString = decades[(int)(num / 10)] +
                        (baseTwenty[(int)(num % 10)].Equals("Zero") ? "" : " " + baseTwenty[(int)(num % 10)]);
                }
            }
            else
                if (number.Length == 3)
                {
                    numberString = baseTwenty[int.Parse(number.ToCharArray()[0] + "")] + " Hundred ";
                    if (number.ToCharArray()[0] == '0')
                        numberString = "";
                    numberString = numberString + GetNumberInWordsInLacs(number.Substring(1));
                }
                else
                    if (number.Length > 3 && number.Length < 6)
                    {
                        numberString = GetNumberInWordsInLacs(number.Substring(0, number.Length - 3)) + " Thousand ";
                        if ((number.ToCharArray()[0] == '0' && number.Length == 4) || (number.ToCharArray()[0] == '0' && number.ToCharArray()[1] == '0'))
                            numberString = "";
                        numberString = numberString + GetNumberInWordsInLacs(number.Substring(number.Length - 3));
                    }
                    else
                        if (number.Length > 5 && number.Length < 8)
                        {
                            numberString = GetNumberInWordsInLacs(number.Substring(0, number.Length - 5)) + " Lac" + (number.Length > 6 ? "s " : " ");
                            if ((number.ToCharArray()[0] == '0' && number.Length == 6) || (number.ToCharArray()[0] == '0' && number.ToCharArray()[1] == '0'))
                                numberString = "";
                            numberString = numberString + GetNumberInWordsInLacs(number.Substring(number.Length - 5));
                        }
                        else
                            if (number.Length > 7)
                            {
                                numberString = GetNumberInWordsInLacs(number.Substring(0, number.Length - 7)) + " Crore" + (number.Length > 8 ? "s " : " ");
                                if (numberString.StartsWith("Zero"))
                                    numberString = "";
                                numberString = numberString + GetNumberInWordsInLacs(number.Substring(number.Length - 7));
                            }

            if (numberString.Length > 4 && numberString.EndsWith("Zero"))
                numberString = numberString.Substring(0, numberString.LastIndexOf(" "));

            numberString = numberString.Trim();
            return numberString;
        }

        /// <summary>
        ///< Method to get number in words.>       
        /// </summary>
        /// <Param number = input number ></Param>
        /// <returns> converted number in word string </returns>
        private static string GetNumberInWordsInMillions(string number)
        {
            string numberString = "";
            long num = long.Parse(number);

            if (number.Length < 3)
            {
                if (num < 20)
                {
                    numberString = baseTwenty[(int)num];
                }
                else
                {
                    numberString = decades[(int)(num / 10)] +
                        (baseTwenty[(int)(num % 10)].Equals("Zero") ? "" : " " + baseTwenty[(int)(num % 10)]);
                }
            }
            else
                if (number.Length == 3)
                {
                    numberString = baseTwenty[int.Parse(number.ToCharArray()[0] + "")] + " Hundred ";
                    if (number.ToCharArray()[0] == '0')
                        numberString = "";
                    numberString = numberString + GetNumberInWordsInMillions(number.Substring(1));
                }
                else
                    if (number.Length > 3 && number.Length < 7)
                    {
                        numberString = GetNumberInWordsInMillions(number.Substring(0, number.Length - 3)) + " Thousand ";
                        if ((number.ToCharArray()[0] == '0' && number.Length == 4) || (number.ToCharArray()[0] == '0' && number.ToCharArray()[1] == '0'))
                            numberString = "";
                        numberString = numberString + GetNumberInWordsInMillions(number.Substring(number.Length - 3));
                    }
                    else
                        if (number.Length > 6 && number.Length < 10)
                        {
                            numberString = GetNumberInWordsInMillions(number.Substring(0, number.Length - 6)) + " Million" + (number.Length > 7 ? "s " : " ");
                            if ((number.ToCharArray()[0] == '0' && number.Length == 6) || (number.ToCharArray()[0] == '0' && number.ToCharArray()[1] == '0'))
                                numberString = "";
                            numberString = numberString + GetNumberInWordsInMillions(number.Substring(number.Length - 6));
                        }
                        else
                            if (number.Length > 9)
                            {
                                numberString = GetNumberInWordsInMillions(number.Substring(0, number.Length - 9)) + " Billion" + (number.Length > 10 ? "s " : " ");
                                if (numberString.StartsWith("Zero"))
                                    numberString = "";
                                numberString = numberString + GetNumberInWordsInMillions(number.Substring(number.Length - 8));
                            }

            if (numberString.Length > 4 && numberString.EndsWith("Zero"))
                numberString = numberString.Substring(0, numberString.LastIndexOf(" "));

            numberString = numberString.Trim();
            return numberString;
        }

        /// <summary>
        ///< Method to get decimal number in words.>       
        /// </summary>
        /// <Param number = input number ></Param>
        /// <returns> converted decimalnumber in word string </returns>
        public static string GetDecimalNumberInWords(string number, string decimalRepresentation, NumberWordsType wordsType)
        {
            // Start-Change Round Decimal Value by Abdul Rauf Ahmed on Dated 06-Apr-2009
            number =decimal.Round(Convert.ToDecimal(number),2).ToString();
            // End-Change Round Decimal Value by Abdul Rauf Ahmed on Dated 06-Apr-2009
            string numberString = "";
            long beforeDecimal = long.Parse(number.Substring(0, number.IndexOf(".")));
            long afterDecimal = long.Parse(number.Substring(number.IndexOf(".") + 1, 2));

            if (wordsType == NumberWordsType.Lacs)
                numberString = NumberWord.GetNumberInWordsInLacs(beforeDecimal.ToString());
            else
                numberString = NumberWord.GetNumberInWordsInMillions(beforeDecimal.ToString());

            if (afterDecimal > 0)
            {
                for (; ; )
                {
                    if (afterDecimal.ToString().EndsWith("0"))
                        afterDecimal = afterDecimal / 10;
                    else
                        break;
                }

                if (wordsType == NumberWordsType.Lacs)
                    numberString = numberString + " & " + NumberWord.GetNumberInWordsInLacs(afterDecimal.ToString()) + " " + decimalRepresentation + " Only";
                else
                    numberString = numberString + " & " + NumberWord.GetNumberInWordsInMillions(afterDecimal.ToString()) + " " + decimalRepresentation + " Only";
            }
            else
            {
                numberString = numberString + " Only";
            }

            return numberString.ToUpper();
        }
    }
}
