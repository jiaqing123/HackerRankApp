﻿namespace HackerRankApp.Tests.TestData
{
	public class MaxHourGlassSumTestData : TheoryData<List<List<int>>, int>
	{
		public MaxHourGlassSumTestData()
		{
			Add([
				[1, 1, 1, 0, 0, 0],
				[0, 1, 0, 0, 0, 0],
				[1, 1, 1, 0, 0, 0],
				[0, 9, 2, -4, -4, 0],
				[0, 0, 0, -2, 0, 0],
				[0, 0, -1, -2, -4, 0],
				], 13);
		}
	}
}
