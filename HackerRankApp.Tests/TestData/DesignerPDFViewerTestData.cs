namespace HackerRankApp.Tests.TestData;

public class DesignerPDFViewerTestData : TheoryData<List<int>, string, int>
{
	public DesignerPDFViewerTestData()
	{
		AddTest01();
	}

	private void AddTest01()
	{
		var heights = new List<int>
		{
			1, 3, 1, 3, 1, 4, 1, 3, 2, 5, 5, 5, 5, 1, 1, 5, 5, 1, 5, 2, 5, 5, 5, 5, 5, 5
		};
		var word = "torn";
		var expectation = 8;
		Add(heights, word, expectation);
	}
}
