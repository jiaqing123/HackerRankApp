namespace HackerRankApp.Tests.Algorithm
{
	public class AngryProfessorTests
	{
		[Theory]
		[ClassData(typeof(AngryProfessorTestData))]
		public void IsClassCancelled_InputValid_NotThrowException(int threshold, List<int> arrivals, bool expectation)
		{
			var handleTask = () => AngryProfessor.IsClassCancelled(threshold, arrivals);

			handleTask.Should().NotThrow()
				.Which.Should().Be(expectation);
		}

	}
}
