namespace HackerRankApp.Completed
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/angry-professor/problem
    /// </summary>
    public static class AngryProfessor
    {
        public static bool IsClassCancelled(int threshold, List<int> arrivals)
        {
            var arrivalCount = 0;
            var notArrivalCount = 0;
            var stopThreshold = arrivals.Count - threshold;

            foreach (int arrival in arrivals)
            {
                if (arrival <= 0) arrivalCount++;
                else notArrivalCount++;

                if (arrivalCount >= threshold) return false;

                if (notArrivalCount >= stopThreshold) return true;
            }

            return true;
        }
    }
}
