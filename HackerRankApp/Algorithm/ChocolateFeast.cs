namespace HackerRankApp.Algorithm
{
	/// <summary>
	/// https://www.hackerrank.com/challenges/chocolate-feast/problem
	/// </summary>
	public static class ChocolateFeast
	{
		public static int Run(int initial, int cost, int rate)
		{
			// initial: initial fund
			// cost: cost per bar
			// rate: wrapper exchanged for one bar

			var purchaseCount = initial / cost;

			var (exchanged, _) = ExchangeRecursively(purchaseCount, rate, 0);

			// total bars
			return purchaseCount + exchanged;
		}

		/// <summary>
		/// Get amount
		/// </summary>
		/// <param name="amount">Chocolate</param>
		/// <param name="rate">Wrapper to Chocolate Rate</param>
		/// <param name="partial">Wrapper</param>
		/// <returns>Number of chocolate exchanged, Number of wrapper left</returns>
		private static (int, int) ExchangeRecursively(int amount, int rate, int partial)
		{
			// 15, 3, 2, 9
			// 15 / 3 = 5
			// 5 / 2 = 2...1
			// 2 / 2 = 1
			// 1 + 1 = 2
			// 2 / 2 = 1
			// 9

			// eat all of the chocolate
			partial += amount;
			amount = 0;

			// exchange wrapper to chocolate
			var (exchanged, remainder) = Math.DivRem(partial, rate);
			amount = exchanged;
			partial = remainder;

			// if wrapper can exchange for chocolate
			if (amount + partial >= rate)
			{
				var (exchange1, remainder1) = ExchangeRecursively(amount, rate, partial);

				amount += exchange1;
				partial = remainder1;
			}

			return (amount, partial);
		}
	}
}
