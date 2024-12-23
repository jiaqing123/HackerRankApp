namespace HackerRankApp.Tests.Algorithm;

public class EmasSupercomputerTests
{
	[Fact]
	public void Run_01()
	{
		List<string> grid = [
			"GGGGGG",
			"GBBBGB",
			"GGGGGG",
			"GGBBGB",
			"GGGGGG"
			];

		int expectancy = 5;

		var handleTask = () => EmasSupercomputer.Run(grid);

		handleTask.Should().NotThrow()
			.Which.Should().Be(expectancy);
	}

	[Fact]
	public void Run_02()
	{
		List<string> grid = [
			"BGBBGB",
			"GGGGGG",
			"BGBBGB",
			"GGGGGG",
			"BGBBGB",
			"BGBBGB"
			];

		int expectancy = 25;

		var handleTask = () => EmasSupercomputer.Run(grid);

		handleTask.Should().NotThrow()
			.Which.Should().Be(expectancy);
	}

	[Fact]
	public void Run_03()
	{
		List<string> grid = [
			"GGGGGG",
			"GGGGGG",
			"GGGGGG",
			"GGGGGG",
			"GGGGGG",
			"GGGGGG"
			];

		int expectancy = 45;

		var handleTask = () => EmasSupercomputer.Run(grid);

		handleTask.Should().NotThrow()
			.Which.Should().Be(expectancy);
	}

	[Fact]
	public void Run_04()
	{
		List<string> grid = [
			"BGBBBB",
			"GGGBBB",
			"BGGBBB",
			"BGGGBB",
			"BBGBBB",
			"BBBBBB"
			];

		int expectancy = 25;

		var handleTask = () => EmasSupercomputer.Run(grid);

		handleTask.Should().NotThrow()
			.Which.Should().Be(expectancy);
	}

	[Fact]
	public void Run_05()
	{
		List<string> grid = [
			"BBBBBGGBGG",
			"GGGGGGGGGG",
			"GGGGGGGGGG",
			"BBBBBGGBGG",
			"BBBBBGGBGG",
			"GGGGGGGGGG",
			"BBBBBGGBGG",
			"GGGGGGGGGG",
			"BBBBBGGBGG",
			"GGGGGGGGGG"
			];

		int expectancy = 85;

		var handleTask = () => EmasSupercomputer.Run(grid);

		handleTask.Should().NotThrow()
			.Which.Should().Be(expectancy);
	}
}
