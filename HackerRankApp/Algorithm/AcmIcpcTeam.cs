using System.Collections;

namespace HackerRankApp.Algorithm
{
	/// <summary>
	/// https://www.hackerrank.com/challenges/acm-icpc-team/problem
	/// </summary>
	public static class AcmIcpcTeam
	{
		public static List<int> Run(List<string> topics)
		{
			var topicArr = topics.Select(ConvertToBoolArray).ToList();
			var combineds = new List<int>();

			for (int i = 0; i < topicArr.Count - 1; i++)
			{
				for (int j = i + 1; j < topicArr.Count; j++)
				{
					var combinedTopic = new BitArray(topicArr[i]).Or(new BitArray(topicArr[j]));

					var combined = 0;
					for (int k = 0; k < combinedTopic.Count; k++)
					{
						if (combinedTopic[k] == true)
						{
							combined++;
						}
					}
					combineds.Add(combined);
				}
			}

			var max = combineds.Max(i => i);
			var count = combineds.Count(i => i == max);

			return [max, count];
		}

		private static bool[] ConvertToBoolArray(string topics) => topics.Select(i => i == '1').ToArray();
	}
}
