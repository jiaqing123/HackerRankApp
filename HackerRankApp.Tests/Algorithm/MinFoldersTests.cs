namespace HackerRankApp.Tests.Algorithm
{
	public class MinFoldersTests
	{
		[Fact]
		public void Run_01()
		{
			var cssFiles = 1;
			var jsFiles = 1;
			var readMeFiles = 0;
			var capacity = 1;

			var result = MinFolders.Run(cssFiles, jsFiles, readMeFiles, capacity);

			result.Should().Be(2);
		}
	}
}
