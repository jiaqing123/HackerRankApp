namespace HackerRankApp.Tests
{
	public class MinimumDistancesTests
	{
		[Fact]
		public void Run_01()
		{
			List<int> arr = [3, 2, 1, 2, 3];
			int expection = 2;

			var handleTask = () => MinimumDistances.Run(arr);

			handleTask.Should().NotThrow()
				.Which.Should().Be(expection);
		}
	}
}
