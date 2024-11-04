namespace HackerRankApp.Algorithm
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/kaprekar-numbers/problem
    /// </summary>
    public static class ModifiedKaprekarNumbers
    {
        private const string InvalidRange = "INVALID RANGE";

        public static string Run(int start, int end)
        {
            // n^2 = (n^2/100 + n^2 % 100) = n
            var numbers = SearchNumbers(start, end);

            if (numbers.Any())
            {
                return numbers.Select(i => i.ToString()).Aggregate((i, j) => $"{i} {j}");
            }

            return InvalidRange;
        }

        private static IEnumerable<int> SearchNumbers(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                if (IsModifiedKaprekarNumber(i)) yield return i;
            }
        }

        private static int GetNumberOfDigits(int number)
        {
            //var count = Math.Log10(number);

            //if (count == (int)count)
            //{
            //	count += 1;
            //}
            //else
            //{
            //	count = Math.Ceiling(count);
            //}

            return number.ToString().Length;
        }

        private static bool IsModifiedKaprekarNumber(int number)
        {
            var digitCount = number.ToString().Length;

            var l = 0d;
            var r = 0d;

            // a = n * n
            // b = n

            // l * Math.Pow(10, digitCount) + r = (l + r)^2
            // l^2 + 2*l*r + r^2

            var a = l * Math.Pow(10, digitCount) + r;
            var b = l + r;


            var sq = (long)Math.Pow(number, 2);

            var divisor = Math.Pow(10, GetNumberOfDigits(number));

            var left = (int)(sq / divisor);
            var right = (int)(sq % divisor);

            return number == left + right;
        }
    }
}
