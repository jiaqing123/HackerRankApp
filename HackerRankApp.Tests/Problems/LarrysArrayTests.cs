using HackerRankApp.Problems;

namespace HackerRankApp.Tests.Problems;

public class LarrysArrayTests
{
	[Fact]
	public void Run_01()
	{
		List<int> sequence = [1, 6, 5, 2, 4, 3];

		string expectation = "YES";

		var handleTask = () => LarrysArray.Run(sequence);

		handleTask.Should().NotThrow()
			.Subject.Should().BeEquivalentTo(expectation);
	}

	[Fact]
	public void Run_02()
	{
		List<int> sequence = [3, 1, 2];

		string expectation = "YES";

		var handleTask = () => LarrysArray.Run(sequence);

		handleTask.Should().NotThrow()
			.Subject.Should().BeEquivalentTo(expectation);
	}

	[Fact]
	public void Run_03()
	{
		List<int> sequence = [1, 3, 4, 2];

		string expectation = "YES";

		var handleTask = () => LarrysArray.Run(sequence);

		handleTask.Should().NotThrow()
			.Subject.Should().BeEquivalentTo(expectation);
	}

	[Fact]
	public void Run_04()
	{
		List<int> sequence = [1, 2, 3, 5, 4];

		string expectation = "NO";

		var handleTask = () => LarrysArray.Run(sequence);

		handleTask.Should().NotThrow()
			.Subject.Should().BeEquivalentTo(expectation);
	}
}
