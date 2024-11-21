namespace HackerRankApp.Algorithm;

/// <summary>
/// https://www.hackerrank.com/challenges/permutation-equation/problem
/// </summary>
public static class SequenceEquation
{
	public static List<int> GetValues(List<int> numbers)
	{
		var values = new List<int>();

		for (int i = 1; i <= numbers.Count; i++)
		{
			values.Add(FindOrderByValueTwice(numbers, i));
		}

		return values;
	}

	private static int FindOrderByValue(List<int> numbers, int x)
	{
		var result = numbers.FindIndex((i) => i == x);

		return result + 1;
	}

	private static int FindOrderByValueTwice(List<int> numbers, int x)
	{
		var result = FindOrderByValue(numbers, x);

		var result2 = FindOrderByValue(numbers, result);

		return result2;
	}
}
