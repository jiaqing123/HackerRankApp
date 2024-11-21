namespace HackerRankApp.Algorithm;

/// <summary>
/// https://www.hackerrank.com/challenges/absolute-permutation/problem
/// </summary>
public class AbsolutePermutation
{
	private static readonly List<int> EmptyPermutation = [-1];

	public static List<int> Run(int upperBound, int differences)
	{
		if (differences > upperBound - 1) return EmptyPermutation;

		if (differences == 0) return CreateList(upperBound).ToList();

		var per = new int[upperBound + 1];
		var hash = new HashSet<int>();
		var invalid = false;

		for (int i = 1; i <= upperBound; i++)
		{
			var lower = i - differences;
			var upper = i + differences;

			if (lower > 0 && !hash.Contains(lower))
			{
				per[i] = lower;
			}
			else if (upper <= upperBound && !per.Contains(upper))
			{
				per[i] = upper;
			}
			else
			{
				invalid = true;
				break;
			}

			hash.Add(per[i]);
		}

		if (invalid) return EmptyPermutation;

		return [.. per[1..]];
	}

	private static IEnumerable<int> CreateList(int upperBound)
	{
		for (int i = 1; i <= upperBound; i++)
		{
			yield return i;
		}
	}
}
