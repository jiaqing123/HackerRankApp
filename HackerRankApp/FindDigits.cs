namespace HackerRankApp
{
	public static class FindDigits
	{
		private const char Zero = '0';

		public static int GetDivisorCount(int number)
		{
			var digits = GetDigits(number);

			var count = digits.Where(i => i.Key != Zero && number % (i.Key - Zero) == 0)
				.Sum(i => i.Value);

			return count;
		}

		private static Dictionary<char, int> GetDigits(int number) => number.ToString().GroupBy(i => i).ToDictionary(i => i.Key, i => i.Count());
	}
}
