namespace HackerRankApp.Tests.Algorithm
{
	public class DynamicArrayTests
	{
		[Fact]
		public void Run_01()
		{
			var size = 2;
			List<List<int>> queries =
			[
				[1, 0, 5],
				[1, 1, 7],
				[1, 0, 3],
				[2, 1, 0],
				[2, 1, 1],
			];

			List<int> expectation = [7, 3];

			var handleTask = () => DynamicArray.Run(size, queries);

			handleTask.Should().NotThrow()
				.Which.Should().BeEquivalentTo(expectation, opts => opts.WithStrictOrdering());
		}
	}
}
