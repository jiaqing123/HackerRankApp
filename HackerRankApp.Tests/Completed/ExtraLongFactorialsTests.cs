using System.Numerics;
using HackerRankApp.Completed;

namespace HackerRankApp.Tests.Completed
{
    public class ExtraLongFactorialsTests
    {
        [Theory]
        [ClassData(typeof(ExtraLongFactorialsTestData))]
        public void CalculateResult_InputValid_NotThrowException(int number, BigInteger expectation)
        {
            var handleTask = () => ExtraLongFactorials.CalculateResult(number);

            handleTask.Should().NotThrow()
                .Which.Should().BeEquivalentTo(expectation);
        }
    }
}
