namespace HackerRankApp.Tests
{
	public class MaxHourGlassSumTest
	{
		[Theory]
		[ClassData(typeof(MaxHourGlassSumTestData))]
		public void Run_01(List<List<int>> arr, int expectation)
		{
			var handleTask = () => MaxHourGlassSum.Run(arr);

			handleTask.Should().NotThrow()
				.Which.Should().Be(expectation);
		}
	}
}
