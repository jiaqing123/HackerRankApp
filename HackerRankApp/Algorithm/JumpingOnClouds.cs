namespace HackerRankApp.Algorithm
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/jumping-on-the-clouds/problem
    /// </summary>
    public static class JumpingOnClouds
    {
        public static int Run(List<int> clouds)
        {
            var thunders = GetThunderIndices(clouds);
            var steps = 0;
            var pos = 0;

            for (int i = 0; i < thunders.Count; i++)
            {
                var length = thunders[i] - pos - 1;

                var full = length / 2;
                var half = length % 2;

                steps += full + half;

                pos = thunders[i] + 1;

                steps++;
            }

            if (pos == clouds.Count - 1)
            {
                return steps;
            }
            else
            {
                var length = clouds.Count - pos - 1;

                var full = length / 2;
                var half = length % 2;

                steps += full + half;
            }

            return steps;
        }

        private static List<int> GetThunderIndices(List<int> clouds)
        {
            var indices = new List<int>();

            _ = clouds.Where((e, i) => { if (e == 1) indices.Add(i); return true; }).ToList();

            return indices;
        }
    }
}
