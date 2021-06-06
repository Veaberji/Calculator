using NUnit.Framework;
using SimpleCalculator;
using System.Collections.Generic;
using Converter = SimpleCalculator.Converter;

namespace SimpleCalculatorTests
{
    [TestFixture]
    class ConverterTests
    {
        [Test]
        public void CombineNumbers_12Plus345_ReturnExpressionWithCombineNumbersAsList()
        {
            string data = "12+345";
            var expected = new List<string> { "12", "+", "345" };

            var result = Converter.CombineNumbers(data);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void CombineNumbers_Plus12_ReturnExpressionWithCombineNumbersAsList()
        {
            string data = "+12";
            var expected = new List<string> { "0", "+", "12" };

            var result = Converter.CombineNumbers(data);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void CombineNumbers_12PlusNegative345_ReturnExpressionWithCombineNumbersAsList()
        {
            string data = "12+(-345)";
            var expected = new List<string> { "12", "+", "(", "0", "-", "345", ")" };

            var result = Converter.CombineNumbers(data);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void CombineNumbers_12Point34Plus345_ReturnExpressionWithCombineNumbersAsList()
        {
            string separator = Mathematics.Separator;
            string data = $"12{separator}34+345";
            var expected = new List<string> { $"12{separator}34", "+", "345" };

            var result = Converter.CombineNumbers(data);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
