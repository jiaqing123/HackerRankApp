namespace HackerRankApp.Tests.Algorithm;

public class BombermanGameTests
{
	[Fact]
	public void Run_01()
	{
		int time = 1;
		List<string> grid = [
			"...",
			".O.",
			"..."
		];

		List<string> expectation = [
			"...",
			".O.",
			"..."
		];

		var handleTask = () => BombermanGame.Run(time, grid);

		handleTask.Should().NotThrow()
			.Which.Should().BeEquivalentTo(expectation, opts => opts.WithStrictOrdering());
	}

	[Fact]
	public void Run_02()
	{
		int time = 2;
		List<string> grid = [
			"...",
			".O.",
			"..."
		];

		List<string> expectation = [
			"OOO",
			"OOO",
			"OOO"
		];

		var handleTask = () => BombermanGame.Run(time, grid);

		handleTask.Should().NotThrow()
			.Which.Should().BeEquivalentTo(expectation, opts => opts.WithStrictOrdering());
	}

	[Fact]
	public void Run_03()
	{
		int time = 3;
		List<string> grid = [
			"...",
			".O.",
			"..."
		];

		List<string> expectation = [
			"O.O",
			"...",
			"O.O"
		];

		var handleTask = () => BombermanGame.Run(time, grid);

		handleTask.Should().NotThrow()
			.Which.Should().BeEquivalentTo(expectation, opts => opts.WithStrictOrdering());
	}

	//[Fact]
	//public void Run_04()
	//{
	//	int time = 3;
	//	List<string> grid = [
	//		"...",
	//		".O.",
	//		"..."
	//	];

	//	List<string> expectation = [
	//		"O.O",
	//		"...",
	//		"O.O"
	//	];

	//	for (int i = 0; i < 100; i++)
	//	{
	//		time += 4 * i;

	//		var handleTask = () => BombermanGame.Run(time, grid);

	//		handleTask.Should().NotThrow()
	//			.Which.Should().BeEquivalentTo(expectation, opts => opts.WithStrictOrdering());
	//	}
	//}

	[Fact]
	public void Run_05()
	{
		int time = 5;
		List<string> grid = [
			".......",
			"...O.O.",
			"....O..",
			"..O....",
			"OO...OO",
			"OO.O...",
		];

		List<string> expectation = [
			".......",
			"...O.O.",
			"...OO..",
			"..OOOO.",
			"OOOOOOO",
			"OOOOOOO",
		];

		var handleTask = () => BombermanGame.Run(time, grid);

		handleTask.Should().NotThrow()
			.Which.Should().BeEquivalentTo(expectation, opts => opts.WithStrictOrdering());
	}

	//[Fact]
	//public void Run_06()
	//{
	//	int time = 5;
	//	List<string> grid = [
	//		".......",
	//		"...O.O.",
	//		"....O..",
	//		"..O....",
	//		"OO...OO",
	//		"OO.O...",
	//	];

	//	List<string> expectation = [
	//		".......",
	//		"...O.O.",
	//		"...OO..",
	//		"..OOOO.",
	//		"OOOOOOO",
	//		"OOOOOOO",
	//	];

	//	for (int i = 0; i < 100; i++)
	//	{
	//		time += 4 * i;

	//		var handleTask = () => BombermanGame.Run(time, grid);

	//		handleTask.Should().NotThrow()
	//			.Which.Should().BeEquivalentTo(expectation, opts => opts.WithStrictOrdering());

	//	}
	//}
}
