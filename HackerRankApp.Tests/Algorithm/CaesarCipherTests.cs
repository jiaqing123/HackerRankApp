namespace HackerRankApp.Tests.Algorithm
{
	public class CaesarCipherTests
	{
		[Fact]
		public void Run_01()
		{
			string clearText = "abcdefghijklmnopqrstuvwxyz";
			int rotationFactor = 3;

			string expectation = "defghijklmnopqrstuvwxyzabc";

			var handleTask = () => CaesarCipher.Run(clearText, rotationFactor);

			handleTask.Should().NotThrow()
				.Which.Should().BeEquivalentTo(expectation);
		}

		[Fact]
		public void Run_02()
		{
			string clearText = "middle-Outz";
			int rotationFactor = 2;

			string expectation = "okffng-Qwvb";

			var handleTask = () => CaesarCipher.Run(clearText, rotationFactor);

			handleTask.Should().NotThrow()
				.Which.Should().BeEquivalentTo(expectation);
		}
	}
}
