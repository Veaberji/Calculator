using NUnit.Framework;
using SimpleCalculator;
using Validator = SimpleCalculator.Validator;

namespace SimpleCalculatorTests
{
    [TestFixture]
    class ValidatorTests
    {
        [Test]
        public void IsValidWithParenthesesData_EmptyString_ReturnFalse()
        {
            string empty = "";

            bool result = Validator.IsValidWithParenthesesData(empty);

            Assert.IsFalse(result);
        }

        [Test]
        [TestCase("1+)1-1)")]
        [TestCase("1+(1-(1+1)")]
        [TestCase("1+(1-1")]
        [TestCase("(1+()-1-1)")]
        [TestCase("(1+(1+(-1))))")]
        [TestCase("(1+((1+(-1)))")]
        public void IsValidWithParenthesesData_InvalidParentheses_ReturnFalse(string data)
        {
            bool result = Validator.IsValidWithParenthesesData(data);

            Assert.IsFalse(result);
        }

        [Test]
        [TestCase("1+1-1(")]
        [TestCase("1+1-1-")]
        [TestCase("1+1-1,")]
        [TestCase("1+1-1x")]
        [TestCase("1+1-1.")]
        [TestCase("1+1-1*")]
        public void IsValidWithParenthesesData_EndNotWithDigitNotWithClosingParenthesis_ReturnFalse(string data)
        {
            bool result = Validator.IsValidWithParenthesesData(data);

            Assert.IsFalse(result);
        }

        [Test]
        [TestCase("()")]
        [TestCase("+")]
        [TestCase("(/)")]
        [TestCase("(-)")]
        public void IsValidWithParenthesesData_HasNoDigit_ReturnFalse(string data)
        {
            bool result = Validator.IsValidWithParenthesesData(data);

            Assert.IsFalse(result);
        }

        [Test]
        [TestCase("(1-a)")]
        [TestCase("!+!")]
        [TestCase("1-x")]
        [TestCase("{1/1}")]
        public void IsValidWithParenthesesData_HasInvalidCharacter_ReturnFalse(string data)
        {
            bool result = Validator.IsValidWithParenthesesData(data);

            Assert.IsFalse(result);
        }

        [Test]
        [TestCase("(1--1)")]
        [TestCase("(1+)")]
        [TestCase("(//1 )")]
        [TestCase("1+(1*)")]
        public void IsValidWithParenthesesData_HasInValidOperation_ReturnFalse(string data)
        {
            bool result = Validator.IsValidWithParenthesesData(data);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidWithParenthesesData_NoDigitAfterSeparator_ReturnFalse()
        {
            string separator = Mathematics.Separator;
            string data = $"1{separator}+1";

            bool result = Validator.IsValidWithParenthesesData(data);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidWithParenthesesData_NoDigitBeforeSeparator_ReturnFalse()
        {
            string separator = Mathematics.Separator;
            string data = $"{separator}1+1";

            bool result = Validator.IsValidWithParenthesesData(data);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidWithParenthesesData_CorrectPositionOfSeparator_ReturnTrue()
        {
            string separator = Mathematics.Separator;
            string data = $"1{separator}1+1";

            bool result = Validator.IsValidWithParenthesesData(data);

            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("1-1")]
        [TestCase("(1+(1/1))")]
        [TestCase("(1*1)")]
        public void IsValidWithParenthesesData_CorrectData_ReturnTrue(string data)
        {
            bool result = Validator.IsValidWithParenthesesData(data);

            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("(1+(1/1))")]
        [TestCase("(1*1")]
        [TestCase("1*1)")]
        public void IsValidWithoutParenthesesData_DataContainsParentheses_ReturnFalse(string data)
        {
            bool result = Validator.IsValidWithoutParenthesesData(data);

            Assert.IsFalse(result);
        }
    }
}
