using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankApp
{
	public static class AngryProfessor
	{
		public static bool IsClassCancelled(int threshold, List<int> arrivals)
		{
			var arrivalCount = 0;
			var notArrivalCount = 0;
			var stopThreshold = arrivals.Count - threshold;

			foreach (int arrival in arrivals)
			{
				if (arrival <= 0) arrivalCount++;
				else notArrivalCount++;

				if (arrivalCount >= threshold) return false;

				if (notArrivalCount >= stopThreshold) return true;
			}

			return true;
		}
	}
}
