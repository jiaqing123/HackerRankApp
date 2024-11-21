namespace HackerRankApp.Tests.Algorithm;

public class ViralAdvertisingTests
{
	[Theory]
	[ClassData(typeof(ViralAdvertisingTestData))]
	public void GetTotalLikeds_InputValid_NotThrowException(int days, int expectation)
	{
		var handleTask = () => ViralAdvertising.GetTotalLikeds(days);

		handleTask.Should().NotThrow()
			.Which.Should().Be(expectation);
	}

}
