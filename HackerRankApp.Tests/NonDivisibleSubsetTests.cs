namespace HackerRankApp.Tests
{
	public class NonDivisibleSubsetTests
	{
		[Theory]
		[ClassData(typeof(NonDivisibleSubsetTestData))]
		public void Run_InputValid_NotThrowException(int divisor, List<int> numbers, int expectation)
		{
			var handleTask = () => NonDivisibleSubset.Run(divisor, numbers);

			handleTask.Should().NotThrow()
				.Which.Should().Be(expectation);
		}
	}
}
