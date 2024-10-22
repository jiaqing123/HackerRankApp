namespace HackerRankApp.Tests
{
	public class AcmIcpcTeamTests
	{
		[Theory]
		[ClassData(typeof(AcmIcpcTeamTestData))]
		public void Run_InputValid_NotThrowException(List<string> topics, List<int> expectation)
		{
			var handleTask = () => AcmIcpcTeam.Run(topics);

			handleTask.Should().NotThrow()
				.Which.Should().BeEquivalentTo(expectation, opts => opts.WithStrictOrdering());
		}
	}
}
