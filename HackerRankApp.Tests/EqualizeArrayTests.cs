namespace HackerRankApp.Tests
{
	public class EqualizeArrayTests
	{
		[Theory]
		[ClassData(typeof(EqualizeArrayTestData))]
		public void Run_InputValid_NotThrowException(List<int> arr, int expectation)
		{
			var handleTask = () => EqualizeArray.Run(arr);

			handleTask.Should().NotThrow()
				.Which.Should().Be(expectation);
		}
	}
}
