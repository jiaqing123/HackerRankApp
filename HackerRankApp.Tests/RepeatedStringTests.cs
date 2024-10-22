namespace HackerRankApp.Tests
{
	public class RepeatedStringTests
	{
		[Theory]
		[ClassData(typeof(RepeatedStringTestData))]
		public void Run_InputValid_NotThrowException(string repeating, long count, long expectation)
		{
			var handleTask = () => RepeatedString.Run(repeating, count);

			handleTask.Should().NotThrow()
				.Which.Should().Be(expectation);
		}
	}
}
