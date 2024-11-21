namespace HackerRankApp.Tests.TestData;

public class CircularArrayRotationTestData : TheoryData<List<int>, int, List<int>, List<int>>
{
	public CircularArrayRotationTestData()
	{
		Add([3, 4, 5], 2, [1, 2], [5, 3]);
	}
}
