namespace HackerRankApp.Algorithm
{
	public class ZoneCounter
	{
		private class AreaInfo
		{
			public int Width { get; set; }

			public int Length { get; set; }

			public int[][] Areas { get; set; } = [];
		}

		private enum AreaTypes
		{
			Empty = 0,
			Occupied = 1,
		}

		private class SearchResult
		{
			public AreaTypes? AreaType { get; set; }

			public bool Searched { get; set; }
		}

		public int CountZones(int[][] areas)
		{
			var (width, length) = GetDimension(areas);

			var searched = CreateSearchArea(width, length);

			var areaInfo = new AreaInfo()
			{
				Areas = areas,
				Width = width,
				Length = length,
			};

			var count = 0;

			for (int row = 0; row < length; row++)
			{
				for (int col = 0; col < width; col++)
				{
					// if type=Occupied, increase by 1
					var result = SearchArea(areaInfo, row, col, searched);

					if (result.AreaType == AreaTypes.Occupied)
					{
						count++;
					}
				}
			}

			return count;
		}

		private List<List<bool>> CreateSearchArea(int width, int length)
		{
			var searched = new List<List<bool>>();

			for (int i = 0; i < length; i++)
			{
				var row = new List<bool>();

				for (int j = 0; j < width; j++)
				{
					row.Add(false);
				}

				searched.Add(row);
			}

			return searched;
		}

		private AreaTypes GetAreaType(int row, int column, AreaInfo areaInfo)
		{
			var type = areaInfo.Areas[row][column];

			var a = type - '0';

			return (AreaTypes)a;
		}

		private (int, int) GetDimension(int[][] areas)
		{
			var width = areas.Length;
			var height = 0;

			if (areas.Length != 0)
			{
				height = areas[0].Length;
			}

			return (width, height);
		}

		private SearchResult SearchArea(AreaInfo areaInfo, int row, int column, List<List<bool>> searched)
		{
			if (searched[row][column] == true)
			{
				return new SearchResult { Searched = true };
			}
			else
			{
				searched[row][column] = true;
			}

			if (GetAreaType(row, column, areaInfo) == AreaTypes.Empty) return new SearchResult { AreaType = AreaTypes.Empty };

			// search right
			if (column + 1 < areaInfo.Width)
			{
				var result_right = SearchArea(areaInfo, row, column + 1, searched);
			}

			// search left
			if (column - 1 >= 0)
			{
				var result_left = SearchArea(areaInfo, row, column - 1, searched);
			}

			// search down
			if (row + 1 < areaInfo.Length)
			{
				var result_down = SearchArea(areaInfo, row + 1, column, searched);
			}

			// search up
			if (row - 1 >= 0)
			{
				var result_up = SearchArea(areaInfo, row - 1, column, searched);
			}

			return new SearchResult { Searched = true, AreaType = AreaTypes.Occupied };
		}
	}
}
