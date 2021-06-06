using NUnit.Framework;
using SimpleCalculator;
using Calculator = SimpleCalculator.Calculator;

namespace SimpleCalculatorTests
{
    [TestFixture]
    class CalculatorTests
    {
        [Test]
        public void Calculate_StringExpressionPassed_ReturnFloatResult()
        {
            string separator = Mathematics.Separator;
            string expression = $"2-4*2{separator}5-(2-4+(1-3)/(2-4*0{separator}25))";
            float expected = -4;

            var calc = new Calculator();
            float result = calc.Calculate(expression);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
