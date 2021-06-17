using System;
using System.Collections.Generic;
using System.Globalization;

namespace SimpleCalculator
{
    public class Calculator
    {
        private List<string> _secondPriorityCalculations;
        private List<string> _data;

        public float Calculate(string data)
        {
            _secondPriorityCalculations = new List<string>();
            _data = Converter.CombineNumbers(data);
            var containerData = new List<string>();
            var openingParenthesisIndexes = new Stack<int>();

            for (int i = 0; i < _data.Count; i++)
            {
                containerData.Add(_data[i]);
                if (_data[i] == Mathematics.OpeningParenthesis.ToString())
                {
                    openingParenthesisIndexes.Push(containerData.Count - 1);
                }
                else if (_data[i] == Mathematics.ClosingParenthesis.ToString())
                {
                    int openingParenthesisIndex = openingParenthesisIndexes.Pop();
                    int firstNumberIndex = openingParenthesisIndex + 1;
                    int noParenthesesCount = (containerData.Count - 1) - firstNumberIndex;
                    int entireExpressionLength = noParenthesesCount + 2;

                    float result = CalculateSimpleOperations(
                        containerData.GetRange(firstNumberIndex, noParenthesesCount));

                    containerData.RemoveRange(openingParenthesisIndex, entireExpressionLength);
                    containerData.Add(result.ToString(CultureInfo.CurrentCulture));
                }
            }
            return CalculateSimpleOperations(containerData);
        }

        private float CalculateSimpleOperations(List<string> data)
        {
            FirstPriorityCalculate(data);
            return SecondPriorityCalculate();
        }

        private void FirstPriorityCalculate(List<string> data)
        {
            for (int i = 0; i < data.Count; i++)
            {
                float result;
                if (data[i] == Mathematics.Multiplication.ToString())
                {
                    result = float.Parse(data[i - 1]);
                    var number = float.Parse(data[i + 1]);
                    result *= number;

                    WriteResult((float)result);
                    i++;
                }
                else if (data[i] == Mathematics.Division.ToString())
                {

                    result = float.Parse(data[i - 1]);
                    var number = float.Parse(data[i + 1]);

                    if (!Validator.HasDivisionByZero(number))
                    {
                        result /= number;
                        WriteResult((float)result);
                        i++;
                    }
                    else
                    {
                        throw new DivideByZeroException();
                    }

                }
                else
                {
                    _secondPriorityCalculations.Add(data[i]);
                }
            }
        }

        private float SecondPriorityCalculate()
        {
            float result = float.Parse(_secondPriorityCalculations[0]);

            for (int i = 1; i < _secondPriorityCalculations.Count; i++)
            {
                if (_secondPriorityCalculations[i] == Mathematics.Addition.ToString())
                {
                    string number = _secondPriorityCalculations[i + 1];
                    result += float.Parse(number);
                    i++;
                }
                else if (_secondPriorityCalculations[i] == Mathematics.Subtraction.ToString())
                {
                    string number = _secondPriorityCalculations[i + 1];
                    result -= float.Parse(number);
                    i++;
                }
            }
            _secondPriorityCalculations.Clear();
            return result;
        }

        private void WriteResult(float result)
        {
            _secondPriorityCalculations.RemoveAt(_secondPriorityCalculations.Count - 1);
            _secondPriorityCalculations.Add(result.ToString(CultureInfo.CurrentCulture));
        }
    }
}
