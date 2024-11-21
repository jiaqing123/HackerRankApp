namespace HackerRankApp.Algorithm;

/// <summary>
/// https://www.hackerrank.com/challenges/happy-ladybugs/problem
/// </summary>
public static class HappyLadybugs
{
	private class ColorGroup
	{
		public char Color { get; init; }

		public List<int> Items { get; init; } = [];

		public List<int> WaitingItems { get; init; } = [];

		public void ProcessWaitings()
		{
			if (WaitingItems.Count > 0)
			{
				Items.AddRange(WaitingItems);

				WaitingItems.Clear();
			}
		}
	}

	private const string Yes = "YES";
	private const string No = "NO";

	public static string Run(string initial)
	{
		Dictionary<char, ColorGroup> colors = [];
		Dictionary<char, ColorGroup> waitingColors = [];
		bool spaceAvailable = false;

		for (int i = 0; i < initial.Length; i++)
		{
			var color = initial[i];

			if (color == '_')
			{
				spaceAvailable = true;

				if (waitingColors.Count > 0)
				{
					foreach (var colorGroup in waitingColors)
					{
						colorGroup.Value.ProcessWaitings();
					}

					waitingColors.Clear();
				}
			}
			else if (colors.TryGetValue(color, out var colorGroup))
			{
				if (colorGroup.Items[^1] == i - 1)
				{
					colorGroup.Items.Add(i);
				}
				else if (spaceAvailable)
				{
					colorGroup.ProcessWaitings();

					waitingColors.Remove(color);

					colorGroup.Items.Add(i);
				}
				else
				{
					colorGroup.WaitingItems.Add(i);

					waitingColors.TryAdd(color, colorGroup);
				}
			}
			else
			{
				colors.Add(color, new ColorGroup
				{
					Color = color,
					Items = [i]
				});
			}
		}

		if (colors.Any(i => i.Value.WaitingItems.Count > 0))
		{
			return No;
		}
		else if (colors.Any(i => i.Value.Items.Count == 1))
		{
			return No;
		}

		return Yes;
	}
}
