namespace HackerRankApp.Tests
{
	public class CircularArrayRotationTests
	{
		[Theory]
		[ClassData(typeof(CircularArrayRotationTestData))]
		public void GetRotatedValues_InputValid_NotThrowException(List<int> values, int shiftCount, List<int> queries, List<int> expectation)
		{
			var handleTask = () => CircularArrayRotation.GetRotatedValues(values, shiftCount, queries);

			handleTask.Should().NotThrow()
				.Which.Should().BeEquivalentTo(expectation);
		}
	}
}
