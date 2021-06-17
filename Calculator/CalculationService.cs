using System;

namespace SimpleCalculator
{
    class CalculationService
    {
        private readonly Calculator _calculator;
        private bool _continue;

        public CalculationService()
        {
            _calculator = new Calculator();
            _continue = true;
        }

        public void RunConsoleCalculations()
        {
            var dataProvider = new ConsoleData();

            while (_continue)
            {
                try
                {
                    string data = dataProvider.InputData();
                    float result = _calculator.Calculate(data);
                    ConsoleOutput.CalculationResult(result);
                }
                catch (Exception)
                {
                    ConsoleOutput.DivisionByZero();
                }

                ConsoleOutput.AskForContinueCalculations();
                _continue = Validator.CanContinue();
            }
        }

        public void RunFileCalculations()
        {
            var dataProvider = new FileData();

            while (_continue)
            {
                var data = dataProvider.InputData();
                var outputData = new string[data.Length];

                for (var i = 0; i < data.Length; i++)
                {
                    if (Validator.IsValidWithParenthesesData(data[i].Replace(" ", string.Empty)))
                    {
                        try
                        {
                            float result = _calculator.Calculate(data[i].Replace(" ", string.Empty));
                            outputData[i] = $"{data[i]} = {result}";
                        }
                        catch (Exception)
                        {
                            outputData[i] = $"{data[i]} = error in expression";
                        }
                    }
                    else
                    {
                        outputData[i] = $"{data[i]} = error in expression";
                    }
                }

                FileData.WriteData(outputData);

                ConsoleOutput.AskForContinueCalculations();
                _continue = Validator.CanContinue();
            }
        }
    }
}
