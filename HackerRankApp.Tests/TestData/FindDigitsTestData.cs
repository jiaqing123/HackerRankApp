namespace HackerRankApp.Tests.TestData
{
	public class FindDigitsTestData : TheoryData<int, int>
	{
		public FindDigitsTestData()
		{
			Add(124, 3);
			Add(111, 3);
			Add(10, 1);
			Add(12, 2);
			Add(1012, 3);
		}
	}
}
