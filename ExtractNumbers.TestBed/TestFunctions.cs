using System.Data.SqlTypes;
using System.Text;
using System.Text.RegularExpressions;

namespace ExtractNumbers.TestBed
{
    public static class TestFunctions
    {
        public static SqlString ExtractNumbersSBLengthOneHalf(SqlString input)
        {
            var inner = input.Value;
            var builder = new StringBuilder(inner.Length / 2);
            foreach (var character in inner)
            {
                if (char.IsDigit(character))
                {
                    builder.Append(character);
                }
            }
            var result = builder.ToString();
            return result.Length == 0 ? null : result;
        }

        public static SqlString ExtractNumbersSBLength4000(SqlString input)
        {
            var inner = input.Value;
            var builder = new StringBuilder(4000);
            foreach (var character in inner)
            {
                if (char.IsDigit(character))
                {
                    builder.Append(character);
                }
            }
            var result = builder.ToString();
            return result.Length == 0 ? null : result;
        }

        public static SqlString ExtractNumbersRegEx(SqlString input)
        {
            string[] numbers = Regex.Split(input.Value, @"\D+");
            string result = string.Empty;
            foreach (string value in numbers)
            {
                result += value;
            }
            return result;
        }

        public static SqlString ExtractNumbersRegEx_Join(SqlString input)
        {
            string[] numbers = Regex.Split(input.Value, @"\D+");

            return numbers.Length == 0 ? null : string.Join(string.Empty, numbers);
        }

        public static SqlString ExtractNumbersRegEx_SB(SqlString input)
        {
            string[] numbers = Regex.Split(input.Value, @"\D+");
            var builder = new StringBuilder(numbers.Length);

            for (int i = 0; i < numbers.Length; i++)
            {
                builder.Append(numbers[i]);
            }

            return numbers.Length == 0 ? null : builder.ToString();
        }
    }
}