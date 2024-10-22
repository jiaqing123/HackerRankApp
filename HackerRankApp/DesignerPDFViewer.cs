namespace HackerRankApp
{
	public static class DesignerPDFViewer
	{
		public static int Run(List<int> heights, string word)
		{
			var offset = (int)'a';
			var height = -1;

			if (word.Any())
			{
				height = word.ToArray()
					.Select(i => i - offset)
					.Select(i => heights[i])
					.Max();
			}
			else
			{
				height = 0;
			}

			return 1 * word.Length * height;
		}
	}
}
