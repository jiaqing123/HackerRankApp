namespace HackerRankApp.Tests.TestData;

public class SherlockAndSquaresTestData : TheoryData<int, int, int>
{
	public SherlockAndSquaresTestData()
	{
		Add(24, 24, 0);
		Add(25, 25, 1);
		Add(24, 49, 3);
		Add(25, 49, 3);
		Add(26, 49, 2);
		Add(26, 50, 2);
		Add(26, 48, 1);
	}
}
