namespace HackerRankApp.Completed
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/taum-and-bday/problem
    /// </summary>
    public static class TaumAndBday
    {
        public static long Run(int blackCount, int whiteCount, int blackCost, int whiteCost, int conversionCost)
        {
            var minimumCost = 0L;

            if (blackCost == whiteCost ||
                blackCost > whiteCost && blackCost <= whiteCost + conversionCost ||
                blackCost < whiteCost && blackCost + conversionCost >= whiteCost)
            {
                minimumCost = CalculateCost(blackCount, whiteCount, blackCost, whiteCost);
            }
            else
            {
                if (blackCost > whiteCost && blackCost > whiteCost + conversionCost)
                {
                    minimumCost = CalculateCost(blackCount, whiteCount, whiteCost + conversionCost, whiteCost);
                }
                else
                {
                    minimumCost = CalculateCost(blackCount, whiteCount, blackCost, blackCost + conversionCost);
                }

            }

            return minimumCost;
        }

        private static long CalculateCost(long blackCount, long whiteCount, long blackCost, long whiteCost)
            => blackCost * blackCount + whiteCost * whiteCount;
    }
}
