namespace HackerRankApp.Algorithm
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/library-fine/problem
    /// </summary>
    public static class LibraryFine
    {
        public static int Run(int day, int month, int year, int expiryDay, int expiryMonth, int expiryYear)
        {
            var fine = 0;

            var (lateDays, lateMonths, lateYears) = GetExpiryTime(day, month, year, expiryDay, expiryMonth, expiryYear);

            if (IsExpired(lateDays, lateMonths, lateYears))
            {
                if (lateYears > 0)
                {
                    fine = 10000;
                }
                else if (lateMonths > 0)
                {
                    fine = 500 * lateMonths;
                }
                else if (lateDays > 0)
                {
                    fine = 15 * lateDays;
                }
            }

            return fine;
        }

        private static bool IsExpired(int lateDays, int lateMonths, int lateYears)
        {
            if (lateYears > 0) return true;
            if (lateYears < 0) return false;

            if (lateMonths > 0) return true;
            if (lateMonths < 0) return false;

            if (lateDays > 0) return true;
            return false;
        }

        private static (int, int, int) GetExpiryTime(int day, int month, int year, int expiryDay, int expiryMonth, int expiryYear)
        {
            var lateDays = 0;
            var lateMonths = 0;
            var lateYears = 0;

            if (year != expiryYear)
            {
                lateYears = year - expiryYear;
            }
            else if (month != expiryMonth)
            {
                lateMonths = month - expiryMonth;
            }
            else if (day != expiryDay)
            {
                lateDays = day - expiryDay;
            }

            return (lateDays, lateMonths, lateYears);
        }
    }
}
