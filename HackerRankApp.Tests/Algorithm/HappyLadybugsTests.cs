namespace HackerRankApp.Tests.Algorithm
{
	public class HappyLadybugsTests
	{
		[Fact]
		public void Run_01()
		{
			string initial = "YYR_B_BR";

			string expectation = "YES";

			var handleTask = () => HappyLadybugs.Run(initial);

			handleTask.Should().NotThrow()
				.Which.Should().BeEquivalentTo(expectation);
		}

		[Theory]
		[InlineData("RBY_YBR", "YES")]
		[InlineData("X_Y__X", "NO")]
		[InlineData("__", "YES")]
		[InlineData("B_RRBR", "YES")]
		[InlineData("AABBC", "NO")]
		[InlineData("AABBC_C", "YES")]
		[InlineData("_", "YES")]
		[InlineData("DD__FQ_QQF", "YES")]
		[InlineData("AABCBC", "NO")]
		[InlineData("AABBBBBCCD_DDEEEFFFGHJGHKJ", "NO")]
		public void Run_02(string initial, string expectation)
		{
			var handleTask = () => HappyLadybugs.Run(initial);

			handleTask.Should().NotThrow()
				.Which.Should().BeEquivalentTo(expectation);
		}
	}
}
