using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace SimpleCalculator
{
    public class Validator
    {
        public static bool IsValidWithParenthesesData(string data)
        {
            if (!IsCorrectString(data) || !HasCorrectEnd(data) || !IsCorrectParentheses(data))
            {
                return false;
            }

            bool hasDigit = false;
            for (int i = 0; i < data.Length; i++)
            {
                if (!hasDigit)
                {
                    hasDigit = char.IsDigit(data[i]);
                }

                bool lastCharIndex = (i == data.Length - 1);
                if (HasInvalidCharacter(data[i]))
                {
                    return false;
                }

                if (!lastCharIndex &&
                    !HasValidOperation(data[i], data[i + 1]))
                {
                    return false;
                }

                if (IsSeparator(data[i]))
                {
                    if (i == 0 ||
                        (!lastCharIndex && !IsCorrectPositionOfSeparator(data[i - 1], data[i + 1])))
                    {
                        return false;
                    }
                }
            }

            return hasDigit;
        }

        public static bool IsCorrectString(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                return false;
            }

            CheckForQuit(data);

            return true;
        }

        public static bool IsNumericChar(char character)
        {
            return char.IsDigit(character) ||
                   IsSeparator(character);
        }

        public static bool IsOperator(char character)
        {
            return Mathematics.Operators.Contains(character);
        }

        public static bool HasDivisionByZero(float number)
        {
            if (number == 0)
            {
                return true;
            }
            return false;
        }

        public static bool IsPossibleDirectory(string path)
        {
            string localDisk = path[..2];
            return Directory.Exists(localDisk);
        }

        public static bool CanContinue()
        {
            var key = Console.ReadKey(true).Key;
            if (key != ConsoleKey.Escape)
            {
                return true;
            }

            return false;
        }

        private static bool HasValidOperation(char currentChar, char nextChar)
        {
            if (IsOperator(currentChar) && (!IsNumericChar(nextChar) && nextChar != Mathematics.OpeningParenthesis))
            {
                return false;
            }
            return true;
        }

        private static void CheckForQuit(string data)
        {
            if (data.ToLower() == "quit")
            {
                Console.WriteLine("Adieu!");
                Thread.Sleep(2000);
                Environment.Exit(0);
            }
        }

        private static bool HasCorrectEnd(string data)
        {
            char lastСharacter = data[^1];
            if (!char.IsDigit(lastСharacter) && lastСharacter != Mathematics.ClosingParenthesis)
            {
                return false;
            }
            return true;
        }

        private static bool HasInvalidCharacter(char character)
        {
            return !IsNumericChar(character) &&
                   !IsOperator(character) &&
                   character != Mathematics.OpeningParenthesis &&
                   character != Mathematics.ClosingParenthesis;
        }

        private static bool IsSeparator(char character)
        {
            return Mathematics.Separator.Contains(character);
        }

        private static bool IsCorrectPositionOfSeparator(char lastChar, char nextChar)
        {
            return char.IsDigit(lastChar) && char.IsDigit(nextChar);
        }

        private static bool IsCorrectParentheses(string data)
        {
            var stack = new Stack<char>();
            for (var i = 0; i < data.ToCharArray().Length; i++)
            {
                if (data[i] == Mathematics.OpeningParenthesis)
                {
                    if (!char.IsDigit(data[i + 1]) && data[i + 1] != Mathematics.Subtraction)
                    {
                        return false;
                    }
                    stack.Push(data[i]);
                }
                else if (data[i] == Mathematics.ClosingParenthesis)
                {
                    if (stack.Count == 0 || stack.Pop() != Mathematics.OpeningParenthesis)
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }
    }
}
