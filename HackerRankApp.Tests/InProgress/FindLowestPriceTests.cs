using HackerRankApp.InProgress;

namespace HackerRankApp.Tests.InProgress
{
	public class FindLowestPriceTests
	{
		[Fact]
		public void Run_01()
		{
			List<List<string>> products = [["10", "d0", "d1"], ["15", "EMPTY", "EMPTY"], ["20", "d1", "EMPTY"]];
			List<List<string>> discounts = [["d0", "1", "27"], ["d1", "2", "5"]];
			var expectation = 35;

			var handleTask = () => FindLowestPrice.Run(products, discounts);

			handleTask.Should().NotThrow()
				.Which.Should().Be(expectation);
		}

		[Fact]
		public void Run_02()
		{
			List<List<string>> products = [["10", "sale", "january-sale"], ["200", "sale", "EMPTY"]];
			List<List<string>> discounts = [["sale", "0", "10"], ["january-sale", "1", "10"]];
			var expectation = 19;

			var handleTask = () => FindLowestPrice.Run(products, discounts);

			handleTask.Should().NotThrow()
				.Which.Should().Be(expectation);
		}

		[Fact]
		public void Run_03()
		{
			List<List<string>> products = [
				["100", "dcoupon1"],
				["50", "dcoupon1"],
				["30", "dcoupon1"],
				["100", "dcoupon2"],
				["50", "dcoupon2"],
				["30", "dcoupon2"]
			];
			List<List<string>> discounts = [
				["dcoupon1", "0", "60"],
				["dcoupon1", "1", "30"],
				["dcoupon1", "1", "20"],
				["dcoupon2", "2", "20"],
				["dcoupon2", "1", "85"],
				["dcoupon2", "0", "15"],
			];
			var expectation = 142;

			var handleTask = () => FindLowestPrice.Run(products, discounts);

			handleTask.Should().NotThrow()
				.Which.Should().Be(expectation);
		}

		[Fact]
		public void Run_04()
		{
			List<List<string>> products = [
				["100", "dcoupon1"],
				["50", "dcoupon1"],
				["30", "dcoupon1"],
				["100", "dcoupon2"],
				["50", "dcoupon2"],
				["30", "dcoupon2"],
				["30", "dcoupon3"]
			];
			List<List<string>> discounts = [
				["dcoupon1", "0", "60"],
				["dcoupon1", "1", "30"],
				["dcoupon1", "1", "20"],
				["dcoupon2", "2", "20"],
				["dcoupon2", "1", "85"],
				["dcoupon2", "0", "15"],
				["dcoupon3", "0", "20"],
			];

			var expectation = 142 + 20;

			var handleTask = () => FindLowestPrice.Run(products, discounts);

			handleTask.Should().NotThrow()
				.Which.Should().Be(expectation);
		}
	}
}
