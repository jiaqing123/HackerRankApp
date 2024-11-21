namespace HackerRankApp.Tests.Algorithm;

public class FairRationsTests
{
	[Fact]
	public void Run_01()
	{
		List<int> loaves = [4, 5, 6, 7];

		string expectation = "4";

		var handleTask = () => FairRations.Run(loaves);

		handleTask.Should().NotThrow()
			.Which.Should().BeEquivalentTo(expectation);
	}

	[Fact]
	public void Run_02()
	{
		List<int> loaves = [2, 3, 4, 5, 6];

		string expectation = "4";

		var handleTask = () => FairRations.Run(loaves);

		handleTask.Should().NotThrow()
			.Which.Should().BeEquivalentTo(expectation);
	}

	[Fact]
	public void Run_03()
	{
		List<int> loaves = [1, 2];

		string expectation = "NO";

		var handleTask = () => FairRations.Run(loaves);

		handleTask.Should().NotThrow()
			.Which.Should().BeEquivalentTo(expectation);
	}
}
