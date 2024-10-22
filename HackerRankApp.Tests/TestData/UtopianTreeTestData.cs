namespace HackerRankApp.Tests.TestData
{
	public class UtopianTreeTestData : TheoryData<int, int>
	{
		public UtopianTreeTestData()
		{
			Add(0, 1);
			Add(1, 2);
			Add(2, 3);
			Add(3, 6);
			Add(4, 7);
			Add(5, 14);
		}
	}
}
