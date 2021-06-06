using System;
using System.IO;

namespace SimpleCalculator
{
    class FileData
    {
        private string _inputPath;
        private string[] _data;

        public string[] InputData()
        {
            ConsoleOutput.EnterInputFilePath();
            _inputPath = InputPath();

            _data = File.ReadAllLines(_inputPath);

            return _data;
        }

        public static void WriteData(string[] data)
        {
            ConsoleOutput.EnterOutputFilePath();
            string outputFilePath = InputPathToWrite();

            if (File.Exists(outputFilePath))
            {
                ConsoleOutput.AskForOverwriteFile();

                if (!Validator.CanContinue())
                {
                    return;
                }
            }

            string directory = Path.GetDirectoryName(outputFilePath);
            Directory.CreateDirectory(directory);
            File.WriteAllLines(outputFilePath, data);
        }

        private static string InputPath()
        {
            bool isFileExists = false;
            string filePath = "";

            while (!isFileExists)
            {
                filePath = Console.ReadLine();
                Validator.IsCorrectString(filePath);
                isFileExists = File.Exists(filePath);
                if (!isFileExists)
                {
                    ConsoleOutput.InvalidInput();
                }
            }

            return filePath;
        }

        private static string InputPathToWrite()
        {
            bool isPossibleDirectory = false;
            string filePath = "";

            while (!isPossibleDirectory)
            {
                filePath = Console.ReadLine()?.Trim();
                Validator.IsCorrectString(filePath);
                isPossibleDirectory = Validator.IsPossibleDirectory(filePath);
                if (!isPossibleDirectory)
                {
                    ConsoleOutput.InvalidInput();
                }
            }

            return AddTxtExtension(filePath);
        }

        private static string AddTxtExtension(string path)
        {
            if (!Path.HasExtension(path))
            {
                path += ".txt";
            }

            return path;
        }
    }
}
