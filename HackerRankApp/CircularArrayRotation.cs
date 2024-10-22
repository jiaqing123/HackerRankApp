namespace HackerRankApp
{
	public static class CircularArrayRotation
	{
		public static List<int> GetRotatedValues(List<int> values, int shiftCount, List<int> queries)
		{
			var shifts = shiftCount % values.Count;

			var rotatedValues = values.GetRange(values.Count - shifts, shifts)
					.Concat(values.GetRange(0, values.Count - shifts))
					.ToList();

			if (queries.Any())
			{
				return queries.Select(i => rotatedValues[i]).ToList();
			}
			else
			{
				return new List<int>();
			}
		}
	}
}
