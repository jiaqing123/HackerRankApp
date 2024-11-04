namespace HackerRankApp.Algorithm
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/cavity-map/problem
    /// </summary>
    public static class CavityMap
    {
        private const char CavitySymbol = 'X';

        public static List<string> Run(List<string> grid)
        {
            if (!Verify(grid)) return grid;

            var gridInt = CreateMap(grid).ToList();
            var map = CreateMap(grid).ToList();

            for (int row = 1; row < gridInt.Count - 1; row++)
            {
                for (int col = 1; col < gridInt[row].Length - 1; col++)
                {
                    if (IsCavity(row, col, gridInt))
                    {
                        map[row][col] = CavitySymbol;
                    }
                }
            }

            var denoted = CreateGrid(map).ToList();

            return denoted;
        }

        private static IEnumerable<int[]> CreateMap(List<string> grid)
        {
            foreach (var item in grid)
            {
                yield return item.Select(i => i - '0').ToArray();
            }
        }

        private static IEnumerable<string> CreateGrid(List<int[]> map)
        {
            foreach (var item in map)
            {
                yield return new string(item.Select(i => i == CavitySymbol ? (char)i : (char)('0' + i)).ToArray());
            }
        }

        private static bool IsCavity(int row, int col, List<int[]> grid)
        {
            var val = grid[row][col];

            if (grid[row - 1][col] >= val) return false;

            if (grid[row][col + 1] >= val) return false;

            if (grid[row][col - 1] >= val) return false;

            if (grid[row + 1][col] >= val) return false;

            return true;
        }

        private static bool Verify(List<string> grid)
        {
            if (grid.Count < 3) return false;

            if (grid[0].Length < 3) return false;

            return true;
        }
    }
}
