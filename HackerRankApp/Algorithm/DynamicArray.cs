namespace HackerRankApp.Algorithm;

/// <summary>
/// https://www.hackerrank.com/challenges/dynamic-array/problem
/// </summary>
public static class DynamicArray
{
	public static List<int> Run(int size, List<List<int>> queries)
	{
		// size: number of array in queries
		// queries: operations on result arr
		// arr: results of Type 2 operations

		// query: 1 0 5
		// query Type 1, value 5, target f(x)/f(0), arr[(x^lastAnswer) % 2] = a [0] = y
		// a[0] = [5]

		// query: 1 1 7
		// query Type 1, value 7, arr[(x^lastAnswer) % 2] = a [1]
		// a[1] = [7]

		// query: 1 0 3
		// query Type 1, value 7, arr[(x^lastAnswer) % 2] = a[0]
		// a[0] = [5, 3]

		// query: 2 1 0
		// query Type 2, value 0, arr[(x^lastAnswer) % 2] = a[1]; assign a[1] to lastAnswer
		// lastAnswer = 7

		// query: 2 1 1
		// query Type 2, value 1, arr[(x^lastAnswer) % 2] = a[0], assign a[0][1] to lastAnswer
		// lastAnswer = 3

		var answers = new List<int>();
		var lastAnswer = 0;

		var arr = new List<List<int>>();
		for (int i = 0; i < size; i++)
		{
			arr.Add(new List<int>());
		}

		foreach (var query in queries)
		{
			if (query[0] == 1)
			{
				lastAnswer = PerformQuery1(query[1], query[2], arr, lastAnswer);
			}
			else if (query[0] == 2)
			{
				lastAnswer = PerformQuery2(query[1], query[2], arr, lastAnswer, answers);
			}
		}

		return answers;
	}

	private static int PerformQuery1(int x, int y, List<List<int>> arr, int lastAnswer)
	{
		var idx = (x ^ lastAnswer) % arr.Count;

		arr[idx].Add(y);

		return lastAnswer;
	}

	private static int PerformQuery2(int x, int y, List<List<int>> arr, int lastAnswer, List<int> answers)
	{
		var idx = (x ^ lastAnswer) % arr.Count;

		lastAnswer = arr[idx][y % arr[idx].Count];

		answers.Add(lastAnswer);

		return lastAnswer;
	}
}
