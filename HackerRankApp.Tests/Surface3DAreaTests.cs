namespace HackerRankApp.Tests
{
	public class Surface3DAreaTests
	{
		[Fact]
		public void Run_01()
		{
			List<List<int>> area = [
				[1]
				];

			int expectation = 6;

			var handleTask = () => Surface3DArea.Run(area);

			handleTask.Should().NotThrow()
				.Which.Should().Be(expectation);
		}

		[Fact]
		public void Run_02()
		{
			List<List<int>> area = [
				[1, 3, 4],
				[2, 2, 3],
				[1, 2, 4],
				];

			int expectation = 60;

			var handleTask = () => Surface3DArea.Run(area);

			handleTask.Should().NotThrow()
				.Which.Should().Be(expectation);
		}
	}
}
