namespace HackerRankApp.Tests.Algorithm;

public class UtopianTreeTests
{
	[Theory]
	[ClassData(typeof(UtopianTreeTestData))]
	public void CalculateHeight_InputValid_NotThrowException(int period, int expectation)
	{
		var handleTask = () => UtopianTree.CalculateHeight(period);

		handleTask.Should().NotThrow()
			.Which.Should().Be(expectation);
	}
}
