namespace HackerRankApp.Tests.Algorithm;

public class SequenceEquationTests
{
	[Theory]
#pragma warning disable xUnit1045 // Avoid using TheoryData type arguments that might not be serializable
	[ClassData(typeof(SequenceEquationTestData))]
#pragma warning restore xUnit1045 // Avoid using TheoryData type arguments that might not be serializable
	public void GetValues_InputValid_NotThrowException(List<int> numbers, List<int> expectation)
	{
		var handleTask = () => SequenceEquation.GetValues(numbers);

		handleTask.Should().NotThrow()
			.Which.Should().BeEquivalentTo(expectation, opts => opts.WithStrictOrdering());
	}
}
