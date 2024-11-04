namespace HackerRankApp.Tests.Algorithm
{
	public class CavityMapTests
	{
		[Fact]
		public void Run_01()
		{
			List<string> grid = [
				"989",
				"191",
				"111"
				];

			List<string> expectation = [
				"989",
				"1X1",
				"111"
				];

			var handleTask = () => CavityMap.Run(grid);

			handleTask.Should().NotThrow()
				.Which.Should().BeEquivalentTo(expectation, opts => opts.WithStrictOrdering());
		}

		[Fact]
		public void Run_02()
		{
			List<string> grid = [
				"1112",
				"1912",
				"1892",
				"1234"
				];

			List<string> expectation = [
				"1112",
				"1X12",
				"18X2",
				"1234"
				];

			var handleTask = () => CavityMap.Run(grid);

			handleTask.Should().NotThrow()
				.Which.Should().BeEquivalentTo(expectation, opts => opts.WithStrictOrdering());
		}
	}
}
