namespace HackerRankApp.Completed
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/append-and-delete/problem
    /// </summary>
    public static class AppendAndDelete
    {
        public static bool CanConvert(string source, string destination, int maxSteps)
        {
            if (maxSteps >= source.Length + destination.Length) return true;

            var srcChars = source.ToCharArray();
            var dstChars = destination.ToCharArray();
            var length = Math.Min(srcChars.Length, dstChars.Length);
            var diffPos = -1;

            for (int i = 0; i < length; i++)
            {
                if (srcChars[i] == dstChars[i])
                {
                    continue;
                }
                else
                {
                    diffPos = i;

                    break;
                }
            }

            var steps = 0;

            if (diffPos == -1)
            {
                steps = Math.Abs(srcChars.Length - dstChars.Length);
            }
            else
            {
                steps = srcChars.Length - diffPos + (dstChars.Length - diffPos);
            }

            return steps <= maxSteps && (maxSteps - steps) % 2 == 0;
        }
    }
}
