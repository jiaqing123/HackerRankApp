namespace HackerRankApp.Algorithm;

/// <summary>
/// https://www.hackerrank.com/challenges/organizing-containers-of-balls/problem
/// </summary>
public class OrganizingContainersBalls
{
	public static bool Run(List<List<int>> containers)
	{
		if (containers.Count == 0) return false;

		var firstContainer = containers[0];

		// can be in a single loop
		var containerSizes = containers.Select(i => i.Sum(i => (long)i)).OrderBy(i => i).ToList();

		// extra all values from container, indexing by list index
		// select values with the same index, i.e. column
		// get the sum of column
		//var typeSizes = containers.SelectMany(c => c.Select((e, i) => new { Index = i, Value = (long)e }))
		//	.GroupBy(i => i.Index)
		//	.Select(i => i.Sum(j => j.Value))
		//	.OrderBy(i => i)
		//	.ToList();

		var typeValues = new long[firstContainer.Count];

		foreach (var container in containers)
		{
			for (var i = 0; i < container.Count; i++)
			{
				typeValues[i] += container[i];
			}
		}

		var typeSizes = typeValues.OrderBy(i => i).ToList();

		for (int i = 0; i < containerSizes.Count; i++)
		{
			if (containerSizes[i] == typeSizes[i])
			{
				continue;
			}
			else
			{
				return false;
			}
		}

		return true;
	}
}
