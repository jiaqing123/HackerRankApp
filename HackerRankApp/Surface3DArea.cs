namespace HackerRankApp
{
	/// <summary>
	/// https://www.hackerrank.com/challenges/3d-surface-area/problem
	/// </summary>
	public static class Surface3DArea
	{
		private enum Direction2D
		{
			Up, Down, Left, Right,
		}

		private class Block
		{
			public int Row { get; init; }

			public int Column { get; init; }

			public int Height { get; init; }

			public Dictionary<Direction2D, int?> DirectionAreas { get; init; } = new Dictionary<Direction2D, int?> {
				{ Direction2D.Up, null },		// Row - 1
				{ Direction2D.Right, null },	// Column + 1
				{ Direction2D.Down, null },		// Row + 1
				{ Direction2D.Left, null },		// Column - 1
			};
		}

		public static int Run(List<List<int>> area)
		{
			var surface = 0;

			var blocks = CreateBlocks(area);

			for (var i = 0; i < blocks.Count; i++)
			{
				for (var j = 0; j < blocks[i].Count; j++)
				{
					surface += CalculateArea(blocks[i][j], blocks);
				}
			}

			return surface;
		}

		private static int CalculateArea(Block block, List<List<Block>> blocks)
		{
			var area = 0;

			if (block.Height == 0)
			{
				foreach (var directionArea in block.DirectionAreas)
				{
					if (directionArea.Value.HasValue) continue;

					block.DirectionAreas[directionArea.Key] = 0;
				}

				return area;
			}

			// Top and Bottom
			area = 2;

			foreach (var directionArea in block.DirectionAreas)
			{
				if (directionArea.Value.HasValue)
				{
					area += directionArea.Value.Value;
				}
				else
				{
					area += CalculateAreaBetweenNeighbour(block, directionArea.Key, blocks);
				}
			}

			return area;
		}

		private static int CalculateAreaBetweenNeighbour(Block block, Direction2D direction, List<List<Block>> blocks)
		{
			var neighbourDirection = default(Direction2D);
			var neighbourRow = default(int);
			var neighbourColumn = default(int);

			switch (direction)
			{
				case Direction2D.Up:
					neighbourDirection = Direction2D.Down;
					neighbourRow = block.Row - 1;
					neighbourColumn = block.Column;
					break;
				case Direction2D.Down:
					neighbourDirection = Direction2D.Up;
					neighbourRow = block.Row + 1;
					neighbourColumn = block.Column;
					break;
				case Direction2D.Left:
					neighbourDirection = Direction2D.Right;
					neighbourRow = block.Row;
					neighbourColumn = block.Column - 1;
					break;
				case Direction2D.Right:
					neighbourDirection = Direction2D.Left;
					neighbourRow = block.Row;
					neighbourColumn = block.Column + 1;
					break;
				default:
					break;
			}

			if (neighbourRow >= 0 && neighbourRow < blocks.Count)
			{
				if (neighbourColumn >= 0 && neighbourColumn < blocks[neighbourRow].Count)
				{
					var neighbour = blocks[neighbourRow][neighbourColumn];

					if (neighbour.Height == block.Height)
					{
						neighbour.DirectionAreas[neighbourDirection] = 0;
						block.DirectionAreas[direction] = 0;
					}
					else if (neighbour.Height > block.Height)
					{
						neighbour.DirectionAreas[neighbourDirection] = neighbour.Height - block.Height;
						block.DirectionAreas[direction] = 0;
					}
					else
					{
						neighbour.DirectionAreas[neighbourDirection] = 0;
						block.DirectionAreas[direction] = block.Height - neighbour.Height;
					}
				}
			}

			// no neighbour on that direction
			if (!block.DirectionAreas[direction].HasValue)
			{
				block.DirectionAreas[direction] = block.Height;
			}

			return block.DirectionAreas[direction]!.Value;
		}

		private static List<List<Block>> CreateBlocks(List<List<int>> area)
		{
			List<List<Block>> blocks = [];

			for (var i = 0; i < area.Count; i++)
			{
				List<Block> rowBlocks = [];

				for (var j = 0; j < area[i].Count; j++)
				{
					rowBlocks.Add(new Block
					{
						Row = i,
						Column = j,
						Height = area[i][j]
					});
				}

				blocks.Add(rowBlocks);
			}

			return blocks;
		}
	}
}
