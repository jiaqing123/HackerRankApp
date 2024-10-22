namespace HackerRankApp
{
	public static class RequestToServer
	{
		public static List<int> Run(int serverIndexes, List<List<int>> log_data, List<int> query, int X)
		{
			if (query.Count == 0) return new List<int>();

			// [1, n]: serverIndexes
			// log_data: serverId, time
			// find not receive data in time frame: query, x [query[i]-x, query[i]]
			// m: size of log_data

			// not receive request

			// n=3: 0,1,2

			// q: [10, 11], x=5
			// i=1: [10-5,10]
			// i=2: [11-5,11]
			var intervals = query.Select(i => new
			{
				StartTime = i - X,
				EndTime = i,
				Servers = new bool[serverIndexes]
			}).ToList();

			// number of server count not receive request
			// [0,n-1]
			//var servers = new bool[serverIndexes];

			foreach (var data in log_data)
			{
				// [1,n]
				var serverIndex = data[0];
				var serverTime = data[1];

				var serverIntervals = intervals
					.Where(i => i.StartTime <= serverTime && i.EndTime >= serverTime);

				foreach (var serverInterval in serverIntervals)
				{
					serverInterval.Servers[serverIndex - 1] = true;
				}
			}

			var count = intervals
				.Select(i => i.Servers.Count(i => i == false))
				.ToList();

			return count;
		}
	}
}
