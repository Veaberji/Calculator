using System.Collections.Generic;
using System.Text;

namespace SimpleCalculator
{
    public class Converter
    {
        public static List<string> CombineNumbers(string data)
        {
            var combineNumbersData = new List<string>();
            var numberContainer = new StringBuilder("");

            for (int i = 0; i < data.Length; i++)
            {
                if ((Validator.IsOperator(data[i]) && i == 0) ||
                    (data[i] == Mathematics.Subtraction && data[i - 1] == Mathematics.OpeningParenthesis))
                {
                    combineNumbersData.Add("0");
                }
                if (Validator.IsNumericChar(data[i]))
                {
                    numberContainer.Append(data[i]);

                    if (i == data.Length - 1)
                    {
                        combineNumbersData.Add(numberContainer.ToString());
                    }
                }
                else
                {
                    if (numberContainer.Length > 0)
                    {
                        combineNumbersData.Add(numberContainer.ToString());
                        numberContainer.Clear();
                    }
                    combineNumbersData.Add(data[i].ToString());
                }
            }
            return combineNumbersData;
        }
    }
}