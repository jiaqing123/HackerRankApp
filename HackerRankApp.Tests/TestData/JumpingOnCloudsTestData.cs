namespace HackerRankApp.Tests.TestData;

public class JumpingOnCloudsTestData : TheoryData<List<int>, int>
{
	public JumpingOnCloudsTestData()
	{
		Add([0, 1, 0, 0, 0, 1, 0], 3);
		Add([0, 0, 1, 0, 0, 1, 0], 4);
		Add([0, 0, 1, 0, 0, 1, 0, 0], 5);
		Add([0], 0);
		Add([0, 0], 1);
		Add([0, 0, 0], 1);
	}
}
