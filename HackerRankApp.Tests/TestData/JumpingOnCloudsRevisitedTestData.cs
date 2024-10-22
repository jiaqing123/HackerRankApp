namespace HackerRankApp.Tests.TestData
{
	public class JumpingOnCloudsRevisitedTestData : TheoryData<int[], int, int>
	{
        public JumpingOnCloudsRevisitedTestData()
        {
			Add([0, 0, 1, 0], 2, 96);
			Add([0, 0, 1, 0, 0, 1, 1, 0], 2, 92);
			Add([1, 1, 1, 0, 1, 1, 0, 0, 0, 0], 3, 80);
		}
    }
}
