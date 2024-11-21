using HackerRankApp.InProgress;

namespace HackerRankApp.Tests.InProgress;

public class TurnstileTests
{
	[Fact]
	public void Run_01()
	{
		List<int> times = [0, 0, 1, 5];
		List<int> directions = [0, 1, 1, 0];

		List<int> expectation = [2, 0, 1, 5];

		var handleTask = () => Turnstile.Run(times, directions);

		handleTask.Should().NotThrow()
			.Which.Should().BeEquivalentTo(expectation);
	}

#pragma warning disable
	[Theory]
	[ClassData(typeof(TurnstileTestData))]
	public void Run_02(List<int> times, List<int> directions, List<int> expectation)
	{
		var handleTask = () => Turnstile.Run(times, directions);

		handleTask.Should().NotThrow()
			.Which.Should().BeEquivalentTo(expectation);
	}
#pragma warning enable
}
