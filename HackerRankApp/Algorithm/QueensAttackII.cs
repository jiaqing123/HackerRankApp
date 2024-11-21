namespace HackerRankApp.Algorithm;

/// <summary>
/// https://www.hackerrank.com/challenges/queens-attack-2/problem
/// </summary>
public static class QueensAttackII
{
	public static int Run(int dimension, int obstacleCount, int queenRow, int queenColumn, List<List<int>> obstacles)
	{
		var area = 0;

		// 4 lines
		// y=x+b
		// y=-x+b
		// y=b (any x, parallel to x)
		// 0=x+b (any y, parallel to y)

		// obstacles will not in the same line

		foreach (var k in new List<int> { 1, -1, 0 })
		{
			area += Line05(queenRow, queenColumn, k, dimension, obstacles);
		}

		//area += Line01(queenRow, queenColumn, dimension, obstacles);
		//area += Line02(queenRow, queenColumn, dimension, obstacles);
		//area += Line03(queenRow, queenColumn, dimension, obstacles);
		area += Line04(queenRow, queenColumn, dimension, obstacles);

		return area;
	}

	private static int GetUnitsBetween(int x1, int y1, int x2, int y2)
	{
		if (x1 == x2)
		{
			return Math.Abs(y2 - y1);
		}
		else if (y2 == y1)
		{
			return Math.Abs(x2 - x1);
		}
		else
		{
			return (int)Math.Round(Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)) / Math.Sqrt(2));
		}
	}

	private static int Line01(int x0, int y0, int dimension, List<List<int>> obstacles)
	{
		// y=x+b
		var b = y0 - x0;

		Func<int, int> fx = (x) => x + b;
		Func<int, int> fy = (y) => y - b;

		var blockers = obstacles.Where(i => i[1] == fx(i[0])).ToList();

		// point 1
		var x1 = 0;
		var y1 = 0;
		var blockerLeftFound = false;
		if (blockers.Any(i => i[0] < x0))
		{
			blockerLeftFound = true;

			x1 = blockers.Where(i => i[0] < x0).Max(i => i[0]);
			y1 = blockers.Where(i => i[0] == x1).First()[1];
		}
		else
		{
			y1 = 1;
			x1 = fy(y1);
			if (x1 < 1)
			{
				x1 = 1;
				y1 = fx(x1);
			}
		}

		// point 2
		var x2 = 0;
		var y2 = 0;
		var blockerRightFound = false;
		if (blockers.Any(i => i[0] > x0))
		{
			blockerRightFound = true;

			x2 = blockers.Where(i => i[0] > x0).Min(i => i[0]);
			y2 = blockers.Where(i => i[0] == x2).First()[1];
		}
		else
		{
			x2 = dimension;
			y2 = fx(x2);
			if (y2 > dimension)
			{
				y2 = dimension;
				x2 = fy(y2);
			}
		}

		// inclusive
		var units = GetUnitsBetween(x1, y1, x2, y2) + 1;

		if (units > 0)
		{
			if (blockerLeftFound)
			{
				units--;
			}

			if (blockerRightFound)
			{
				units--;
			}

			units--;
		}

		if (blockers.Count > 0)
		{
			foreach (var blocker in blockers)
			{
				obstacles.Remove(blocker);
			}
		}

		return units;
	}

	private static int Line02(int x0, int y0, int dimension, List<List<int>> obstacles)
	{
		// y = -x + b
		var b = y0 + x0;

		Func<int, int> fx = (x) => -x + b;
		Func<int, int> fy = (y) => -y + b;

		var blockers = obstacles.Where(i => i[1] == fx(i[0])).ToList();

		// point 1
		var x1 = 0;
		var y1 = 0;
		var blockerLeftFound = false;
		if (blockers.Any(i => i[0] < x0))
		{
			blockerLeftFound = true;

			x1 = blockers.Where(i => i[0] < x0).Max(i => i[0]);
			y1 = blockers.Where(i => i[0] == x1).First()[1];
		}
		else
		{
			x1 = 1;
			y1 = fx(x1);
			if (y1 > dimension)
			{
				y1 = dimension;
				x1 = fy(y1);
			}
		}

		// point 2
		var x2 = 0;
		var y2 = 0;
		var blockerRightFound = false;
		if (blockers.Any(i => i[0] > x0))
		{
			blockerRightFound = true;

			x2 = blockers.Where(i => i[0] > x0).Min(i => i[0]);
			y2 = blockers.Where(i => i[0] == x2).First()[1];
		}
		else
		{
			x2 = dimension;
			y2 = fx(x2);
			if (y2 < 1)
			{
				y2 = 1;
				x2 = fy(y2);
			}
		}


		var units = GetUnitsBetween(x1, y1, x2, y2) + 1;

		if (units > 0)
		{
			if (blockerLeftFound)
			{
				units--;
			}

			if (blockerRightFound)
			{
				units--;
			}

			// remove some
			// itself
			units -= 1;
		}

		if (blockers.Count > 0)
		{
			foreach (var blocker in blockers)
			{
				obstacles.Remove(blocker);
			}
		}

		return units;
	}

	private static int Line03(int x0, int y0, int dimension, List<List<int>> obstacles)
	{
		// y=b (any x, parallel to x)
		var b = y0;

		Func<int, int> fx = (x) => b;

		// because points at k=1/k=-1 are removed
		var blockers = obstacles.Where(i => i[1] == fx(i[0])).ToList();

		// point 1
		var x1 = 0;
		var y1 = 0;
		var blockerLeftFound = false;
		if (blockers.Any(i => i[0] < x0))
		{
			blockerLeftFound = true;

			x1 = blockers.Where(i => i[0] < x0).Max(i => i[0]);
			y1 = blockers.Where(i => i[0] == x1).First()[1];
		}
		else
		{
			x1 = 1;
			y1 = fx(x1);
		}

		// point 2
		var x2 = 0;
		var y2 = 0;
		var blockerRightFound = false;
		if (blockers.Any(i => i[0] > x0))
		{
			blockerRightFound = true;

			x2 = blockers.Where(i => i[0] > x0).Min(i => i[0]);
			y2 = blockers.Where(i => i[0] == x2).First()[1];
		}
		else
		{
			x2 = dimension;
			y2 = fx(b);
		}

		var units = GetUnitsBetween(x1, y1, x2, y2) + 1;

		if (units > 0)
		{
			if (blockerLeftFound)
			{
				units--;
			}

			if (blockerRightFound)
			{
				units--;
			}

			// remove some
			// itself
			units -= 1;
		}

		if (blockers.Count > 0)
		{
			foreach (var blocker in blockers)
			{
				obstacles.Remove(blocker);
			}
		}

		return units;
	}

	private static int Line04(int x0, int y0, int dimension, List<List<int>> obstacles)
	{
		// 0=x+b (any y, parallel to y)
		var b = -x0;

		Func<int, int> fy = (y) => -b;

		// because points at k=1/k=-1 are removed
		var blockers = obstacles.Where(i => i[0] == fy(i[1])).ToList();

		// point 1
		var x1 = 0;
		var y1 = 0;
		var blockerDownFound = false;
		if (blockers.Any(i => i[1] < y0))
		{
			blockerDownFound = true;

			y1 = blockers.Where(i => i[1] < y0).Max(i => i[1]);
			x1 = blockers.Where(i => i[1] == y1).First()[0];
		}
		else
		{
			y1 = 1;
			x1 = fy(y1);
		}

		// point 2
		var x2 = 0;
		var y2 = 0;
		var blockerUpFound = false;
		if (blockers.Any(i => i[1] > y0))
		{
			blockerUpFound = true;

			y2 = blockers.Where(i => i[1] > y0).Min(i => i[1]);
			x2 = blockers.Where(i => i[1] == y2).First()[0];
		}
		else
		{
			y2 = dimension;
			x2 = fy(y1);
		}

		var units = GetUnitsBetween(x1, y1, x2, y2) + 1;

		if (units > 0)
		{
			if (blockerDownFound)
			{
				units--;
			}

			if (blockerUpFound)
			{
				units--;
			}

			// remove some
			// itself
			units -= 1;
		}

		if (blockers.Count > 0)
		{
			foreach (var blocker in blockers)
			{
				obstacles.Remove(blocker);
			}
		}

		return units;
	}

	private static int Line05(int x0, int y0, int k, int dimension, List<List<int>> obstacles)
	{
		// y=kx+b
		var b = y0 - k * x0;

		Func<int, int> fx = (x) => k * x + b;
		Func<int, int> fy = (y) => (y - b) / k;

		var blockers = obstacles.Where(i => i[1] == fx(i[0])).ToList();

		// point 1
		var x1 = 0;
		var y1 = 0;
		var blockerLeftFound = false;
		if (blockers.Any(i => i[0] < x0))
		{
			blockerLeftFound = true;

			x1 = blockers.Where(i => i[0] < x0).Max(i => i[0]);
			y1 = blockers.Where(i => i[0] == x1).First()[1];
		}
		else
		{
			x1 = 1;
			y1 = fx(x1);
			if (y1 < 1)
			{
				y1 = 1;
				x1 = fy(y1);
			}
			else if (y1 > dimension)
			{
				y1 = dimension;
				x1 = fy(y1);
			}
		}

		// point 2
		var x2 = 0;
		var y2 = 0;
		var blockerRightFound = false;
		if (blockers.Any(i => i[0] > x0))
		{
			blockerRightFound = true;

			x2 = blockers.Where(i => i[0] > x0).Min(i => i[0]);
			y2 = blockers.Where(i => i[0] == x2).First()[1];
		}
		else
		{
			x2 = dimension;
			y2 = fx(x2);
			if (y2 < 1)
			{
				y2 = 1;
				x2 = fy(y2);
			}
			else if (y2 > dimension)
			{
				y2 = dimension;
				x2 = fy(y2);
			}
		}

		// inclusive
		var units = GetUnitsBetween(x1, y1, x2, y2) + 1;

		if (units > 0)
		{
			if (blockerLeftFound)
			{
				units--;
			}

			if (blockerRightFound)
			{
				units--;
			}

			units--;
		}

		if (blockers.Count > 0)
		{
			foreach (var blocker in blockers)
			{
				obstacles.Remove(blocker);
			}
		}

		return units;
	}
}
