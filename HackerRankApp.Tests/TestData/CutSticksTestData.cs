namespace HackerRankApp.Tests.TestData
{
	public class CutSticksTestData : TheoryData<List<int>, List<int>>
	{
		public CutSticksTestData()
		{
			Add([1, 2, 3], [3, 2, 1]);
			Add([5, 4, 4, 2, 2, 8], [6, 4, 2, 1]);
		}
	}
}
