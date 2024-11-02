using HackerRankApp.Completed;

namespace HackerRankApp.Tests.Completed
{
    public class SherlockAndSquaresTests
    {
        [Theory]
        [ClassData(typeof(SherlockAndSquaresTestData))]
        public void CountSquareIntegers_InputValid_NotThrowException(int lower, int upper, int expectation)
        {
            var handleTask = () => SherlockAndSquares.CountSquareIntegers(lower, upper);

            handleTask.Should().NotThrow()
                .Which.Should().Be(expectation);
        }
    }
}
