namespace HackerRankApp
{
	public static class RepeatedString
	{
		public static long Run_Simple(string repeating, long count)
		{
			var indecis = GetIndecis(repeating);

			var times = count / repeating.Length;
			var remainder = count % repeating.Length;

			var frequence = indecis.Count * times + indecis.Count(i => i < remainder);

			return frequence;
		}

		public static long Run(string repeating, long count)
		{
			if (repeating.Length == 0) return 0;

			var pattern = FindPattern(repeating);

			var indecis = GetIndecis(pattern);

			var times = count / pattern.Length;
			var remainder = count % pattern.Length;

			var frequence = indecis.Count * times + indecis.Count(i => i < remainder);

			return frequence;
		}

		private static List<int> GetIndecis(string pattern)
		{
			var result = new List<int>();

			for (int i = 0; i < pattern.Length; i++)
			{
				if (pattern[i] == 'a') result.Add(i);
			}

			return result;
		}

		private static string FindPattern(string repeating)
		{
			for (int i = 0; ; i++)
			{
				var length = i + 1;

				var pattern = repeating.Substring(0, length);

				var unmatched = false;

				if (length * 2 < repeating.Length)
				{
					for (var j = length; j < repeating.Length; j += length)
					{
						if (j + length >= repeating.Length)
						{
							// unable to find pattern
							unmatched = true;
							break;
						}
						else if (pattern == repeating.Substring(j, length))
						{
							continue;
						}
						else
						{
							unmatched = true;
							break;
						}
					}

					if (!unmatched)
					{
						return pattern;
					}
				}
				else
				{
					return repeating;
				}
			}
		}
	}
}
