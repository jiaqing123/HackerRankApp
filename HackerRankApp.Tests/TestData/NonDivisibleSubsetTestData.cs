namespace HackerRankApp.Tests.TestData
{
	public class NonDivisibleSubsetTestData : TheoryData<int, List<int>, int>
	{
        public NonDivisibleSubsetTestData()
        {
			Add(1, [1, 2, 3, 4, 5], 1);
			Add(4, [19, 10, 12, 24, 25, 22], 3);
			Add(3, [1, 7, 2, 4], 3);
			Add(4, [1, 3, 5, 7], 2);
		}
    }
}
