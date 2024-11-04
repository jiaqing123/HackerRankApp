namespace HackerRankApp.Algorithm
{
	/// <summary>
	/// https://www.hackerrank.com/challenges/utopian-tree/problem
	/// </summary>
	public static class UtopianTree
	{
		public static int CalculateHeight(int period)
		{
			if (period == 0)
			{
				return 1;
			}
			else if (period % 2 == 1)
			{
				return CalculateHeight(period - 1) * 2;
			}
			else
			{
				return CalculateHeight(period - 1) + 1;
			}
		}
	}
}
