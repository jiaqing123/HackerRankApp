namespace HackerRankApp
{
	public static class HalloweenSales
	{
		public static int Run(int init, int discount, int min, int budget)
		{
			// s[0]=init
			// s[i]=s[i-1]-discount
			// s[i]<=min

			// s[k]=s[0]-discount*[k-1]
			// sum(s[0-k]) = s[0]*(k+1) - discount * (1+k)*k/2

			// 等差数列求和
			// a[k] = a[k-1] + d
			// a[n] = a[m] + d * (n-m)
			// S = (a[1] + a[n]) * ((a[n] - a[1])/d + 1) / 2

			// 等比数列求和
			// a[k] = a[k-1] * q
			// a[n] = a[m] * q^(n-m)
			// S = a[1] * (1 - q^n) / (1 - q)

			// budget can buy 1
			// budget can buy 2
			// budget can buy 1, if 2 then second price is negative


			var count = (int)Math.Ceiling((min - init) / -(double)discount);

			// if decreased to zero, set to zero
			var sum = CalculateSum(init, -discount, count);

			// min = 2; diff = 8; a[k]=4, a[k+1]=-4
			var minPrice = init - discount * (count - 1);
			if (minPrice < 0)
			{
				sum -= minPrice;
				count -= 1;
			}

			var remaining = budget - sum;

			if (remaining > 0)
			{
				// increase count
				var remainingCount = (int)Math.Floor(remaining / (double)min);

				sum += min * remainingCount;
				count += remainingCount;
			}
			else if (remaining < 0)
			{
				// decrease count
				var estimatedCounts = CalculateSolutions(-discount, 2 * init + discount, -2 * budget);
				var estimatedCount = (int)Math.Floor(estimatedCounts.First(x => x > 0 && x <= count));

				sum = CalculateSum(init, -discount, estimatedCount);
				count = estimatedCount;
			}

			// number of games
			return count;
		}

		private static double CalculateSum(int init, int diff, double count) => (init * 2 + diff * (count - 1)) * count / 2;

		private static List<double> CalculateSolutions(double a, double b, double c)
		{
			var sqrt = Math.Sqrt(Math.Pow(b, 2) - 4 * a * c);

			return
			[
				(-b + sqrt) / (2 * a),
				(-b - sqrt) / (2 * a),
			];
		}
	}
}
