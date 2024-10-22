namespace HackerRankApp.Tests.TestData
{
	public class EqualizeArrayTestData : TheoryData<List<int>, int>
	{
		public EqualizeArrayTestData()
		{
			Add([1, 2, 2, 3], 2);
			Add([3, 3, 2, 1, 3], 2);
		}
	}
}
