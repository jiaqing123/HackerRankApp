namespace HackerRankApp.Algorithm
{
	/// <summary>
	/// https://www.hackerrank.com/challenges/manasa-and-stones/problem
	/// </summary>
	public static class ManasaAndStones
	{
		public static List<int> Run(int count, int diff1, int diff2)
		{
			if (diff1 == diff2) return [diff1 * (count - 1)];

			var small = diff1 < diff2 ? diff1 : diff2;
			var large = diff1 < diff2 ? diff2 : diff1;

			var start = small * (count - 1);
			var end = large * (count - 1);
			var step = large - small;

			if (start == 0) start += step;

			var faces = new List<int>();

			for (var i = start; i <= end; i += step)
			{
				faces.Add(i);
			}

			return faces;
		}
	}
}
