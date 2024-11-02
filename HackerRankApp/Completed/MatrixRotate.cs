namespace HackerRankApp.Completed
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/matrix-rotation-algo/problem
    /// </summary>
    public static class MatrixRotate
    {
        private static readonly double Degree90 = Math.PI * (90 / 180d);
        private static readonly double Sin90 = Math.Sin(Degree90);
        private static readonly double Cos90 = Math.Cos(Degree90);

        public static List<List<int>> Rotate(List<List<int>> target)
        {
            // what if the middle one is different
            // 4 5 8
            // 2 4 1
            // 1 9 7

            // rotate clockwise
            var result = new List<List<int>>
            {
                new() {0, 0, 0},
                new() {0, 0, 0},
                new() {0, 0, 0}
            };
            var size = target.Count;

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    var (x1, y1) = Rotate90(x, -y, size / 2);

                    result[x1][-y1] = target[x][y];
                }
            }

            return result;
        }

        /// <summary>
        /// x1 = x0 * cos(delta) - y0 * sin(delta)
        /// y1 = y0 * cos(delta) + x0 * sin(delta)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        private static (int, int) Rotate90(int x, int y, int k)
        {
            var x1 = Math.Round((x - k) * Cos90 - (y + k) * Sin90) + k;
            var y1 = Math.Round((y + k) * Cos90 + (x - k) * Sin90) - k;

            return ((int)x1, (int)y1);
        }

    }
}
