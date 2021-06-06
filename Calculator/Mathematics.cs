using System.Globalization;

namespace SimpleCalculator
{
    public class Mathematics
    {
        public static readonly char Multiplication = '*';
        public static readonly char Division = '/';
        public static readonly char Addition = '+';
        public static readonly char Subtraction = '-';

        public static readonly char OpeningParenthesis = '(';
        public static readonly char ClosingParenthesis = ')';

        public static readonly char[] Operators = { Multiplication, Division, Addition, Subtraction };
        public static readonly string Separator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
    }
}