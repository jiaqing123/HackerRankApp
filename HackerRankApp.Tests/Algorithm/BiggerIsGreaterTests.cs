namespace HackerRankApp.Tests.Algorithm;

public class BiggerIsGreaterTests
{
	private static readonly string DirPath = Directory.GetCurrentDirectory();

	[Theory]
	[ClassData(typeof(BiggerIsGreaterTestData))]
	public void Run_01(string original, string expectation)
	{
		var handleTask = () => BiggerIsGreater.Run(original);

		handleTask.Should().NotThrow()
			.Which.Should().BeEquivalentTo(expectation);
	}

	[Theory]
	[InlineData(@"TestData\BiggerIsGreaterLargeTestData03.txt", @"TestData\BiggerIsGreaterLargeTestDataResult03.txt")]
	public void Run_02(string source, string expectation)
	{
		var srcPath = Path.Combine(DirPath, source);
		var expPath = Path.Combine(DirPath, expectation);

		var srcData = File.ReadAllLines(srcPath);
		var expData = File.ReadAllLines(expPath);

		for (int i = 1; i < expData.Length; i++)
		{
			var handleTask = () => BiggerIsGreater.Run(srcData[i]);

			handleTask.Should().NotThrow()
			.Which.Should().BeEquivalentTo(expData[i - 1]);
		}
	}
}
