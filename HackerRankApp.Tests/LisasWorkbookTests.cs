namespace HackerRankApp.Tests
{
	public class LisasWorkbookTests
	{
		[Fact]
		public void Run_01()
		{
			int chapterCount = 2;
			int maxPageProblemCount = 3;
			List<int> chapterProblemCounts = [4, 2];
			int expectation = 1;

			var handleTask = () => LisasWorkbook.Run(chapterCount, maxPageProblemCount, chapterProblemCounts);

			handleTask.Should().NotThrow()
				.Which.Should().Be(expectation);
		}

		[Fact]
		public void Run_02()
		{
			int chapterCount = 5;
			int maxPageProblemCount = 3;
			List<int> chapterProblemCounts = [4, 2, 6, 1, 10];
			int expectation = 4;

			var handleTask = () => LisasWorkbook.Run(chapterCount, maxPageProblemCount, chapterProblemCounts);

			handleTask.Should().NotThrow()
				.Which.Should().Be(expectation);
		}
	}
}
