namespace HackerRankApp.Tests
{
	public class RequestToServerTests
	{
		[Fact]
		public void Run_01()
		{
			var n = 3;
			var log_data = new List<List<int>> { new() { 3, 3 }, new() { 2, 6 }, new() { 1, 5 } };
			var query = new List<int> { 10, 11 };
			var X = 5;
			var expectation = new List<int>() { 1, 2 };

			var result = RequestToServer.Run(n, log_data, query, X);

			result.Should().BeEquivalentTo(expectation);
		}
	}
}
