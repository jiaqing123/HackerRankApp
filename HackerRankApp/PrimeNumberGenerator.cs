namespace HackerRankApp
{
	public static class PrimeNumberGenerator
	{
		private static List<int> primeNumbers = new List<int>();

		private static Dictionary<int, int> GetCommonPrimeFactors(List<int> numbers)
		{
			var multiplier = new Dictionary<int, int>();

			foreach (int number in numbers)
			{
				var factors = GetFactors(number);

				foreach (var group in factors.GroupBy(e => e))
				{
					if (multiplier.ContainsKey(group.Key))
					{
						if (multiplier[group.Key] < group.Count())
						{
							multiplier[group.Key] = group.Count();
						}
					}
					else
					{
						multiplier.Add(group.Key, group.Count());
					}
				}
			}

			return multiplier;
		}

		private static IEnumerable<int> GetFactors(int number)
		{
			if (IsNonCompositeNumber(number))
			{
				yield return number;

				yield break;
			}

			var i = 0;
			var nextNumber = number;

			while (nextNumber > 1)
			{
				if (nextNumber % primeNumbers[i] == 0)
				{
					yield return primeNumbers[i];

					nextNumber /= primeNumbers[i];
				}
				else
				{
					i++;
				}
			}
		}

		private static bool IsNonCompositeNumber(int number) => primeNumbers.Contains(number);

		private static List<int> SieveOfEratosthenes(int limit)
		{
			bool[] isPrime = new bool[limit + 1];
			for (int i = 2; i <= limit; i++)
				isPrime[i] = true;

			for (int i = 2; i * i <= limit; i++)
			{
				if (isPrime[i])
				{
					for (int j = i * i; j <= limit; j += i)
					{
						isPrime[j] = false;
					}
				}
			}

			List<int> primes = new List<int>();
			for (int i = 2; i <= limit; i++)
			{
				if (isPrime[i])
				{
					primes.Add(i);
				}
			}

			return primes;
		}

		#region Other Methods

		public static int getTotalX(List<int> a, List<int> b)
		{
			primeNumbers = SieveOfEratosthenes(Math.Max(a.Max(), b.Max())).OrderBy(i => i).ToList();

			var multiplier = GetCommonPrimeFactors(a);

			return GetMimimumQuotient(b, multiplier);
		}

		static List<int> GetAllDivisors(Dictionary<int, int> primeFactors)
		{
			List<int> divisors = new List<int>();
			GetDivisorsRecursive(primeFactors, new List<int>(primeFactors.Keys), 1, 0, divisors);
			return divisors;
		}

		static void GetDivisorsRecursive(Dictionary<int, int> primeFactors, List<int> primes, int currentDivisor, int index, List<int> divisors)
		{
			if (index == primes.Count)
			{
				divisors.Add(currentDivisor);
				return;
			}

			int prime = primes[index];
			int maxExponent = primeFactors[prime];

			for (int exp = 0; exp <= maxExponent; exp++)
			{
				int newDivisor = currentDivisor * (int)Math.Pow(prime, exp);
				GetDivisorsRecursive(primeFactors, primes, newDivisor, index + 1, divisors);
			}
		}

		private static Dictionary<int, int> GetGroupFactors(IEnumerable<int> factors)
			=> factors.OrderBy(i => i).GroupBy(e => e).ToDictionary(g => g.Key, g => g.Count());

		private static Dictionary<int, int> GetCommonFactors(IEnumerable<Dictionary<int, int>> numberFactors)
		{
			return numberFactors.SelectMany(i => i).GroupBy(i => i.Key)
				.Where(i => i.Count() == numberFactors.Count())
				.ToDictionary(i => i.Key, i => i.Select(j => j.Value).Min());
		}

		private static int GetMimimumQuotient(List<int> numbers, Dictionary<int, int> divisor)
		{
			if (divisor.Count() == 0)
			{
				var numbersFactors = new List<Dictionary<int, int>>();

				foreach (int number in numbers)
				{
					var numberFactors = GetGroupFactors(GetFactors(number));

					numbersFactors.Add(numberFactors);
				}

				var commonFactors = GetCommonFactors(numbersFactors);

				var divisors = GetAllDivisors(commonFactors);

				return divisors.Count();
			}
			else
			{
				var numberOptions = new List<int>();
				var numbersFactors = new List<Dictionary<int, int>>();

				foreach (int number in numbers)
				{
					if (number <= 0) return 0;

					var numberFactors = GetGroupFactors(GetFactors(number));
					var options = new List<int>();

					numbersFactors.Add(numberFactors);

					foreach (var numberFactor in numberFactors)
					{
						// should check if it has all keys from divisor
						if (divisor.ContainsKey(numberFactor.Key))
						{
							if (numberFactor.Value < divisor[numberFactor.Key])
							{
								return 0;
							}

							options.Add(numberFactor.Value - divisor[numberFactor.Key] + 1);
						}
					}

					if (options.Count() > 0)
					{
						numberOptions.Add(options.Aggregate((selectedCount, j) => selectedCount * j));
					}
				}

				var numberOptionsWithoutDivisorCount = 0;

				// options without divisor
				var commonFactorsWithoutDivisor = GetCommonFactors(numbersFactors)
					.Where(i => !divisor.ContainsKey(i.Key))
					.ToList();
				if (commonFactorsWithoutDivisor.Count() > 0)
				{
					numberOptionsWithoutDivisorCount = commonFactorsWithoutDivisor.Select(grp => grp.Value).Aggregate((i, j) => i * j);
				}

				// options with divisor
				if (numberOptions.Count() > 0)
				{
					return numberOptions.Min() * (numberOptionsWithoutDivisorCount + 1);
				}

				return 0;
			}
		}

		#endregion

	}
}
