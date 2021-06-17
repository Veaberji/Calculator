using System;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var service = new CalculationService();
                service.RunConsoleCalculations();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                var service = new CalculationService();
                service.RunFileCalculations();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
