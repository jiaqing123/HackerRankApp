namespace HackerRankApp
{
	/// <summary>
	/// it does not 
	/// </summary>
	public static class DeliveryManagementSystem
	{
		private class Area
		{
			public City this[int number] { get => Cities[number]; }

			public Dictionary<int, City> Cities { get; set; } = [];
		}

		private class City
		{
			public int Level { get; set; } = int.MaxValue;

			public int Number { get; set; }

			public List<City> Neighbours { get; set; } = [];
		}

		private class DeliveryContext
		{
		}

		private class DeliveryResult
		{
			public City Start { get; init; }

			public List<City> Cities { get; set; } = [];

			public List<DeliveryResult> Nexts { get; set; } = [];

			public DeliveryResult(City start)
			{
				Start = start;
			}
		}

		private static void PrintList(List<int> list, int start, int length)
		{
			Console.WriteLine(list[start..length].Select(i => i.ToString()).Aggregate((i, j) => $"{i},{j}"));
		}

		public static List<int> Run(int cityNodes, List<int> cityFroms, List<int> cityTos, int company)
		{
			var area = CreateArea(cityNodes, cityFroms, cityTos);

			// starting from company number, e.g. 1, the first company or the nodes

			var startCity = area[company];
			var context = new DeliveryContext();

			// go to nearest city, 2
			startCity.Level = 0;

			var result = DeliverGoods(startCity, context);

			// next is 3, 4

			var orders = GetDeliveryOrders(result);

			return orders;
		}

		private static Area CreateArea(int cityNodes, List<int> cityFroms, List<int> cityTos)
		{
			var area = new Area();

			for (int number = 1; number <= cityNodes; number++)
			{
				area.Cities.Add(number, new City { Number = number });
			}

			for (int i = 0; i < cityFroms.Count; i++)
			{
				var cityFrom = area[cityFroms[i]];
				var cityTo = area[cityTos[i]];

				cityFrom.Neighbours.Add(cityTo);
				cityTo.Neighbours.Add(cityFrom);
			}

			return area;
		}

		private static DeliveryResult DeliverGoods(City city, DeliveryContext context)
		{
			var result = new DeliveryResult(city);

			var nextLevel = city.Level + 1;

			var neighbours = city.Neighbours
				.Where(i => i.Level > nextLevel)
				.ToList();

			if (neighbours.Count == 0) return result;

			neighbours.ForEach(i => i.Level = nextLevel);

			result.Cities.AddRange(neighbours);

			foreach (var neighbour in neighbours)
			{
				var neighbourResult = DeliverGoods(neighbour, new DeliveryContext());

				result.Nexts.Add(neighbourResult);
			}

			return result;
		}

		private static void AddDeliveryOrders(DeliveryResult result, int level, List<int> orders)
		{
			var cities = GetDeliveryCities(result, level);

			orders.AddRange(cities.Select(i => i.Number).Distinct().OrderBy(i => i));
		}

		private static List<City> GetDeliveryCities(DeliveryResult result, int level)
		{
			var cities = new List<City>();

			cities.AddRange(result.Cities.Where(i => i.Level == level));

			foreach (var next in result.Nexts)
			{
				cities.AddRange(GetDeliveryCities(next, level));
			}

			return cities;
		}

		private static List<int> GetDeliveryOrders(DeliveryResult result)
		{
			List<int> orders = [];
			int levels = GetDeliveryOrderLevel(result);

			for (int i = 1; i <= levels; i++)
			{
				AddDeliveryOrders(result, i, orders);
			}

			return orders;
		}

		private static int GetDeliveryOrderLevel(DeliveryResult result)
		{
			if (result.Cities.Count == 0) return result.Start.Level;

			var maxLevel = result.Cities.Max(i => i.Level);

			foreach (var next in result.Nexts)
			{
				var nextLevel = GetDeliveryOrderLevel(next);

				if (nextLevel > maxLevel)
				{
					maxLevel = nextLevel;
				}
			}

			return maxLevel;
		}
	}
}
