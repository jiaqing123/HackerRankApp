namespace HackerRankApp.Tests.Algorithm;

public class OrganizingContainersBallsTests
{
	[Theory]
#pragma warning disable xUnit1045 // Avoid using TheoryData type arguments that might not be serializable
	[ClassData(typeof(OrganizingContainersBallsTestData))]
#pragma warning restore xUnit1045 // Avoid using TheoryData type arguments that might not be serializable
	public void Run_InputValid_NotThrowException(List<List<int>> containers, bool expectation)
	{
		var handleTask = () => OrganizingContainersBalls.Run(containers);

		handleTask.Should().NotThrow()
			.Which.Should().Be(expectation);
	}

}
