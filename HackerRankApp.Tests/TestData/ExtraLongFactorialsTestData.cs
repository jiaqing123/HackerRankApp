using System.Numerics;

namespace HackerRankApp.Tests.TestData
{
	public class ExtraLongFactorialsTestData : TheoryData<int, BigInteger>
	{
        public ExtraLongFactorialsTestData()
        {
			Add(25, BigInteger.Parse("15511210043330985984000000"));
        }
    }
}
