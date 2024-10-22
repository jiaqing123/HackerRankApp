namespace HackerRankApp.Tests
{
	public class ServiceLaneTests
	{
		[Fact]
		public void Run_01()
		{
			List<int> widths = [2, 3, 1, 2, 3, 2, 3, 3];
			List<List<int>> cases = [[0, 3], [4, 6], [6, 7], [3, 5], [0, 7]];
			List<int> expectation = [1, 2, 3, 2, 1];

			var handleTask = () => ServiceLane.Run(widths, cases);

			handleTask.Should().NotThrow()
				.Which.Should().BeEquivalentTo(expectation, opts => opts.WithStrictOrdering());
		}
	}
}
