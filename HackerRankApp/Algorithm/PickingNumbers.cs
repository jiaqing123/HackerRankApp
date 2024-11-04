namespace HackerRankApp.Algorithm
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/picking-numbers/problem
    /// </summary>
    public static class PickingNumbers
    {
        public static int Run(List<int> a)
        {
            var groups = a.GroupBy(x => x)
                .ToDictionary(i => i.Key, i => i.Count())
                .OrderBy(i => i.Key)
                .ToList();
            var buffer = new List<KeyValuePair<int, int>>();
            var segments = new List<List<KeyValuePair<int, int>>>();
            var counts = new List<int>();

            for (int i = 0; i < groups.Count; i++)
            {
                if (buffer.Count == 0)
                {
                    buffer.Add(groups[i]);

                    segments.Add(buffer);
                }
                else
                {
                    var diff = Math.Abs(buffer[buffer.Count - 1].Key - groups[i].Key);

                    if (diff <= 1)
                    {
                        buffer.Add(groups[i]);
                    }

                    buffer = new List<KeyValuePair<int, int>>
                    {
                        groups[i]
                    };
                    segments.Add(buffer);
                }
            }

            return segments.Any() ? segments.Select(i => i.Sum(j => j.Value)).Max() : 0;
        }
    }
}
