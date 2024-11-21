namespace HackerRankApp.Tests.TestData;

public class SequenceEquationTestData : TheoryData<List<int>, List<int>>
{
	public SequenceEquationTestData()
	{
		Add([5, 2, 1, 3, 4], [4, 2, 5, 1, 3]);
		Add([4, 3, 5, 1, 2], [1, 3, 5, 4, 2]);
		Add([2, 3, 1], [2, 3, 1]);
	}
}
