namespace HackerRankApp.Algorithm
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/repeated-string/problem
    /// </summary>
    public static class DuplicatedStringElement
    {
        public static bool IsStringDuplicated(List<string> strings)
        {
            var dic = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase);

            foreach (var item in strings)
            {
                if (!dic.TryAdd(item, 1))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
