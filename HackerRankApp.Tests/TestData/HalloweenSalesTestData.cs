namespace HackerRankApp.Tests.TestData;

public class HalloweenSalesTestData : TheoryData<int, int, int, int, int>
{
	public HalloweenSalesTestData()
	{
		Add(20, 3, 6, 20, 1);
		Add(20, 3, 6, 19, 0);
	}
}