namespace HackerRankApp.Algorithm;

/// <summary>
/// https://www.hackerrank.com/challenges/two-pluses/problem?isFullScreen=true
/// </summary>
public static class EmasSupercomputer
{
	private record Cell
	{
		public int Row { get; init; }

		public int Column { get; init; }

		public bool IsGood { get; init; }
	}

	private record Grid
	{
		public Cell this[int row, int column] { get => Cells[row][column]; }

		public List<List<Cell>> Cells { get; init; } = [];

		public int RowCount { get { return Cells.Count; } }

		public int ColumnCount { get { return Cells[0].Count; } }
	}

	private record Plus
	{
		public int Row { get; init; }

		public int Column { get; init; }

		public int Radius { get; init; }

		public int Area { get => 1 + 4 * Radius; }

		public List<Cell> Cells { get; init; } = [];
	}

	private record PlusCollection
	{
		public List<Plus> this[int radius] { get => RadiusGroups[radius]; }

		public List<Plus> Pluses { get; init; } = [];

		public Dictionary<int, List<Plus>> RadiusGroups { get; init; } = [];
	}

	private record Combination
	{
		public int One { get; init; }

		public int Other { get; init; }

		public int Product
		{
			get
			{
				_product ??= (1 + 4 * One) * (1 + 4 * Other);
				return _product.Value;
			}
		}

		private int? _product;
	}

	public static int Run(List<string> gridStr)
	{
		// Si = 1 + 4i
		// Smax = Sm * Sn (Min(m-n))

		var grid = GetGrid(gridStr);

		var collection = GetPluses(grid);

		var combinations = GetRadiusCombination(collection);

		var max = GetMaxProduct(collection, combinations);

		return max;
	}

	private static Grid GetGrid(List<string> gridStr)
	{
		var grid = new Grid();

		for (int n = 0; n < gridStr.Count; n++)
		{
			var row = gridStr[n];
			var cellRow = new List<Cell>();

			for (int m = 0; m < row.Length; m++)
			{
				var col = row[m];

				if (col == 'G')
				{
					cellRow.Add(new Cell
					{
						IsGood = true,
						Column = m,
						Row = n
					});
				}
				else
				{
					cellRow.Add(new Cell
					{
						IsGood = false,
						Column = m,
						Row = n
					});
				}
			}

			grid.Cells.Add(cellRow);
		}

		return grid;
	}

	private static PlusCollection GetPluses(Grid grid)
	{
		var collection = new PlusCollection();

		for (int n = 0; n < grid.RowCount; n++)
		{
			for (int m = 0; m < grid.ColumnCount; m++)
			{
				var plusesAt = GetPlusesAt(grid, n, m);

				foreach (var plus in plusesAt)
				{
					collection.Pluses.Add(plus);

					if (collection.RadiusGroups.TryGetValue(plus.Radius, out List<Plus>? value))
					{
						value.Add(plus);
					}
					else
					{
						collection.RadiusGroups.Add(plus.Radius, [plus]);
					}
				}
			}
		}

		return collection;
	}

	private static IEnumerable<Cell> GetCornerCells(Grid grid, int n, int m, int radius)
	{
		if (radius == 0)
		{
			yield return grid[n, m];
		}
		else
		{
			yield return grid[n - radius, m];
			yield return grid[n, m + radius];
			yield return grid[n + radius, m];
			yield return grid[n, m - radius];
		}
	}

	private static List<Plus> GetPlusesAt(Grid grid, int n, int m)
	{
		if (!grid[n, m].IsGood) return [];

		var pluses = new List<Plus>
		{
			new() { Row = n, Column = m, Radius = 0, Cells = [.. GetCornerCells(grid, n, m, 0)] },
		};

		var maxRadius = new List<int>
		{
			n, m, grid.RowCount - n - 1, grid.ColumnCount - m - 1
		}.Min();

		for (int radius = 1; radius <= maxRadius; radius++)
		{
			var cells = GetCornerCells(grid, n, m, radius);

			if (cells.Any(e => !e.IsGood)) break;

			pluses.Add(new Plus { Row = n, Column = m, Radius = radius, Cells = [.. pluses[^1].Cells.Union(cells)] });
		}

		return pluses;
	}

	private static IEnumerable<Combination> GetRadiusCombination(PlusCollection collection)
	{
		var keys = collection.RadiusGroups.Keys
			.OrderByDescending(e => e)
			.ToList();

		for (int i = 0; i < keys.Count; i++)
		{
			for (int j = i; j < keys.Count; j++)
			{
				if (i == j)
				{
					if (collection[i].Count > 1)
					{
						yield return new Combination()
						{
							One = keys[i],
							Other = keys[j]
						};
					}
				}
				else
				{
					yield return new Combination()
					{
						One = keys[i],
						Other = keys[j]
					};
				}
			}
		}
	}

	private static int GetMaxProduct(PlusCollection collection, IEnumerable<Combination> combinations)
	{
		//  1, 5, 9, 13
		var ordered = combinations
			.OrderByDescending(e => e.Other)
			.OrderByDescending(e => e.One)
			.OrderByDescending(e => e.Product).ToList();

		foreach (var combination in ordered)
		{
			if (combination.One == combination.Other)
			{
				var group = collection[combination.One];

				for (var i = 0; i < group.Count - 1; i++)
				{
					var one = group[i];

					for (var j = i + 1; j < group.Count; j++)
					{
						var other = group[j];

						if (!IsOverlapped(one, other))
						{
							return one.Area * other.Area;
						}
					}
				}
			}
			else
			{
				var group1 = collection[combination.One];
				var group2 = collection[combination.Other];

				for (var i = 0; i < group1.Count; i++)
				{
					var one = group1[i];

					for (var j = 0; j < group2.Count; j++)
					{
						var other = group2[j];

						if (!IsOverlapped(one, other))
						{
							return one.Area * other.Area;
						}
					}
				}
			}
		}

		return 0;
	}

	private static bool IsOverlapped_01(Plus one, Plus other)
	{
		foreach (var cell in one.Cells)
		{
			if (other.Cells.Contains(cell)) return true;
		}

		return false;
	}

	private static bool IsOverlapped(Plus one, Plus other)
	{
		var rowDiff = Math.Abs(one.Row - other.Row) - 1;
		var colDiff = Math.Abs(one.Column - other.Column) - 1;

		var maxDis = one.Radius + other.Radius;

		if (rowDiff >= maxDis) return false;

		if (colDiff >= maxDis) return false;

		var maxRadius = Math.Max(one.Radius, other.Radius);

		if (rowDiff >= maxRadius && colDiff >= 0) return false;

		if (colDiff >= maxRadius && rowDiff >= 0) return false;

		var minRadius = Math.Min(one.Radius, other.Radius);

		if (rowDiff >= minRadius && colDiff >= minRadius) return false;

		return true;
	}
}
