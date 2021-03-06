namespace SimpleCalculator
{
    public class ConsoleData
    {
        private string _data;

        public string InputData()
        {
            ConsoleOutput.EnterCalculatedString();
            _data = "";
            bool isValidData = false;
            while (!isValidData)
            {
                _data = ConsoleOutput.Input();
                isValidData = Validator.IsValidWithoutParenthesesData(_data);

                if (!isValidData)
                {
                    ConsoleOutput.InvalidInput();
                }
            }

            return _data;
        }
    }
}
