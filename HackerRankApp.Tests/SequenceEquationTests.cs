namespace HackerRankApp.Tests
{
	public class SequenceEquationTests
	{
		[Theory]
		[ClassData(typeof(SequenceEquationTestData))]
		public void GetValues_InputValid_NotThrowException(List<int> numbers, List<int> expectation)
		{
			var handleTask = () => SequenceEquation.GetValues(numbers);

			handleTask.Should().NotThrow()
				.Which.Should().BeEquivalentTo(expectation, opts => opts.WithStrictOrdering());
		}
	}
}
