namespace HackerRankApp.Algorithm;

/// <summary>
/// https://www.hackerrank.com/challenges/beautiful-triplets/problem
/// </summary>
public static class BeautifulTriplets
{
	public static int Run(int diff, List<int> arr)
	{
		if (arr.Count < 3) return 0;

		// increasing sequenc of arr. may be the same
		// d is positive

		// Key is the value, Value is the list of index in arr
		var groups = arr.Select((e, i) => new { Index = i, Value = e })
			.GroupBy(e => e.Value, e => e.Index)
			.ToDictionary(e => e.Key, e => e.ToList());

		var count = 0;
		var keys = groups.Keys.Order();
		var maxKey = keys.Last();

		foreach (var key0 in groups.Keys.Order())
		{
			var key1 = key0 + diff;

			if (key1 < maxKey && groups.ContainsKey(key1))
			{
				var key2 = key1 + diff;

				if (key2 <= maxKey && groups.ContainsKey(key2))
				{
					count += groups[key0].Count * groups[key1].Count * groups[key2].Count;
				}
			}
		}

		return count;
	}
}
