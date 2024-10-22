﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankApp
{
	public static class BeautifulDaysAtMovies
	{
		public static int GetNumberOfBeautifulDays(int beginDay, int endDay, int divisor)
		{
			var days = 0;

			for (int i = beginDay; i <= endDay; i++)
			{
				var reversed = GetReverse(i);

				if (Math.Abs(i - reversed) % divisor == 0)
				{
					days++;
				}
			}

			return days;
		}

		private static int GetReverse(int number) => int.Parse(new string(number.ToString().Reverse().ToArray()));
	}
}
