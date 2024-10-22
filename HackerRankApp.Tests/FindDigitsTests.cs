namespace HackerRankApp.Tests
{
	public class FindDigitsTests
	{
		[Theory]
		[ClassData(typeof(FindDigitsTestData))]
		public void GetDivisorCount_InputValid_NotThrowException(int number, int expectation)
		{
			var handleTask = () => FindDigits.GetDivisorCount(number);

			handleTask.Should().NotThrow()
				.Which.Should().Be(expectation);
		}
	}
}
