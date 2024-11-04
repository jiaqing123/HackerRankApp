namespace HackerRankApp.Algorithm
{
	/// <summary>
	/// https://www.hackerrank.com/challenges/climbing-the-leaderboard/problem
	/// </summary>
	public static class ClimbingLeaderboard
	{
		// Custom comparer for descending order
		public class DescendingComparer : IComparer<int>
		{
			public int Compare(int x, int y)
			{
				// Reverse the comparison: return positive if y > x, negative if y < x
				return y.CompareTo(x);
			}
		}

		public static List<int> AddNewPlayers(List<int> rankeds, List<int> players)
		{
			// rankeds: desc
			// players: asc
			// Originate from https://youtu.be/gVt9Ft_i5mU?si=UarOZtjqd8TGQle5
			var newRankeds = new List<int>();
			var descendingComparer = new DescendingComparer();
			var working = rankeds.Distinct().ToList();
			var maxRank = -1;

			for (int i = 0; i < players.Count; i++)
			{
				var player = players[i];

				if (maxRank < 0)
				{
					var result = working.BinarySearch(player, descendingComparer);

					if (result < 0)
					{
						maxRank = ~result + 1;
					}
					else
					{
						maxRank = result + 1;
					}
				}
				else
				{
					for (int j = maxRank <= working.Count ? maxRank - 1 : working.Count - 1; j >= 0; j--)
					{
						if (players[i] == working[j])
						{
							maxRank = j + 1;
							break;
						}
						else if (players[i] > working[j])
						{
							maxRank = j + 1;
							continue;
						}
						else
						{
							break;
						}
					}
				}

				newRankeds.Add(maxRank);
			}

			return newRankeds;
		}

		public static List<int> AddNewPlayers_Timeout01(List<int> rankeds, List<int> players)
		{
			// rankeds: existing rankings
			// players: new players
			// return: new players' rankings

			var newPlayerRanked = new List<int>();

			var newRankeds = rankeds
				.GroupBy(i => i)
				.Select(i => new KeyValuePair<int, int>(i.Key, i.Count()))
				.OrderByDescending(i => i.Key)
				.ToList();

			foreach (var player in players)
			{
				var playerAdded = false;

				for (var i = 0; i < newRankeds.Count; i++)
				{
					var newRanked = newRankeds[i];

					if (newRanked.Key > player)
					{
						continue;
					}
					else if (newRanked.Key == player)
					{
						newRankeds[i] = new KeyValuePair<int, int>(player, newRanked.Value + 1);

					}
					else if (newRanked.Key < player)
					{
						newRankeds.Insert(i, new KeyValuePair<int, int>(player, 1));
					}

					newPlayerRanked.Add(i + 1);
					playerAdded = true;
					break;
				}

				if (!playerAdded)
				{
					newRankeds.Add(new KeyValuePair<int, int>(player, 1));
					newPlayerRanked.Add(newRankeds.Count);
				}
			}

			return newPlayerRanked;
		}

		public static List<int> AddNewPlayers_Timeout02(List<int> rankeds, List<int> players)
		{
			var newPlayerRankeds = new List<int>();

			foreach (var player in players)
			{
				var rankedCount = 0;
				var playerAdded = false;
				var lastRanked = 0;

				for (int i = 0; i < rankeds.Count; i++)
				{
					if (player < rankeds[i])
					{
						if (rankeds[i] != lastRanked)
						{
							lastRanked = rankeds[i];
							rankedCount++;
						}
					}
					else if (player == rankeds[i])
					{
						rankeds.Insert(i, player);
						playerAdded = true;
						break;
					}
					else
					{
						rankeds.Insert(i, player);
						playerAdded = true;
						break;
					}
				}

				if (!playerAdded)
				{
					rankeds.Add(player);
				}

				newPlayerRankeds.Add(rankedCount + 1);
			}

			return newPlayerRankeds;
		}

		public static List<int> AddNewPlayers_Timeout03(List<int> rankeds, List<int> players)
		{
			var newPlayerRankeds = new List<int>();

			for (int i = 0; i < players.Count; i++)
			{
				var player = players[i];

				var rankedCount = 0;
				var playerAdded = false;
				var lastRanked = 0;

				for (int j = 0; j < rankeds.Count; j++)
				{
					if (player < rankeds[j])
					{
						if (rankeds[j] != lastRanked)
						{
							lastRanked = rankeds[j];
							rankedCount++;
						}
					}
					else if (player == rankeds[j])
					{
						rankeds.Insert(j, player);
						playerAdded = true;

						// try next player 
						if (i + 1 < players.Count)
						{
							if (players[i + 1] <= player)
							{
								newPlayerRankeds.Add(rankedCount + 1);

								i++;
								player = players[i];
								continue;
							}
						}
						break;
					}
					else
					{
						rankeds.Insert(j, player);
						playerAdded = true;

						// try next player
						if (i + 1 < players.Count)
						{
							if (players[i + 1] <= player)
							{
								newPlayerRankeds.Add(rankedCount + 1);

								i++;
								player = players[i];
								continue;
							}
						}
						break;
					}
				}

				if (!playerAdded)
				{
					rankeds.Add(player);
				}

				newPlayerRankeds.Add(rankedCount + 1);
			}

			return newPlayerRankeds;
		}

		public static List<int> AddNewPlayers_TimeoutBetter01(List<int> rankeds, List<int> players)
		{
			var newPlayerRankeds = new List<int>();

			for (int i = 0; i < players.Count; i++)
			{
				var player = players[i];

				var playerAdded = false;

				rankeds = rankeds.Distinct().ToList();

				for (int j = 0; j < rankeds.Count; j++)
				{
					if (player < rankeds[j])
					{
						continue;
					}
					else if (player == rankeds[j])
					{
						playerAdded = true;
						newPlayerRankeds.Add(j + 1);

						// try next player 
						if (i + 1 < players.Count)
						{
							if (players[i + 1] <= player)
							{
								i++;
								player = players[i];
								j--;
								continue;
							}
						}
						break;
					}
					else
					{
						rankeds.Insert(j, player);
						playerAdded = true;
						newPlayerRankeds.Add(j + 1);

						// try next player
						if (i + 1 < players.Count)
						{
							if (players[i + 1] <= player)
							{
								i++;
								player = players[i];
								j--;
								continue;
							}
						}
						break;
					}
				}

				if (!playerAdded)
				{
					rankeds.Add(player);
					newPlayerRankeds.Add(rankeds.Count);
				}
			}

			return newPlayerRankeds;
		}

		public static List<int> AddNewPlayers_TimeoutBetter02(List<int> rankeds, List<int> players)
		{
			// failed: 6, 7, 9
			var newPlayerRankeds = new List<int>();

			var defaultComparer = Comparer<int>.Default;
			var reverseComparer = Comparer<int>.Create((x, y) => -defaultComparer.Compare(x, y));

			var rankedArr = rankeds.Distinct().OrderByDescending(i => i).ToArray();

			for (int i = 0; i < players.Count; i++)
			{
				var player = players[i];

				var result = Array.BinarySearch(rankedArr, player, reverseComparer);

				if (result < 0)
				{
					if (-result > rankedArr.Length)
					{
						var tmp = rankedArr.ToList();
						tmp.Add(player);
						rankedArr = tmp.ToArray();
					}
					else
					{
						var tmp = rankedArr.ToList();
						tmp.Insert(-result - 1, player);
						rankedArr = tmp.ToArray();
					}
					newPlayerRankeds.Add(-result);
				}
				else
				{
					newPlayerRankeds.Add(result + 1);
				}
			}

			return newPlayerRankeds;
		}

		public static List<int> AddNewPlayers_TimeoutBetter03(List<int> rankeds, List<int> players)
		{
			// Failed: 6, 7, 9 timeout 
			var newPlayerRankeds = new List<int>();

			var defaultComparer = Comparer<int>.Default;
			var reverseComparer = Comparer<int>.Create((x, y) => -defaultComparer.Compare(x, y));

			rankeds = rankeds.Distinct().OrderByDescending(i => i).ToList();

			var previousPlayer = -1;

			for (int i = 0; i < players.Count; i++)
			{
				var player = players[i];

				if (player == previousPlayer)
				{
					newPlayerRankeds.Add(newPlayerRankeds[newPlayerRankeds.Count - 1]);
					continue;
				}

				var result = rankeds.BinarySearch(player, reverseComparer);

				if (result < 0)
				{
					var index = ~result;

					if (index == rankeds.Count)
					{
						rankeds.Add(player);
					}
					else
					{
						rankeds.Insert(index, player);
					}
					newPlayerRankeds.Add(index + 1);
				}
				else
				{
					newPlayerRankeds.Add(result + 1);
				}

				previousPlayer = player;
			}

			return newPlayerRankeds;
		}

		public static List<int> AddNewPlayers_TimeoutBetter04(List<int> rankeds, List<int> players)
		{
			// rankeds: desc
			// players: asc

			var newPlayerRankeds = new List<int>();

			rankeds = rankeds.Distinct().OrderBy(i => i).ToList();

			var previousPlayer = -1;

			for (int i = 0; i < players.Count; i++)
			{
				var player = players[i];

				if (player == previousPlayer)
				{
					newPlayerRankeds.Add(newPlayerRankeds[newPlayerRankeds.Count - 1]);
					continue;
				}

				var result = rankeds.BinarySearch(player);

				if (result < 0)
				{
					var index = ~result;

					if (index == rankeds.Count)
					{
						rankeds.Add(player);
					}
					else
					{
						rankeds.Insert(index, player);
					}
					newPlayerRankeds.Add(rankeds.Count - index);
				}
				else
				{
					newPlayerRankeds.Add(rankeds.Count - result);
				}

				previousPlayer = player;
			}

			return newPlayerRankeds;
		}
	}
}
