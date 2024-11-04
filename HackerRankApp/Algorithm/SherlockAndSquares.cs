namespace HackerRankApp.Algorithm
{
	/// <summary>
	/// https://www.hackerrank.com/challenges/sherlock-and-squares/problem
	/// </summary>
	public static class SherlockAndSquares
	{
		public static int CountSquareIntegers(int lower, int upper)
		{
			// 24(4) 25(5) 26(5) 36(6)
			var begin = Math.Round(Math.Sqrt(lower), 3);
			var end = Math.Round(Math.Sqrt(upper), 3);

			var countBegin = begin == (int)begin;

			var count = (int)end - (int)begin;

			if (countBegin) count++;

			return count;
		}
	}
}
