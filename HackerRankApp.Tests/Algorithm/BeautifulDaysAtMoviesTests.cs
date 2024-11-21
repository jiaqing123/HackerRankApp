namespace HackerRankApp.Tests.Algorithm;

public class BeautifulDaysAtMoviesTests
{
	[Theory]
	[ClassData(typeof(BeautifulDaysAtMoviesTestData))]
	public void GetNumberOfBeautifulDays_InputValid_NotThrowException(int beginDay, int endDay, int divisor, int expectation)
	{
		var handleTask = () => BeautifulDaysAtMovies.GetNumberOfBeautifulDays(beginDay, endDay, divisor);

		handleTask.Should().NotThrow()
			.Which.Should().Be(expectation);
	}
}
