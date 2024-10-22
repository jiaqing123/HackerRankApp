namespace HackerRankApp.Tests.TestData
{
	public class LibraryFineTestData : TheoryData<int, int, int, int, int, int, int>
	{
		public LibraryFineTestData()
		{
			Add(14, 7, 2018, 5, 7, 2018, 135);
			Add(9, 6, 2015, 6, 6, 2015, 45);
			Add(6, 6, 2015, 6, 6, 2015, 0);
			Add(6, 5, 2015, 6, 6, 2015, 0);
			Add(12, 31, 2015, 1, 1, 2016, 0);
			Add(1, 12, 2015, 31, 1, 2015, 5500);
			Add(1, 1, 2015, 31, 1, 2015, 0);
			Add(6, 7, 2015, 6, 6, 2015, 500);
			Add(6, 7, 2015, 6, 6, 2014, 10000);
			Add(6, 7, 2015, 6, 6, 2013, 10000);
		}
	}
}
