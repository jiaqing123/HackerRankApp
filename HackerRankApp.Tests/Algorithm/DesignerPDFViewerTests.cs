namespace HackerRankApp.Tests.Algorithm
{
	public class DesignerPDFViewerTests
	{
		[Theory]
		[ClassData(typeof(DesignerPDFViewerTestData))]
		public void Run_ValidInput_NotThrowException(List<int> heights, string word, int expectation)
		{
			var handleTask = () => DesignerPDFViewer.Run(heights, word);

			handleTask.Should().NotThrow()
				.Which.Should().Be(expectation);
		}

	}
}
