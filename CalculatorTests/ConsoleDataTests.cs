using NUnit.Framework;
using SimpleCalculator;
using System;
using System.IO;

namespace SimpleCalculatorTests
{
    [TestFixture]
    class ConsoleDataTests
    {
        [Test]
        public void InputData_ValidDataProvided_ReturnDataStringWithoutSpaces()
        {
            string data = "2 + 3 * 6 + 2 / 4";
            var sr = new StringReader(data);
            string expected = "2+3*6+2/4";

            Console.SetIn(sr);
            var dataProvider = new ConsoleData();
            string result = dataProvider.InputData();

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
