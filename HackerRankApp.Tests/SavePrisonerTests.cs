namespace HackerRankApp.Tests
{
	public class SavePrisonerTests
	{
		[Theory]
		[ClassData(typeof(SavePrisonerTestData))]
		public void GetWarningSeat_InputValid_NotThrowException(int numberOfPeople, int numberOfCandy, int startingNumber, int expectation)
		{
			var handleTask = () => SavePrisoner.GetWarningSeat(numberOfPeople, numberOfCandy, startingNumber);

			handleTask.Should().NotThrow()
				.Which.Should().Be(expectation);
		}
	}
}
