namespace HackerRankApp.Tests.Algorithm;

public class FlatlandSpaceStationsTests
{
	[Fact]
	public void Run_01()
	{
		int numberOfCities = 3;
		int[] stationLocations = [1];

		int expectation = 1;

		var handleTask = () => FlatlandSpaceStations.Run(numberOfCities, stationLocations);

		handleTask.Should().NotThrow()
			.Which.Should().Be(expectation);
	}

	[Fact]
	public void Run_02()
	{
		int numberOfCities = 5;
		int[] stationLocations = [0, 4];

		int expectation = 2;

		var handleTask = () => FlatlandSpaceStations.Run(numberOfCities, stationLocations);

		handleTask.Should().NotThrow()
			.Which.Should().Be(expectation);
	}

	[Fact]
	public void Run_03()
	{
		int numberOfCities = 6;
		int[] stationLocations = [0, 1, 2, 4, 3, 5];

		int expectation = 0;

		var handleTask = () => FlatlandSpaceStations.Run(numberOfCities, stationLocations);

		handleTask.Should().NotThrow()
			.Which.Should().Be(expectation);
	}
}
