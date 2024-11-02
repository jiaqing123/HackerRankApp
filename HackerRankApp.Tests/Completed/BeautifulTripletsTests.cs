using HackerRankApp.Completed;

namespace HackerRankApp.Tests.Completed
{
    public class BeautifulTripletsTests
    {
        [Theory]
        [ClassData(typeof(BeautifulTripletsTestData))]
        public void Run01(int diff, List<int> arr, int expectation)
        {
            var handleTask = () => BeautifulTriplets.Run(diff, arr);

            handleTask.Should().NotThrow()
                .Which.Should().Be(expectation);
        }
    }
}
