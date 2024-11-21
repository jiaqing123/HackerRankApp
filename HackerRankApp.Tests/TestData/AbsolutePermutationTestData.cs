namespace HackerRankApp.Tests.TestData
{
	public class AbsolutePermutationTestData : TheoryData<int, int, List<int>>
	{
		public AbsolutePermutationTestData()
		{
			Add(2, 1, [2, 1]);
			Add(10, 5, [6, 7, 8, 9, 10, 1, 2, 3, 4, 5]);
			Add(7, 5, [-1]);
			Add(2, 1, [2, 1]);
			Add(2, 0, [1, 2]);
			Add(2, 0, [1, 2]);
			Add(1, 0, [1]);
			Add(10, 5, [6, 7, 8, 9, 10, 1, 2, 3, 4, 5]);
			Add(10, 0, [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);
			Add(6, 0, [1, 2, 3, 4, 5, 6]);
			Add(9, 0, [1, 2, 3, 4, 5, 6, 7, 8, 9,]);
			Add(9, 1, [-1]);
			Add(9, 2, [-1]);
			Add(9, 3, [-1]);
			Add(9, 4, [-1]);
			Add(9, 5, [-1]);
			Add(9, 6, [-1]);
			Add(9, 7, [-1]);
			Add(9, 8, [-1]);
		}
	}
}
