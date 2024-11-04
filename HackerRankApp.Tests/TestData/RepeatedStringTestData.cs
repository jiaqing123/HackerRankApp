namespace HackerRankApp.Tests.TestData
{
	public class RepeatedStringTestData : TheoryData<string, long, long>
	{
		public RepeatedStringTestData()
		{
			Add("abcac", 10, 4);
			Add("aba", 10, 7);
			Add("aba", 0, 0);
			Add("abcdabcda", 9, 3);
			Add("a", 1000000000000, 1000000000000);
			Add("abcabc", 6, 2);
			Add("abcabc", 9, 3);
			Add("abcabc", 10, 4);
			Add("abcabc", 0, 0);
			Add("abcabc", 1, 1);
			Add("abcabc", 3, 1);
			Add("abcabc", 4, 2);
			Add("", 4, 0);
			Add("aabaab", 10, 7);
			Add("aabaabc", 10, 6);
			Add("aabaaba", 10, 7);
		}
	}
}
