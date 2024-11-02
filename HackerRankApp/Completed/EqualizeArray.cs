namespace HackerRankApp.Completed
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/equality-in-a-array/problem
    /// </summary>
    public static class EqualizeArray
    {
        public static int Run(List<int> arr)
        {
            var numbers = arr.GroupBy(i => i)
                .ToDictionary(i => i.Key, i => i.Count())
                .OrderBy(i => i.Value)
                .ToList();

            numbers.RemoveAt(numbers.Count - 1);

            var count = numbers.Sum(i => i.Value);

            return count;
        }
    }
}
