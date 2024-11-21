namespace HackerRankApp.Tests.TestData;

public class ClimbingLeaderboardTestData : TheoryData<List<int>, List<int>, List<int>>
{
	public ClimbingLeaderboardTestData()
	{
		AddTest01();

		AddTest02();

		AddTest03();

		AddTest04();

		AddTest05();

		AddTest06();
	}

	private void AddTest01()
	{
		var rankeds = new List<int> { 100, 90, 90, 80 };
		var players = new List<int> { 70, 80, 105 };
		var newRanked = new List<int> { 4, 3, 1 };

		Add(rankeds, players, newRanked);
	}

	private void AddTest02()
	{
		var rankeds = new List<int> { 1, 1, 1, 1 };
		var players = new List<int> { 2, 2, 2 };
		var newRanked = new List<int> { 1, 1, 1 };

		Add(rankeds, players, newRanked);
	}

	private void AddTest03()
	{
		var rankeds = new List<int> { };
		var players = new List<int> { 1, 2, 3 };
		var newRanked = new List<int> { 1, 1, 1 };

		Add(rankeds, players, newRanked);
	}

	private void AddTest04()
	{
		var rankeds = new List<int> { };
		var players = new List<int> { 1, 2, 3 };
		var newRanked = new List<int> { 1, 1, 1 };

		Add(rankeds, players, newRanked);
	}

	private void AddTest05()
	{
		var rankeds = new List<int> { 5, 3, 1 };
		var players = new List<int> { 0, 2, 4 };
		var newRanked = new List<int> { 4, 3, 2 };

		Add(rankeds, players, newRanked);
	}

	private void AddTest06()
	{
		var rankeds = new List<int> { 5, 2, 1 };
		var players = new List<int> { 0, 3, 4 };
		var newRanked = new List<int> { 4, 2, 2 };

		Add(rankeds, players, newRanked);
	}
}
