namespace HackerRankApp.Algorithm
{
	/// <summary>
	/// https://www.hackerrank.com/challenges/flatland-space-stationPositions/problem
	/// </summary>
	public static class FlatlandSpaceStations
	{
		public static int Run(int numberOfCities, int[] stationLocations)
		{
			var locations = stationLocations.ToList();
			locations.Sort();

			var max = locations[0];

			for (var i = 0; i < locations.Count - 1; i++)
			{
				var distance = (locations[i + 1] - locations[i]) / 2;

				if (distance > max)
				{
					max = distance;
				}
			}

			if (locations[^1] != numberOfCities - 1)
			{
				var distance = numberOfCities - 1 - locations[^1];

				if (distance > max)
				{
					max = distance;
				}
			}

			return max;
		}
	}
}
