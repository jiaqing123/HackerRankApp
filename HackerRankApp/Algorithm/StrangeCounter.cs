namespace HackerRankApp.Algorithm
{
	/// <summary>
	/// https://www.hackerrank.com/challenges/strange-code/problem
	/// </summary>
	public static class StrangeCounter
	{
		public static long Run(long time)
		{
			// an, m value: an-index of m
			// 等比数列求和
			// a[k] = a[k-1] * q
			// a[n] = a[m] * q^(n-m)
			// S = a[1] * (1 - q^n) / (1 - q)

			var S = new Dictionary<long, long>();
			var a = new Dictionary<long, long>();

			a[1] = 3;

			var q = 2;

			var n = (long)Math.Ceiling(Math.Log(1 - time * (1 - q) / (double)a[1]) / Math.Log(q));

			S[n - 1] = (long)(a[1] * (1 - Math.Pow(2, n - 1)) / (1 - q));
			a[n] = a[1] * (long)Math.Pow(q, n - 1);

			var remain = time - S[n - 1];
			var val = a[n] - remain + 1;

			return val;
		}
	}
}
