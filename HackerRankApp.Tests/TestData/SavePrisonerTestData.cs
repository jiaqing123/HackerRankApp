namespace HackerRankApp.Tests.TestData;

public class SavePrisonerTestData : TheoryData<int, int, int, int>
{
	public SavePrisonerTestData()
	{
		Add(4, 6, 2, 3);
		Add(5, 2, 1, 2);
		Add(5, 2, 2, 3);
		Add(7, 19, 2, 6);
		Add(3, 7, 3, 3);
		Add(1, 1, 1, 1);
		Add(1, 2, 1, 1);
		Add(3, 1, 1, 1);
		Add(3, 2, 1, 2);
		Add(3, 2, 2, 3);
		Add(3, 2, 3, 1);
	}
}
