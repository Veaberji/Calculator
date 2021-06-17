using System;

namespace SimpleCalculator
{
    class ConsoleOutput
    {
        public static void InvalidInput()
        {
            Console.Write("Invalid input, try again\n>>> ");
        }

        public static void DivisionByZero()
        {
            Console.WriteLine("Error: Division by zero is prohibited");
        }

        public static void CalculationResult(float result)
        {
            Console.WriteLine($"Result: {result}");
        }

        public static void AskForContinueCalculations()
        {
            Console.WriteLine("Would you like to continue the calculations?\n" +
                          "Press any key to continue or press 'Esc' to exit.");
        }

        public static void EnterCalculatedString()
        {
            Console.Clear();

            Console.Write("Enter the string without the parentheses to calculate,\n" +
                          "available operations:\n" +
                          " multiplication - '*',\n" +
                          " division - '/',\n" +
                          " addition - '+',\n" +
                          " subtraction - '-'.\n" +
                          "Or enter 'quit' to exit\n" +
                          ">>> ");
        }

        public static void EnterInputFilePath()
        {
            Console.Clear();

            Console.Write("Enter the path to the calculations file. " +
                          "Or enter 'quit' to exit\n>>> ");
        }

        public static void EnterOutputFilePath()
        {
            Console.Write("Enter the path to the separate output file. " +
                          "Or enter 'quit' to exit\n>>> ");
        }

        public static void AskForOverwriteFile()
        {
            Console.WriteLine("You are trying to overwrite an existing file.\n" +
                              "Would you like to continue the overwriting?\n" +
                              "Press any key to continue or press 'Esc' to exit.\n");
        }

        public static void Valediction()
        {
            Console.WriteLine("Adieu!");
        }

        public static string Input()
        {
            return Console.ReadLine()?.Replace(" ", string.Empty);
        }

        public static ConsoleKey ReadKey()
        {
            return Console.ReadKey(true).Key;
        }
    }
}