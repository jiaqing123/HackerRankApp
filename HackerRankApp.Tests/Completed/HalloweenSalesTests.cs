using HackerRankApp.Completed;

namespace HackerRankApp.Tests.Completed
{
    public class HalloweenSalesTests
    {
        [Fact]
        public void Run_01()
        {
            int init = 20;
            int discount = 3;
            int min = 6;
            int budget = 70;
            int expection = 5;

            var handleTask = () => HalloweenSales.Run(init, discount, min, budget);

            handleTask.Should().NotThrow()
                .Which.Should().Be(expection);
        }

        [Fact]
        public void Run_02()
        {
            int init = 20;
            int discount = 3;
            int min = 6;
            int budget = 80;
            int expection = 6;

            var handleTask = () => HalloweenSales.Run(init, discount, min, budget);

            handleTask.Should().NotThrow()
                .Which.Should().Be(expection);
        }

        [Theory]
        [ClassData(typeof(HalloweenSalesTestData))]
        public void Run_03(int init, int discount, int min, int budget, int expection)
        {
            var handleTask = () => HalloweenSales.Run(init, discount, min, budget);

            handleTask.Should().NotThrow()
                .Which.Should().Be(expection);
        }
    }
}
