namespace HackerRankApp.Tests.TestData;

public class AngryProfessorTestData : TheoryData<int, List<int>, bool>
{
	public AngryProfessorTestData()
	{
		Add(3, [-2, -1, 0, 1, 2], false);

		Add(3, [-1, -3, 4, 2], true);

		Add(2, [0, -1, 2, 1], false);
	}
}
