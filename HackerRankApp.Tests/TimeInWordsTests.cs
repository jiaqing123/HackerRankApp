namespace HackerRankApp.Tests
{
	public class TimeInWordsTests
	{
		[Theory]
		[InlineData(5, 0, "five o' clock")]
		[InlineData(5, 1, "one minute past five")]
		[InlineData(5, 10, "ten minutes past five")]
		[InlineData(5, 15, "quarter past five")]
		[InlineData(5, 30, "half past five")]
		[InlineData(5, 45, "quarter to six")]
		[InlineData(5, 57, "three minutes to six")]
		[InlineData(11, 45, "quarter to twelve")]
		[InlineData(12, 15, "quarter past twelve")]
		[InlineData(12, 25, "twenty five minutes past twelve")]
		[InlineData(12, 45, "quarter to one")]
		[InlineData(12, 35, "twenty five minutes to one")]
		public void Run_01(int hour, int minutes, string expectation)
		{
			var handleTask = () => TimeInWords.Run(hour, minutes);

			handleTask.Should().NotThrow()
				.Which.Should().Be(expectation);
		}
	}
}
