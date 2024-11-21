namespace HackerRankApp.Tests.Algorithm;

public class QueensAttackIITests
{
	[Theory]
#pragma warning disable xUnit1045 // Avoid using TheoryData type arguments that might not be serializable
	[ClassData(typeof(QueensAttackIITestData))]
#pragma warning restore xUnit1045 // Avoid using TheoryData type arguments that might not be serializable
	public void Run_InputValid_NotThrowException(int dimension, int obstacleCount, int queenRow, int queenColumn, List<List<int>> obstacles, int expectation)
	{
		var handleTask = () => QueensAttackII.Run(dimension, obstacleCount, queenRow, queenColumn, obstacles);

		handleTask.Should().NotThrow()
			.Which.Should().Be(expectation);
	}
}
