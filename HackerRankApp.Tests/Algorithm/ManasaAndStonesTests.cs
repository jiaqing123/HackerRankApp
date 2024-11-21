namespace HackerRankApp.Tests.Algorithm;

public class ManasaAndStonesTests
{
	[Fact]
	public void Run_01()
	{
		// example not counts first stone 0. others count the first stone 0
		int count = 3; // in the example, it is 2, which is correct
		int diff1 = 2;
		int diff2 = 3;
		// 0 2 4; 0 2 5; 0 3 5; 0 3 6
		List<int> expectation = [4, 5, 6];

		var handleTask = () => ManasaAndStones.Run(count, diff1, diff2);

		handleTask.Should().NotThrow()
			.Which.Should().BeEquivalentTo(expectation, opts => opts.WithStrictOrdering());
	}

	[Fact]
	public void Run_02()
	{
		// example, it counts non-zero stone
		int count = 3;
		int diff1 = 1;
		int diff2 = 2;

		// 0 1 2; 0 1 3; 0 2 3; 0 2 4;
		List<int> expectation = [2, 3, 4];

		var handleTask = () => ManasaAndStones.Run(count, diff1, diff2);

		handleTask.Should().NotThrow()
			.Which.Should().BeEquivalentTo(expectation, opts => opts.WithStrictOrdering());
	}

	[Fact]
	public void Run_03()
	{
		int count = 4;
		int diff1 = 10;
		int diff2 = 100;

		List<int> expectation = [30, 120, 210, 300];

		var handleTask = () => ManasaAndStones.Run(count, diff1, diff2);

		handleTask.Should().NotThrow()
			.Which.Should().BeEquivalentTo(expectation, opts => opts.WithStrictOrdering());
	}

	[Fact]
	public void Run_04()
	{
		int count = 4;
		int diff1 = 2;
		int diff2 = 3;

		List<int> expectation = [6, 7, 8, 9];

		var handleTask = () => ManasaAndStones.Run(count, diff1, diff2);

		handleTask.Should().NotThrow()
			.Which.Should().BeEquivalentTo(expectation, opts => opts.WithStrictOrdering());
	}
}
