namespace HackerRankApp.Tests.Algorithm;

public class PickingNumbersTests
{
	[Fact]
	public void PickingNumbers01_ResultExpected()
	{
		var numbers = new List<int>()
		{
			1, 1
		};

		var expectation = 2;

		var handleTask = () => PickingNumbers.Run(numbers);

		handleTask.Should().NotThrow()
			.Which.Should().Be(expectation);
	}

	[Theory]
#pragma warning disable xUnit1045 // Avoid using TheoryData type arguments that might not be serializable
	[ClassData(typeof(PickingNumbersTestsData))]
#pragma warning restore xUnit1045 // Avoid using TheoryData type arguments that might not be serializable
	public void PickingNumbers02_ResultExpected(List<int> numbers, int expectation)
	{
		var handleTask = () => PickingNumbers.Run(numbers);

		handleTask.Should().NotThrow()
			.Which.Should().Be(expectation);
	}
}
