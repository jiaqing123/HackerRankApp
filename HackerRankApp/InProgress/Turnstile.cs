namespace HackerRankApp.InProgress;

public static class Turnstile
{
	private enum Directions
	{
		Enter = 0,
		Exit = 1,
	}

	private class Traveller
	{
		public int Index { get; set; } = -1;

		public int QueueTime { get; set; }

		public Directions Direction { get; set; }

		public int? TravelTime { get; set; }
	}

	private class TravellersInfo
	{
		public int CurrentIndex { get; set; } = 0;

		public int? LastTravelTime { get; set; }

		public Traveller this[int index] { get => Travellers[index]; }

		public List<Traveller> Travellers { get; init; } = [];

		public List<Traveller> Backlogs { get; init; } = [];
	}

	private class TurnstileInfo
	{
		public int CurrentTime { get; set; }

		public Directions DefaultDirection { get; init; } = Directions.Exit;

		public Directions LastDirection { get; set; } = Directions.Exit;
	}

	/// <summary>
	/// Get every person's exit/entry time.
	/// </summary>
	/// <param name="queuingTimeList">Each person's queue time</param>
	/// <param name="directionList">Each person's walk direction</param>
	/// <returns></returns>
	public static List<int> Run(List<int> queuingTimeList, List<int> directionList)
	{
		if (queuingTimeList.Count == 0 || directionList.Count == 0) return [];

		// find the exit time for each of the person in queuingTimeList

		// if there is no previous person
		// exit first

		// if there is previous person, i.e. exit/enter in previous second, follow the previous second

		var travellersInfo = new TravellersInfo();
		var turnstileInfo = new TurnstileInfo();

		travellersInfo.Travellers.AddRange(CreateTravellers(queuingTimeList, directionList));

		while (IsReadyToTravel(travellersInfo))
		{
			var frontTravellers = new List<Traveller>();

			// search person travel at the same time
			if (travellersInfo.Backlogs.Count == 0 || IsReadyToTravel(GetFrontTravellers(travellersInfo), turnstileInfo))
			{
				frontTravellers.AddRange(GetFrontTravellers(travellersInfo));
			}

			// wait/adjust time, or process backlog, or process both
			WaitOrProcessBacklog(turnstileInfo, travellersInfo, frontTravellers);

			// get travellings from backlog and/or frontTravellers
			var travellings = GetTravellings(turnstileInfo, travellersInfo, frontTravellers);

			foreach (var travelling in travellings)
			{
				// what if the current time is less than the queue time? 
				travelling.TravelTime = turnstileInfo.CurrentTime++;
			}

			UpdateInfo(turnstileInfo, travellersInfo, travellings);
		}

		return travellersInfo.Travellers
			.Select(i => i.TravelTime!.Value)
			.ToList();
	}

	private static Traveller CreateTraveller(int index, List<int> queuingTimeList, List<int> directionList) => new()
	{
		Direction = (Directions)directionList[index],
		Index = index,
		QueueTime = queuingTimeList[index],
	};

	private static IEnumerable<Traveller> CreateTravellers(List<int> queuingTimeList, List<int> directionList)
	{
		for (int i = 0; i < queuingTimeList.Count; i++)
		{
			yield return CreateTraveller(i, queuingTimeList, directionList);
		}
	}

	/// <summary>
	/// Get list of frontTravellers with the same queuing time
	/// </summary>
	/// <param name="startingIndex"></param>
	/// <param name="queuingTimeList"></param>
	/// <param name="directionList"></param>
	/// <returns></returns>
	private static IEnumerable<Traveller> GetFrontTravellers(TravellersInfo travellersInfo)
	{
		if (travellersInfo.CurrentIndex >= travellersInfo.Travellers.Count) yield break;

		var startingTraveller = travellersInfo[travellersInfo.CurrentIndex];

		yield return startingTraveller;

		for (int i = travellersInfo.CurrentIndex + 1; i < travellersInfo.Travellers.Count; i++)
		{
			var traveller = travellersInfo[i];

			if (traveller.QueueTime == startingTraveller.QueueTime)
			{
				if (traveller.TravelTime == null)
				{
					yield return traveller;
				}
			}
			else
			{
				break;
			}
		}
	}

	private static Directions? GetPreviousSecondDirection(TurnstileInfo turnstileInfo, TravellersInfo travellersInfo)
	{
		if (travellersInfo.LastTravelTime != null &&
			travellersInfo.LastTravelTime == turnstileInfo.CurrentTime - 1)
		{
			return turnstileInfo.LastDirection;
		}

		return null;
	}

	private static IEnumerable<Traveller> GetTravellingsFromBacklog(TravellersInfo travellersInfo, Directions direction)
	{
		foreach (var traveller in travellersInfo.Backlogs.ToList())
		{
			if (traveller.Direction == direction)
			{
				travellersInfo.Backlogs.Remove(traveller);

				yield return traveller;
			}
		}
	}

	private static IEnumerable<Traveller> GetTravellingsFromFront(TravellersInfo travellersInfo, List<Traveller> frontTravellers, Directions direction)
	{
		foreach (var traveller in frontTravellers.ToList())
		{
			if (traveller.Direction == direction)
			{
				frontTravellers.Remove(traveller);

				yield return traveller;
			}
			else
			{
				travellersInfo.Backlogs.Add(traveller);
			}
		}
	}

	/// <summary>
	/// Get travelling travellers from backlog or frontTravellers
	/// </summary>
	/// <param name="turnstileInfo"></param>
	/// <param name="backlogTravellers">travellers not travelled last time</param>
	/// <param name="frontTravellers">travellers in the front of the queue</param>
	/// <returns></returns>
	private static List<Traveller> GetTravellings(TurnstileInfo turnstileInfo, TravellersInfo travellersInfo, List<Traveller> frontTravellers)
	{
		// if no previous travel, exit first
		// if previous travel exists in the last second, follow last travel direction
		var travellings = new List<Traveller>();

		//var previousDirection = GetPreviousSecondDirection(turnstileInfo, travellersInfo);
		var direction = GetPreviousSecondDirection(turnstileInfo, travellersInfo) ?? turnstileInfo.DefaultDirection;

		if (travellersInfo.Backlogs.Count > 0)
		{
			// probably gets nothing. in previous second, the travel with the same direction will finish travel and none left
			travellings.AddRange(GetTravellingsFromBacklog(travellersInfo, direction));
		}

		travellings.AddRange(GetTravellingsFromFront(travellersInfo, frontTravellers, direction));

		if (travellings.Count == 0)
		{
			// process backlog first
			if (travellersInfo.Backlogs.Count > 0)
			{
				travellings.AddRange(travellersInfo.Backlogs);

				travellersInfo.Backlogs.Clear();
			}
			else
			{
				travellings.AddRange(frontTravellers);
			}
		}

		return travellings;
	}

	private static bool IsReadyToTravel(TravellersInfo travellersInfo)
	{
		if (travellersInfo.Backlogs.Count > 0) return true;

		if (travellersInfo.CurrentIndex < travellersInfo.Travellers.Count) return true;

		return false;
	}

	private static bool IsReadyToTravel(IEnumerable<Traveller> travellers, TurnstileInfo turnstileInfo)
	{
		if (!travellers.Any()) return false;

		return travellers.First().QueueTime <= turnstileInfo.CurrentTime;
	}

	private static void UpdateInfo(TurnstileInfo turnstileInfo, TravellersInfo travellersInfo, List<Traveller> travellings)
	{
		var lastTravelling = travellings[^1];

		travellersInfo.LastTravelTime = lastTravelling.TravelTime;
		turnstileInfo.LastDirection = lastTravelling.Direction;
	}

	private static void WaitOrProcessBacklog(TurnstileInfo turnstileInfo, TravellersInfo travellersInfo, List<Traveller> frontTravellers)
	{
		if (IsReadyToTravel(frontTravellers, turnstileInfo))
		{
			travellersInfo.CurrentIndex = frontTravellers[^1].Index + 1;
		}
		else
		{
			if (travellersInfo.Backlogs.Count == 0)
			{
				// wait/adjust time
				turnstileInfo.CurrentTime = frontTravellers[0].QueueTime;

				travellersInfo.CurrentIndex = frontTravellers[^1].Index + 1;
			}
			else
			{
				// process backlog
				frontTravellers.Clear();
			}
		}
	}
}
