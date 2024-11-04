namespace HackerRankApp.Algorithm
{
	/// <summary>
	/// https://www.hackerrank.com/challenges/lisa-workbook/problem?isFullScreen=true
	/// </summary>
	public static class LisasWorkbook
	{
		public static int Run(int chapterCount, int maxPageProblemCount, List<int> chapterProblemCounts)
		{
			var specialProblemCount = 0;
			var startingPage = 1;

			for (int chapterNumber = 1; chapterNumber <= chapterCount; chapterNumber++)
			{
				var maxChapterProblemNumber = chapterProblemCounts[chapterNumber - 1];

				var chapterPages = (int)Math.Ceiling(maxChapterProblemNumber / (double)maxPageProblemCount);

				for (int pageIndex = 0; pageIndex < chapterPages; pageIndex++)
				{
					var pageNumber = startingPage + pageIndex;

					var pageProblemStartNumber = 1 + maxPageProblemCount * pageIndex;

					var pageProblemEndNumber = maxPageProblemCount * (pageIndex + 1);
					if (pageProblemEndNumber > maxChapterProblemNumber) pageProblemEndNumber = maxChapterProblemNumber;

					if (pageProblemStartNumber <= pageNumber && pageNumber <= pageProblemEndNumber)
					{
						specialProblemCount++;
					}
				}

				startingPage += chapterPages;
			}

			// number of special maxChapterProblemNumber
			return specialProblemCount;
		}
	}
}
