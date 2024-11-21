namespace HackerRankApp.Algorithm;

/// <summary>
/// https://www.hackerrank.com/challenges/bomber-man/problem?isFullScreen=true
/// </summary>
public static class BombermanGame
{
	private const char EmptyChar = '.';
	private const char BombChar = 'O';

	private class Cell
	{
		public int Row { get; init; }
		public int Column { get; init; }
	}

	private class CellCollection
	{
		public List<List<Cell>> Cells { get; init; } = [];

		public HashSet<Cell> Empties { get; private set; } = [];

		public HashSet<Cell> Bombs { get; private set; } = [];

		public Cell? this[int i, int j] { get => i >= 0 && i < Cells.Count && j >= 0 && j < Cells[i].Count ? Cells[i][j] : null; }

		public int Count { get => Cells.Sum(i => i.Count); }

		public void Swap()
		{
			(Bombs, Empties) = (Empties, Bombs);
		}
	}

	public static List<string> Run(int time, List<string> initial)
	{
		// Need to carefully identify each state. 
		// Otherwise, it cannot find the regular pattern
		// T: 0
		// 00000
		// 00000
		// 00100
		// 00000
		// 00000

		// T: 1, observe
		// 00000
		// 00000
		// 00100
		// 00000
		// 00000

		// T: 2, plant on previous 0

		// T: 3, dentonate
		// 11111
		// 11011
		// 10001
		// 11011
		// 11111

		// T: 4, plant on previous 0
		// plant

		// T: 5, dentonate
		// 00000
		// 00000
		// 00100
		// 00000
		// 00000

		if (time <= 1) return initial;

		if (initial.Count == 0) return initial;

		if (time % 2 == 0) return GetFullGrid(initial);

		var cells = GetCells(initial);

		var time1 = (time - 3) % 4;

		for (var i = 0; i <= time1; i += 2)
		{
			Detonate(cells);
		}

		return GetGrid(cells);
	}

	private static void Detonate(CellCollection cells)
	{
		foreach (var cell in cells.Bombs.ToList())
		{
			var neighbours = GetNeighbours(cell, cells);

			foreach (var neighbor in neighbours)
			{
				if (cells.Empties.Remove(neighbor))
				{
					cells.Bombs.Add(neighbor);
				}
			}
		}

		cells.Swap();
	}

	private static CellCollection GetCells(List<string> initial)
	{
		var cells = new CellCollection();

		for (int i = 0; i < initial.Count; i++)
		{
			var row = new List<Cell>();

			cells.Cells.Add(row);

			for (int j = 0; j < initial[i].Length; j++)
			{
				var cell = new Cell { Row = i, Column = j, };

				row.Add(cell);

				if (initial[i][j] == EmptyChar)
				{
					cells.Empties.Add(cell);
				}
				else if (initial[i][j] == BombChar)
				{
					cells.Bombs.Add(cell);
				}
			}
		}

		return cells;
	}

	private static List<string> GetFullGrid(List<string> initial)
	{
		var full = new List<string>();

		foreach (string row in initial)
		{
			full.Add(new string(Enumerable.Repeat(BombChar, row.Length).ToArray()));
		}

		return full;
	}

	private static List<string> GetGrid(CellCollection cells)
	{
		var grid = new List<string>();

		foreach (var row in cells.Cells)
		{
			grid.Add(new string(row.Select(i => cells.Empties.Contains(i) ? EmptyChar : BombChar).ToArray()));
		}

		return grid;
	}

	private static IEnumerable<Cell> GetNeighbours(Cell cell, CellCollection cells)
	{
		var neighbour = cells[cell.Row - 1, cell.Column];
		if (neighbour != null) yield return neighbour;

		neighbour = cells[cell.Row, cell.Column + 1];
		if (neighbour != null) yield return neighbour;

		neighbour = cells[cell.Row + 1, cell.Column];
		if (neighbour != null) yield return neighbour;

		neighbour = cells[cell.Row, cell.Column - 1];
		if (neighbour != null) yield return neighbour;
	}
}
