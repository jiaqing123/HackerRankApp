namespace HackerRankApp.Tests.TestData;

public class QueensAttackIITestData : TheoryData<int, int, int, int, List<List<int>>, int>
{
	public QueensAttackIITestData()
	{
		Add(8, 0, 4, 4, [], 27);
		Add(8, 2, 4, 4, [[2, 2], [7, 7]], 23);
		Add(8, 1, 4, 4, [[3, 5]], 24);
		Add(8, 1, 4, 4, [[6, 4]], 24);
		Add(8, 1, 4, 4, [[4, 6]], 24);
		Add(8, 1, 4, 4, [[2, 6]], 25);
		Add(8, 1, 4, 4, [[1, 4]], 26);

		Add(4, 0, 3, 4, [], 9);
		Add(4, 0, 4, 3, [], 9);
		Add(4, 0, 4, 4, [], 9);

		Add(5, 3, 4, 3, [[5, 5], [4, 2], [2, 3]], 10);
		Add(1, 0, 1, 1, [], 0);
	}
}
