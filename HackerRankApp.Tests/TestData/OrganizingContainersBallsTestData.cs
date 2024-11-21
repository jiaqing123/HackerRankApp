namespace HackerRankApp.Tests.TestData;

public class OrganizingContainersBallsTestData : TheoryData<List<List<int>>, bool>
{
	public OrganizingContainersBallsTestData()
	{
		Add([[1, 4], [2, 3]], false);
		Add([[1, 1], [1, 1]], true);
		Add([[0, 2], [1, 1]], false);

		Add([[1, 3, 1], [2, 1, 2], [3, 3, 3]], false);
		Add([[0, 2, 1], [1, 1, 1], [2, 0, 0]], true);
	}
}
