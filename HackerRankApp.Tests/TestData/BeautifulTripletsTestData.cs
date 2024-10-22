namespace HackerRankApp.Tests.TestData
{
	public class BeautifulTripletsTestData : TheoryData<int, List<int>, int>
	{
		public BeautifulTripletsTestData()
		{
			Add(1, [2, 2, 3, 4, 5], 3);

			Add(3, [1, 2, 4, 5, 7, 8, 10], 3);
		}
	}
}
