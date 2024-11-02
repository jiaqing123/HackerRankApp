namespace HackerRankApp.Completed
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/strange-advertising/problem
    /// </summary>
    public static class ViralAdvertising
    {
        public static int GetTotalLikeds(int days)
        {
            var shareds = new Dictionary<int, int>();

            _ = GetShareds(days, shareds);

            var likeds = shareds.Sum(i => GetLikeds(i.Value));

            return likeds;
        }

        private static int GetShareds(int day, Dictionary<int, int> shareds)
        {
            if (day == 1)
            {
                shareds.Add(1, 5);

                return 5;
            }

            var shared = GetShareds(day - 1, shareds) / 2 * 3;

            shareds.Add(day, shared);

            return shared;
        }

        private static int GetLikeds(int shareds) => shareds / 2;
    }
}
