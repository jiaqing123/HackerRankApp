namespace HackerRankApp.Tests.Algorithm;

public class ModifiedKaprekarNumbersTests
{
	[Theory]
	[InlineData(1, 100, "1 9 45 55 99")]
	public void Run(int start, int end, string expectation)
	{
		var handleTask = () => ModifiedKaprekarNumbers.Run(start, end);

		handleTask.Should().NotThrow()
			.Which.Should().Be(expectation);
	}
}
