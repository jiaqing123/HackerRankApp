﻿namespace HackerRankApp.Tests.Algorithm;

public class CutSticksTests
{
	[Theory]
	[ClassData(typeof(CutSticksTestData))]
	public void Run_InputValid_NotThrowException(List<int> sticks, List<int> expectation)
	{
		var handleTask = () => CutSticks.Run(sticks);

		handleTask.Should().NotThrow()
			.Which.Should().BeEquivalentTo(expectation, opts => opts.WithStrictOrdering());
	}
}
