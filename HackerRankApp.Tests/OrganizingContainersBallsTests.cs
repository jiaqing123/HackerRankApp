namespace HackerRankApp.Tests
{
	public class OrganizingContainersBallsTests
	{
		[Theory]
		[ClassData(typeof(OrganizingContainersBallsTestData))]
		public void Run_InputValid_NotThrowException(List<List<int>> containers, bool expectation)
		{
			var handleTask = () => OrganizingContainersBalls.Run(containers);

			handleTask.Should().NotThrow()
				.Which.Should().Be(expectation);
		}

	}
}
