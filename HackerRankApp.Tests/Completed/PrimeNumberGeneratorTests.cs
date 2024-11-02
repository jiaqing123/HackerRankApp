using HackerRankApp.Completed;

namespace HackerRankApp.Tests.Completed
{
    public class PrimeNumberGeneratorTests
    {
#pragma warning disable xUnit1045
        [Theory]
        [ClassData(typeof(PrimeNumberGeneratorTestData))]
        public void Test01(List<int> arr, List<int> brr, int result)
        {
            var handle = () => PrimeNumberGenerator.GetTotalX(arr, brr);

            handle.Should().NotThrow()
                .Which.Should().Be(result);
        }
#pragma warning restore xUnit1045
    }
}
