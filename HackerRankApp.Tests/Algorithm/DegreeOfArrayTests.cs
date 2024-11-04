namespace HackerRankApp.Tests.Algorithm
{
	public class DegreeOfArrayTests
	{
		[Fact]
		public void Run_01()
		{
			var arr = new List<int> { 5, 1, 2, 2, 3, 1 };

			var result = DegreeOfArray.Run(arr);

			result.Should().Be(2);
		}
	}
}
