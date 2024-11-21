namespace HackerRankApp.Tests.TestData;

public class EnglishTextEncryptionTestData : TheoryData<string, string>
{
	public EnglishTextEncryptionTestData()
	{
		Add("",
			"");

		Add("if man was meant to stay on the ground god would have given us roots",
			"imtgdvs fearwer mayoogo anouuio ntnnlvt wttddes aohghn sseoau");

		Add("have a nice day",
			"hae and via ecy");

		Add("feed the dog",
			"fto ehg ee dd");

		Add("chill out",
			"clu hlt io");
	}
}
