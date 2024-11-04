namespace HackerRankApp.Tests.Algorithm
{
	public class DeliveryManagementSystemTests
	{
		[Fact]
		public void Run_01()
		{
			int cityNodes = 4;
			List<int> cityFrom = [1, 2, 2];
			List<int> cityTo = [2, 3, 4];
			int company = 1;

			List<int> expectation = [2, 3, 4];

			var handleTask = () => DeliveryManagementSystem.Run(cityNodes, cityFrom, cityTo, company);

			handleTask.Should().NotThrow()
				.Which.Should().BeEquivalentTo(expectation, opts => opts.WithStrictOrdering());
		}

		[Theory]
		[ClassData(typeof(DeliveryManagementSystemTestData))]
		public void Run_02(int cityNodes, List<int> cityFrom, List<int> cityTo, int company, List<int> expectation)
		{
			var handleTask = () => DeliveryManagementSystem.Run(cityNodes, cityFrom, cityTo, company);

			handleTask.Should().NotThrow()
				.Which.Should().BeEquivalentTo(expectation, opts => opts.WithStrictOrdering());
		}
	}
}
