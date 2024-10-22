namespace HackerRankApp
{
	public static class NonDivisibleSubset
	{
		public static int Run(int divisor, List<int> numbers)
		{
			if (divisor == 0) { return 0; }

			if (divisor == 1) { return 1; }

			if (numbers.Count == 0) { return 0; }

			var simpleNumberGroups = numbers.Select(i => i % divisor)
				.GroupBy(i => i)
				.ToDictionary(i => i.Key, i => i.Count());

			var maxSubsetSize = 0;

			while (simpleNumberGroups.Any())
			{
				var numberGroup = simpleNumberGroups.First();

				if (numberGroup.Key == 0)
				{
					maxSubsetSize++;
				}
				else if (numberGroup.Key * 2 == divisor)
				{
					maxSubsetSize++;
				}
				else
				{
					if (simpleNumberGroups.Remove(divisor - numberGroup.Key, out var value))
					{
						maxSubsetSize += Math.Max(numberGroup.Value, value);
					}
					else
					{
						maxSubsetSize += numberGroup.Value;
					}
				}

				simpleNumberGroups.Remove(numberGroup.Key);
			}

			return maxSubsetSize;
		}

		private static IEnumerable<List<int>> SelectNumbers(List<int> numbers, int count, List<int> selected, int start)
		{
			for (int i = start; i + count - 1 < numbers.Count; i++)
			{
				var level0 = new List<int>(selected)
				{
					numbers[i]
				};

				if (i + 1 < numbers.Count && count - 1 > 0)
				{
					var nextNumbers = SelectNumbers(numbers, count - 1, level0, i + 1);

					foreach (var nextNumber in nextNumbers)
					{
						yield return nextNumber;
					}
				}
				else
				{
					yield return level0;
				}
			}

		}
	}
}
