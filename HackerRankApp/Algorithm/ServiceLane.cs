namespace HackerRankApp.Algorithm
{
	/// <summary>
	/// https://www.hackerrank.com/challenges/service-lane/problem
	/// </summary>
	public static class ServiceLane
	{
		public static List<int> Run(List<int> widths, List<List<int>> paths)
		{
			// max width of each case
			var minWidths = paths.Select(i => GetMinimumWidth(widths, i[0], i[1]))
				.ToList();

			return minWidths;
		}

		private static int GetMinimumWidth(List<int> widths, int start, int end)
			=> widths.GetRange(start, end - start + 1).Min();
	}
}
