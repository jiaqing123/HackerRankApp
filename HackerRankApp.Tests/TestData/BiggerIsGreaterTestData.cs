namespace HackerRankApp.Tests.TestData
{
	public class BiggerIsGreaterTestData : TheoryData<string, string>
	{
		public BiggerIsGreaterTestData()
		{
			//Add("imllmmcslslkyoegymoa", "imllmmcslslkyoegyoam");
			Add("moa", "oam");
		}

		private void AddTest01()
		{
			Add("ab", "ba");

			Add("bb", "no answer");

			Add("hefg", "hegf");

			Add("dhck", "dhkc");

			Add("dkhc", "hcdk");

			Add("lmno", "lmon");

			Add("dcba", "no answer");

			Add("dcbb", "no answer");

			Add("abdc", "acbd");

			Add("abcd", "abdc");

			Add("fedcbabcd", "fedcbabdc");

			Add("dcba", "no answer");

			Add("zzz", "no answer");

			Add("bba", "no answer");

			Add("bccc", "cbcc");

			Add("bcca", "cabc");
		}
	}
}
