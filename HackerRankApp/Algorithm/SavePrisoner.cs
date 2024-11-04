namespace HackerRankApp.Algorithm
{
	/// <summary>
	/// https://www.hackerrank.com/challenges/save-the-prisoner/problem
	/// </summary>
	public static class SavePrisoner
	{
		public static int GetWarningSeat(int numberOfPeople, int numberOfCandy, int startingNumber)
		{
			// people starting from 1
			var result = (startingNumber - 1 + numberOfCandy) % numberOfPeople;

			return result == 0 ? numberOfPeople : result;
		}
	}
}
