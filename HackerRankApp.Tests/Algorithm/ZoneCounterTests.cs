namespace HackerRankApp.Tests.Algorithm;

public class ZoneCounterTests
{
	private readonly ZoneCounter _zoneCounter;

	public ZoneCounterTests()
	{
		_zoneCounter = new ZoneCounter();
	}

	[Fact]
	public void Run_01()
	{
		int[][] areas = [['1', '1', '0', '0', '0'], ['1', '1', '0', '0', '1'], ['0', '0', '0', '1', '1'], ['0', '0', '0', '0', '0'], ['1', '0', '1', '0', '1']];

		var expected = 5;

		var handleTask = () => _zoneCounter.CountZones(areas);

		handleTask.Should().NotThrow()
			.Which.Should().Be(expected);
	}

	[Fact]
	public void Run_02()
	{
		int[][] areas = [[]];

		var expected = 0;

		var handleTask = () => _zoneCounter.CountZones(areas);

		handleTask.Should().NotThrow()
			.Which.Should().Be(expected);
	}

	[Fact]
	public void Run_03()
	{
		int[][] areas = [];

		var expected = 0;

		var handleTask = () => _zoneCounter.CountZones(areas);

		handleTask.Should().NotThrow()
			.Which.Should().Be(expected);
	}
}
