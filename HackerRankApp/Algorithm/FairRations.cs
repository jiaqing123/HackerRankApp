namespace HackerRankApp.Algorithm;

/// <summary>
/// https://www.hackerrank.com/challenges/fair-rations/problem
/// </summary>
public static class FairRations
{
	private const string No = "NO";

	public static string Run(List<int> loaves)
	{
		var firstOdd = -1;
		var count = 0;

		for (var i = 0; i < loaves.Count; i++)
		{
			if (IsEven(loaves[i])) continue;

			if (firstOdd == -1)
			{
				firstOdd = i;
			}
			else
			{
				count += (i - firstOdd) * 2;
				firstOdd = -1;
			}
		}

		return firstOdd == -1 ? count.ToString() : No;
	}

	private static bool IsEven(int val) => val % 2 == 0;
}
