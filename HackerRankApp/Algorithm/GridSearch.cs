namespace HackerRankApp.Algorithm
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/the-grid-search/problem
    /// </summary>
    public static class GridSearch
    {
        private record MatchRange
        {
            public static readonly MatchRange Empty = new(-1, -1);

            public int Left { get; init; }

            public int Right { get; init; }

            public MatchRange(int left, int right)
            {
                Left = left;
                Right = right;
            }
        }

        private const string Yes = "YES";
        private const string No = "NO";

        public static string Run(List<string> grid, List<string> pattern)
        {
            if (!Verify(grid, pattern)) return No;

            var found = false;
            var maxRow = grid.Count - pattern.Count;

            for (var i = 0; i <= maxRow; i++)
            {
                var ranges = SearchLineMultiple(grid[i], pattern[0]);

                foreach (var range in ranges)
                {
                    var row = i + 1;

                    var searchResult = default(MatchRange);

                    for (var j = 1; j < pattern.Count; row++, j++)
                    {
                        searchResult = SearchLine(grid[row], pattern[j], range);

                        if (searchResult == MatchRange.Empty) break;
                    }

                    if (searchResult != MatchRange.Empty)
                    {
                        found = true;
                        break;
                    }
                }
            }

            return found ? Yes : No;
        }

        // Test 9(runtime), 15
        private static IEnumerable<MatchRange> SearchLineMultiple(string line, string patternLine)
        {
            var left = 0;
            var right = left + patternLine.Length;

            while (right <= line.Length)
            {
                var matched = true;

                for (var i = 0; i < patternLine.Length; i++)
                {
                    if (line[left + i] != patternLine[i])
                    {
                        matched = false;
                        break;
                    }
                }

                if (matched) yield return new(left, right);

                left++;
                right++;
            }
        }

        private static MatchRange SearchLine(string line, string patternLine, MatchRange range)
        {
            var window = line[range.Left..range.Right];

            if (window == patternLine) return range;

            return MatchRange.Empty;
        }

        private static bool Verify(List<string> grid, List<string> pattern)
        {
            if (grid.Count == 0 || pattern.Count == 0) return false;

            if (grid.Count < pattern.Count) return false;

            if (grid[0].Length < pattern[0].Length) return false;

            return true;
        }
    }
}
