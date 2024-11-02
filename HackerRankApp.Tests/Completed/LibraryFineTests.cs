using HackerRankApp.Completed;

namespace HackerRankApp.Tests.Completed
{
    public class LibraryFineTests
    {
        [Theory]
        [ClassData(typeof(LibraryFineTestData))]
        public void Run_InputValid_NotThrowException(int day, int month, int year, int expiryDay, int expiryMonth, int expiryYear, int expectation)
        {
            var handleTask = () => LibraryFine.Run(day, month, year, expiryDay, expiryMonth, expiryYear);

            handleTask.Should().NotThrow()
                .Which.Should().Be(expectation);
        }
    }
}
