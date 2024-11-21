namespace HackerRankApp.Tests.Algorithm;

public class GridSearchTests
{
	[Fact]
	public void Run_01()
	{
		List<string> G = [
			"1234567890",
			"0987654321",
			"1111111111",
			"1111111111",
			"2222222222",
			];
		List<string> P = [
			"876543",
			"111111",
			"111111",
			];

		string expectation = "YES";

		var handleTask = () => GridSearch.Run(G, P);

		handleTask.Should().NotThrow()
			.Which.Should().BeEquivalentTo(expectation);
	}

	[Fact]
	public void Run_02()
	{
		List<string> G = [
			"7283455864",
			"6731158619",
			"8988242643",
			"3830589324",
			"2229505813",
			"5633845374",
			"6473530293",
			"7053106601",
			"0834282956",
			"4607924137",
			];
		List<string> P = [
			"9505",
			"3845",
			"3530",
			];

		string expectation = "YES";

		var handleTask = () => GridSearch.Run(G, P);

		handleTask.Should().NotThrow()
			.Which.Should().BeEquivalentTo(expectation);
	}

	[Fact]
	public void Run_03()
	{
		List<string> G = [
			"400453592126560",
			"114213133098692",
			"474386082879648",
			"522356951189169",
			"887109450487496",
			"252802633388782",
			"502771484966748",
			"075975207693780",
			"511799789562806",
			"404007454272504",
			"549043809916080",
			"962410809534811",
			"445893523733475",
			"768705303214174",
			"650629270887160",
			];
		List<string> P = [
			"99",
			"99",
			];

		string expectation = "NO";

		var handleTask = () => GridSearch.Run(G, P);

		handleTask.Should().NotThrow()
			.Which.Should().BeEquivalentTo(expectation);
	}
}
