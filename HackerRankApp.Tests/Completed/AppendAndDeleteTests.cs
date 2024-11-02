using HackerRankApp.Completed;

namespace HackerRankApp.Tests.Completed
{
    public class AppendAndDeleteTests
    {
        [Theory]
        [ClassData(typeof(AppendAndDeleteTestData))]
        public void CanConvert_InputValid_NotThrowException(string source, string destination, int maxSteps, bool expectation)
        {
            var handleTask = () => AppendAndDelete.CanConvert(source, destination, maxSteps);

            handleTask.Should().NotThrow()
                .Which.Should().Be(expectation);
        }
    }
}
