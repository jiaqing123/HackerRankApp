namespace HackerRankApp.Tests
{
	public class SherlockAndSquaresTests
	{
		[Theory]
		[ClassData(typeof(SherlockAndSquaresTestData))]
		public void CountSquareIntegers_InputValid_NotThrowException(int lower, int upper, int expectation)
		{
			var handleTask = () => SherlockAndSquares.CountSquareIntegers(lower, upper);

			handleTask.Should().NotThrow()
				.Which.Should().Be(expectation);
		}
	}
}
