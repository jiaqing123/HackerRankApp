namespace HackerRankApp.Tests.TestData
{
	public class AcmIcpcTeamTestData : TheoryData<List<string>, List<int>>
	{
		public AcmIcpcTeamTestData()
		{
			Add(["10101", "11110", "00010"], [5, 1]);
			Add(["10101", "11100", "11010", "00101"], [5, 2]);
		}
	}
}
