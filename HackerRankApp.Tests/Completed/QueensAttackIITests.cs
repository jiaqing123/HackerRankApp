using HackerRankApp.Completed;

namespace HackerRankApp.Tests.Completed
{
    public class QueensAttackIITests
    {
        [Theory]
        [ClassData(typeof(QueensAttackIITestData))]
        public void Run_InputValid_NotThrowException(int dimension, int obstacleCount, int queenRow, int queenColumn, List<List<int>> obstacles, int expectation)
        {
            var handleTask = () => QueensAttackII.Run(dimension, obstacleCount, queenRow, queenColumn, obstacles);

            handleTask.Should().NotThrow()
                .Which.Should().Be(expectation);
        }
    }
}
