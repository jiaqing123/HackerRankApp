namespace HackerRankApp.Algorithm;

public static class MaxHourGlassSum
{
	public static int Run(List<List<int>> arr)
	{
		// i, i+1, i+2
		// _, i+j+1,
		// i+j*2, i+j*2+1, i+j*2+2
		var rows = arr.Count;
		if (rows < 3) return 0;

		var columns = arr[0].Count;
		if (columns < 3) return 0;

		var sums = new List<int>();

		for (var i = 0; i < columns - 2; i++)
		{
			for (var j = 0; j < rows - 2; j++)
			{
				var sum = arr[j][i] + arr[j][i + 1] + arr[j][i + 2]
					+ arr[j + 1][i + 1] +
					arr[j + 2][i] + arr[j + 2][i + 1] + arr[j + 2][i + 2];
				sums.Add(sum);
			}
		}

		return sums.Max();
	}
}
