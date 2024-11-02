namespace HackerRankApp.Completed
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/bigger-is-greater/problem
    /// </summary>
    public static class BiggerIsGreater
    {
        private const string NoAnswer = "no answer";

        public static string Run(string original)
        {
            if (original.Length < 2) return NoAnswer;

            var chars = original.ToCharArray();

            var (pivotIndex, pivotChar) = FindPivot(chars);

            if (pivotIndex == -1) return NoAnswer;

            Array.Sort(chars, pivotIndex + 1, chars.Length - pivotIndex - 1);

            var (replacementIndex, _) = FindSmallestBigger(chars, pivotChar, pivotIndex + 1);

            SwapChars(chars, pivotIndex, replacementIndex);

            var smallestBigger = new string(chars);

            return smallestBigger;
        }

        /// <summary>
        /// Find priot. Return (index, value)
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        /// <example>
        /// dkhc returns (0, d)
        /// </example>
        private static (int, char) FindPivot(char[] chars)
        {
            for (int i = chars.Length - 1; i > 0; i--)
            {
                if (chars[i - 1] < chars[i])
                {
                    return (i - 1, chars[i - 1]);
                }
            }

            return (-1, char.MinValue);
        }

        /// <summary>
        /// Find smallest bigger from sorted chars.
        /// </summary>
        /// <param name="chars"></param>
        /// <param name="starting"></param>
        /// <returns></returns>
        /// <remarks>
        /// chars is sorted on and after starting index
        /// </remarks>
        private static (int, char) FindSmallestBigger(char[] chars, char comparer, int starting)
        {
            for (int i = starting; i < chars.Length; i++)
            {
                if (chars[i] > comparer)
                {
                    return (i, chars[i]);
                }
            }

            return (starting, chars[starting]);
        }

        private static void SwapChars(char[] chars, int source, int target)
        {
            var tmp = chars[source];

            chars[source] = chars[target];

            chars[target] = tmp;
        }
    }
}
