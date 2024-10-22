namespace HackerRankApp.Tests
{
	public class DuplicatedStringElementTests
	{
		[Fact]
		public void Run_InputValid_NoThrowException()
		{
			List<string> arr = ["wood", "metal", "concrete", "glass", "brick", "ceramic", "plastic", "metal", "fiber", "steel", "aluminum", "rubber", "granite", "stone", "copper", "brass", "silver", "gold", "platinum", "concrete"];

			var expected = false;

			var handleTask = () => DuplicatedStringElement.IsStringDuplicated(arr);

			handleTask.Should().NotThrow()
				.Which.Should().Be(expected);
		}
	}
}
