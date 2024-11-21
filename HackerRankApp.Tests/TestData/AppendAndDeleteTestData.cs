namespace HackerRankApp.Tests.TestData;

public class AppendAndDeleteTestData : TheoryData<string, string, int, bool>
{
	public AppendAndDeleteTestData()
	{
		Add("", "", 0, true);
		Add("a", "", 1, true);
		Add("", "a", 1, true);
		Add("aabc", "abc", 5, true);
		Add("abc", "def", 6, true);
		Add("abc", "abc", 0, true);
		Add("abc", "abcd", 7, true);
		Add("abab", "abcd", 3, false);
		Add("eabab", "abcd", 3, false);
		Add("abababa", "abcde", 8, true);
		Add("hackerhappy", "hackerrank", 9, true);
		Add("aba", "aba", 7, true);
		Add("ashley", "ash", 2, false);
	}
}
