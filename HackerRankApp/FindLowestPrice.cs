using System.Text;

namespace HackerRankApp
{
	public static class FindLowestPrice
	{
		private const string EmptyType = "EMPTY";

		private class DiscountInfo
		{
			public Func<int, int> CalculatePrice { get; set; } = (price) => price;
		}

		private class ProductInfo
		{
			public int BestPrice { get; set; }
		}

		public static int Run(List<List<string>> products, List<List<string>> discounts)
		{
			if (products.Count == 0) return 0;

			// privileged customers
			// discount tag
			// minimum cost to purchase all
			// discharge decimal part...

			// type 0: discounted price
			// type 1: percentage discount
			// type 2: fixed discount

			// productCode, discountCode{0,*}
			//List<List<string>> products0 = [["10", "d0", "d1"], ["15", "EMPTY", "EMPTY"], ["20", "d1", "EMPTY"]];

			// discountCode, type, value
			// d0, type 1: percentage y = x * (1-val)
			// d1, type 2: fixed discount y = x - val
			// choose lower
			//List<List<string>> discounts0 = [["d0", "1", "27"], ["d1", "2", "5"]];

			var discountsInfoList = new Dictionary<string, List<DiscountInfo>>();
			foreach (var discount in discounts)
			{
				// same discount code but differnt values

				if (discountsInfoList.TryGetValue(discount[0], out var discountInfos))
				{
					discountInfos.Add(GetDiscountInfo(discount[1], int.Parse(discount[2])));
				}
				else
				{
					discountsInfoList.Add(discount[0], new List<DiscountInfo>
					{
						GetDiscountInfo(discount[1],int.Parse(discount[2]))
					});
				}
			}

			var productsInfo = products.Select(i => GetProductInfo(i, discountsInfoList));

			var total = productsInfo.Sum(i => i.BestPrice);

			return total;
		}

		private static int CalculatePriceTypeZero(int price, int fixedPrice)
			=> fixedPrice;

		private static int CalculatePriceTypeOne(int price, int percentage)
			=> (int)Math.Floor(price * (1 - (percentage / 100d)));

		private static int CalculatePriceTypeTwo(int price, int discount)
			=> price - discount;

		private static DiscountInfo GetDiscountInfo(string type, int value)
		{
			var info = new DiscountInfo();

			switch (type)
			{
				case "0":
					{
						info.CalculatePrice = (price) => CalculatePriceTypeZero(price, value);
						break;
					}

				case "1":
					{
						info.CalculatePrice = (price) => CalculatePriceTypeOne(price, value);
						break;
					}

				case "2":
					{
						info.CalculatePrice = (price) => CalculatePriceTypeTwo(price, value);
						break;
					}

				default:
					{
						info.CalculatePrice = (price) => price;
						break;
					}
			}

			return info;
		}

		private static ProductInfo GetProductInfo(List<string> infoTags, Dictionary<string, List<DiscountInfo>> discountsInfoList)
		{
			var productInfo = new ProductInfo();

			var price = int.Parse(infoTags[0]);

			var discountedPrices = new List<int>()
			{
				price
			};

			foreach (var infoTag in infoTags.Skip(1))
			{
				if (infoTag == EmptyType) continue;

				if (discountsInfoList.TryGetValue(infoTag, out var discountInfos))
				{
					foreach (var discountInfo in discountInfos)
					{
						discountedPrices.Add(discountInfo.CalculatePrice(price));
					}
				}
			}

			if (discountedPrices.Count == 0)
			{
				productInfo.BestPrice = price;
			}
			else
			{
				productInfo.BestPrice = discountedPrices.Min();
			}

			return productInfo;
		}
	}
}
