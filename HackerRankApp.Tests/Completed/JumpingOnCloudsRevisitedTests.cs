using HackerRankApp.Completed;

namespace HackerRankApp.Tests.Completed
{
    public class JumpingOnCloudsRevisitedTests
    {
        [Theory]
        [ClassData(typeof(JumpingOnCloudsRevisitedTestData))]
        public void GetRemainingEnergy_InputValid_NotThrowException(int[] clouds, int jump, int expectation)
        {
            var handleTask = () => JumpingOnCloudsRevisited.GetRemainingEnergy(clouds, jump);

            handleTask.Should().NotThrow()
                .Which.Should().Be(expectation);
        }
    }
}
