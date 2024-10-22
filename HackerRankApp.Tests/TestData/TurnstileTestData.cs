namespace HackerRankApp.Tests.TestData
{
	public class TurnstileTestData : TheoryData<List<int>, List<int>, List<int>>
	{
		public TurnstileTestData()
		{
			Add([0, 0, 1, 3],
				[0, 1, 1, 0],
				[2, 0, 1, 3]);

			Add([0, 0, 1, 2],
				[0, 1, 1, 0],
				[2, 0, 1, 3]);

			Add([0, 0, 1, 2, 3],
				[0, 1, 1, 0, 1],
				[2, 0, 1, 3, 4]);

			Add([0, 0, 1, 2, 2],
				[0, 1, 1, 0, 1],
				[3, 0, 1, 4, 2]);

			Add([0, 0, 1, 2],
				[0, 1, 1, 1],
				[3, 0, 1, 2]);

			Add([1, 1, 2, 3],
				[0, 1, 1, 1],
				[4, 1, 2, 3]);

			Add([0, 0, 1, 2, 2],
				[0, 1, 0, 1, 0],
				[1, 0, 2, 4, 3]);
		}
	}
}
