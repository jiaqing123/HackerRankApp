namespace HackerRankApp.Tests
{
	public class EnglishTextEncryptionTests
	{
		[Theory]
		[ClassData(typeof(EnglishTextEncryptionTestData))]
		public void Run_01(string original, string expectation)
		{
			var handleTask = () => EnglishTextEncryption.Run(original);

			handleTask.Should().NotThrow()
				.Which.Should().BeEquivalentTo(expectation);
		}
	}
}
