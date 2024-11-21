namespace HackerRankApp.Tests.Algorithm;

public class TaumAndBdayTests
{
	[Theory]
	[ClassData(typeof(TaumAndBdayTestData))]
	public void Run_InputValid_NotThrowException(int blackCount, int whiteCount, int blackCost, int whiteCost, int conversionCost, int expectation)
	{
		var handleTask = () => TaumAndBday.Run(blackCount, whiteCount, blackCost, whiteCost, conversionCost);

		handleTask.Should().NotThrow()
			.Which.Should().Be(expectation);
	}
}
