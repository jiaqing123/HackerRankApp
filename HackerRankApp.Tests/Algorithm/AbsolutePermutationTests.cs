namespace HackerRankApp.Tests.Algorithm
{
	public class AbsolutePermutationTests
	{
		[Fact]
		public void Run_01()
		{
			int upperBound = 4;
			int differences = 2;

			List<int> expectation = [3, 4, 1, 2];

			var handleTask = () => AbsolutePermutation.Run(upperBound, differences);

			handleTask.Should().NotThrow()
				.Which.Should().BeEquivalentTo(expectation, opts => opts.WithStrictOrdering());
		}

		[Fact]
		public void Run_02()
		{
			int upperBound = 2;
			int differences = 1;

			List<int> expectation = [2, 1];

			var handleTask = () => AbsolutePermutation.Run(upperBound, differences);

			handleTask.Should().NotThrow()
				.Which.Should().BeEquivalentTo(expectation, opts => opts.WithStrictOrdering());
		}

		[Fact]
		public void Run_03()
		{
			int upperBound = 3;
			int differences = 0;

			List<int> expectation = [1, 2, 3];

			var handleTask = () => AbsolutePermutation.Run(upperBound, differences);

			handleTask.Should().NotThrow()
				.Which.Should().BeEquivalentTo(expectation, opts => opts.WithStrictOrdering());
		}

		[Fact]
		public void Run_04()
		{
			int upperBound = 3;
			int differences = 2;

			List<int> expectation = [-1];

			var handleTask = () => AbsolutePermutation.Run(upperBound, differences);

			handleTask.Should().NotThrow()
				.Which.Should().BeEquivalentTo(expectation, opts => opts.WithStrictOrdering());
		}

#pragma warning disable xUnit1045
		[Theory]
		[ClassData(typeof(AbsolutePermutationTestData))]
		public void Run_05(int upperBound, int differences, List<int> expectation)
		{
			var handleTask = () => AbsolutePermutation.Run(upperBound, differences);

			handleTask.Should().NotThrow()
				.Which.Should().BeEquivalentTo(expectation, opts => opts.WithStrictOrdering());
		}
#pragma warning restore xUnit1045
	}
}
