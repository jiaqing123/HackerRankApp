using System.Numerics;

namespace HackerRankApp
{
	public static class ExtraLongFactorials
	{
		public static BigInteger CalculateResult(int n)
		{
			return Calculate(n);
		}

		private static BigInteger Calculate(int n)
		{
			if (n == 1) return BigInteger.One;

			return Calculate(n - 1) * new BigInteger(n);
		}
	}
}
