namespace HackerRankApp.Algorithm;

/// <summary>
/// https://www.hackerrank.com/challenges/minimum-distances/problem
/// </summary>
public static class MinimumDistances
{
	public static int Run(List<int> arr)
	{
		var groups = arr.Select((e, i) => new { Value = e, Index = i })
			.GroupBy(i => i.Value, i => i.Index)
			.ToDictionary(i => i.Key, i => i.ToList());

		var distances = groups.Select(i => GetMinimumDifferences(i.Value))
			.Where(i => i > 0)
			.ToList();

		if (distances.Any())
		{
			return distances.Min();
		}

		return -1;
	}

	private static int GetMinimumDifferences(List<int> numbers)
	{
		if (numbers.Count == 1)
		{
			return -1;
		}

		//numbers.Sort();

		var min = int.MaxValue;

		for (int i = 0; i < numbers.Count - 1; i++)
		{
			var diff = numbers[i + 1] - numbers[i];

			min = int.Min(min, diff);
		}

		return min;
	}
}
