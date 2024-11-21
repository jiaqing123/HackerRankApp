namespace HackerRankApp.Algorithm;

public static class DegreeOfArray
{
	public static int Run(List<int> arr)
	{
		var grps = arr.GroupBy(i => i)
			.ToDictionary(i => i.Key, i => i.Count());

		var max = grps.Max(i => i.Value);

		var digits = grps.Where(i => i.Value == max);

		var lengths = new List<int>();

		foreach (var digit in digits)
		{
			var indexes = new List<int>();

			_ = arr.Where((e, i) =>
			{
				if (e == digit.Key)
				{
					indexes.Add(i);

					return true;
				}

				return false;
			}).ToList();

			var start = indexes.Min();
			var end = indexes.Max();

			lengths.Add(end - start + 1);
		}

		return lengths.Min();
	}
}
