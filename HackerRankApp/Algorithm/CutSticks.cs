namespace HackerRankApp.Algorithm;

/// <summary>
/// https://www.hackerrank.com/challenges/cut-the-sticks/problem
/// </summary>
public static class CutSticks
{
	public static List<int> Run(List<int> sticks)
	{
		if (!sticks.Any()) return new List<int>();

		var total = sticks.Count;

		var counts = sticks.GroupBy(i => i)
			.ToDictionary(i => i.Key, i => i.Count())
			.OrderBy(i => i.Key)
			.Select(i =>
			{
				var tmp = total;

				total -= i.Value;

				return tmp;
			})
			.ToList();

		return counts;
	}
}
