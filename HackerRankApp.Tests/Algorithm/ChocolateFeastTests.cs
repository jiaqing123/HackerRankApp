namespace HackerRankApp.Tests.Algorithm;

public class ChocolateFeastTests
{
	[Theory]
	[InlineData(15, 3, 2, 9)]
	public void Run_01(int initial, int cost, int rate, int expectation)
	{
		var handleTask = () => ChocolateFeast.Run(initial, cost, rate);

		handleTask.Should().NotThrow()
			.Which.Should().Be(expectation);
	}
}
