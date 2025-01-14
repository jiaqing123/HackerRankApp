using HackerRankApp.Problems;

namespace HackerRankApp.Tests.Problems;

public class AlmostSortedTests
{
	[Theory]
	[ClassData(typeof(AlmostSortedTestData))]
	public void Run_01(List<int> list, List<string> expectation)
	{
		var handleTask = () => AlmostSorted.Run(list);

		handleTask.Should().NotThrow()
			.Subject.Should().BeEquivalentTo(expectation, opts => opts.WithStrictOrdering());
	}
}

public class AlmostSortedTestData : TheoryData<List<int>, List<string>>
{
	public AlmostSortedTestData()
	{
		Add([1, 2, 4, 9, 3], ["no"]);
		Add([4, 2], ["yes", "swap 1 2"]);
		Add([3, 1, 2], ["no"]);
		Add([1, 5, 4, 3, 2, 6], ["yes", "reverse 2 5"]);
		Add([1, 5, 4, 3, 2], ["yes", "reverse 2 5"]);
		Add([1], ["yes"]);
		Add([1, 2], ["yes"]);
		Add([1, 2, 3], ["yes"]);
		Add([1, 2, 4, 3], ["yes", "swap 3 4"]);
		Add([1, 5, 3, 4, 2, 6], ["yes", "swap 2 5"]);
		Add([1, 6, 3, 4, 5, 2], ["yes", "swap 2 6"]);

		Add([1, 2, 3, 4, 5, 6], ["yes"]);
		Add([6, 5, 4, 3, 2, 1], ["yes", "reverse 1 6"]);
		Add([5, 4, 3, 2, 1, 6], ["yes", "reverse 1 5"]);
		Add([1, 6, 5, 4, 3, 2], ["yes", "reverse 2 6"]);
		Add([1, 5, 4, 3, 2, 6], ["yes", "reverse 2 5"]);

		Add([5, 4, 3, 2, 1, 6, 7, 8], ["yes", "reverse 1 5"]);
		Add([5, 4, 3, 2, 1, 6, 8, 7], ["no"]);
		Add([8, 6, 4, 2, 9, 10, 11, 12], ["yes", "reverse 1 4"]);

		Add([1, 2, 3, 9, 7, 8], ["no"]);
		Add([1, 2, 3, 9, 7, 10], ["yes", "swap 4 5"]);
		Add([1, 2, 3, 9, 7, 6], ["yes", "swap 4 6"]);
	}
}
