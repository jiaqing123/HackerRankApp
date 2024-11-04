namespace HackerRankApp.Tests.Algorithm
{
	public class StrangeCounterTests
	{
		[Fact]
		public void Run_01()
		{
			long time = 4L;

			long expectation = 6L;

			var handleTask = () => StrangeCounter.Run(time);

			handleTask.Should().NotThrow()
				.Which.Should().Be(expectation);
		}

		[Fact]
		public void Run_02()
		{
			long time = 17L;

			long expectation = 5L;

			var handleTask = () => StrangeCounter.Run(time);

			handleTask.Should().NotThrow()
				.Which.Should().Be(expectation);
		}
	}
}
