namespace HackerRankApp.Tests.Algorithm;

public class JumpingOnCloudsTests
{
	[Theory]
	[ClassData(typeof(JumpingOnCloudsTestData))]
	public void Run_InputValid_NotThrowException(List<int> clouds, int expectation)
	{
		var handleTask = () => JumpingOnClouds.Run(clouds);

		handleTask.Should().NotThrow()
			.Which.Should().Be(expectation);
	}
}
