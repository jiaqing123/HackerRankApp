namespace HackerRankApp.Problems;

/// <summary>
/// https://www.hackerrank.com/challenges/larrys-array/problem?isFullScreen=true
/// </summary>
public static class LarrysArray
{
	/// <summary>
	/// a sequence of natural numbers incrementing from 1
	/// </summary>
	/// <param name="sequence"></param>
	/// <returns></returns>
	public static string Run(List<int> sequence)
	{
		var sortable = false;
		var sortedIndex = 0;
		var maxStartIndex = sequence.Count - 3;

		while (sortedIndex < sequence.Count)
		{
			var target = sortedIndex + 1;

			if (sequence[sortedIndex] == target)
			{
				sortable = true;

				sortedIndex++;
			}
			else
			{
				sortable = false;

				// search target number: sorted+1
				var (startIndex, targetIndex) = SearchStartNumber(sequence, target);

				if (startIndex > maxStartIndex)
				{
					break;
				}

				SwapElementsToStartIndex(sequence, startIndex, targetIndex);
			}
		}

		return sortable ? "YES" : "NO";
	}

	/// <summary>
	/// Search target index and swap subsequence start index
	/// </summary>
	/// <param name="sequence"></param>
	/// <param name="target"></param>
	/// <returns></returns>
	private static (int, int) SearchStartNumber(List<int> sequence, int target)
	{
		var index = sequence.IndexOf(target);

		var distance = index - (target - 1);

		if (distance < 2)
		{
			return (target - 1, index);
		}

		return (index - 2, index);
	}

	private static void SwapElements(List<int> sequence, int startIndex)
	{
		var a = sequence[startIndex];
		var b = sequence[startIndex + 1];
		var c = sequence[startIndex + 2];

		sequence[startIndex] = b;
		sequence[startIndex + 1] = c;
		sequence[startIndex + 2] = a;
	}

	/// <summary>
	/// Swap targetIndex to startIndex
	/// </summary>
	/// <param name="sequence"></param>
	/// <param name="startIndex"></param>
	/// <param name="targetIndex"></param>
	private static void SwapElementsToStartIndex(List<int> sequence, int startIndex, int targetIndex)
	{
		var target = sequence[targetIndex];

		while (target != sequence[startIndex])
		{
			SwapElements(sequence, startIndex);
		}
	}
}
