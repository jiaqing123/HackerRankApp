using HackerRankApp.Completed;

namespace HackerRankApp.Tests.Completed
{
    public class ClimbingLeaderboardTests
    {
        [Theory]
        [ClassData(typeof(ClimbingLeaderboardTestData))]
        public void AddNewPlayers_NotThrowException(List<int> rankeds, List<int> players, List<int> newRankeds)
        {
            var handleTask = () => ClimbingLeaderboard.AddNewPlayers(rankeds, players);

            handleTask.Should().NotThrow()
                .Which.Should().BeEquivalentTo(newRankeds);
        }

        // Disable to save time
        //[Theory]
        //[InlineData(@"TestData\ClimbingLeaderboardLargeData06.txt", @"TestData\ClimbingLeaderboardLargeDataResult06.txt")]
        //[InlineData(@"TestData\ClimbingLeaderboardLargeData08.txt", @"TestData\ClimbingLeaderboardLargeDataResult08.txt")]
        //public void AddNewPlayers_LargeData_NotThrowException(string targetFilePath, string expectationFilePath)
        //{
        //	// 06: 5.6s total; 0.85s without validation
        //	var currentDirPath = Directory.GetCurrentDirectory();

        //	var path = Path.Combine(currentDirPath, targetFilePath);

        //	var lines = File.ReadAllLines(path);

        //	var rankedCount = int.Parse(lines[0]);
        //	var rankeds = lines[1].Split(' ').Select(int.Parse).ToList();
        //	var playerCount = int.Parse(lines[2]);
        //	var players = lines[3].Split(' ').Select(int.Parse).ToList();

        //	var resultPath = Path.Combine(currentDirPath, expectationFilePath);

        //	var newRankeds = File.ReadAllLines(resultPath).Select(int.Parse).ToList();

        //	var handleTask = () => ClimbingLeaderboard.AddNewPlayers(rankeds, players);

        //	handleTask.Should().NotThrow()
        //		.Which.Should().BeEquivalentTo(newRankeds);
        //}
    }
}
