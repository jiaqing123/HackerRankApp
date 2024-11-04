namespace HackerRankApp.Tests.Algorithm
{
	/// <summary>
	/// Total number of tests are 8, swaping the left and right columns of the existing test
	/// </summary>
	public class MatrixRotateTests
	{
		[Fact]
		public void Rotate_90Degrees01_RotationSuccessful()
		{
			var matrix = new List<List<int>> {
				new() { 8, 3, 4 },
				new() { 1, 5, 9 },
				new() { 6, 7, 2 }
			};

			var expectation = new List<List<int>> {
				new() { 4, 9, 2 },
				new() { 3, 5, 7 },
				new() { 8, 1, 6 }
			};

			var handleTask = () => MatrixRotate.Rotate(matrix);

			handleTask.Should().NotThrow()
				.Which.Should().BeEquivalentTo(expectation);
		}

		[Fact]
		public void Rotate_90Degrees02_RotationSuccessful()
		{
			var matrix = new List<List<int>> {
				new() { 4, 9, 2 },
				new() { 3, 5, 7 },
				new() { 8, 1, 6 }
			};

			var expectation = new List<List<int>> {
				new() { 2, 7, 6 },
				new() { 9, 5, 1 },
				new() { 4, 3, 8 }
			};

			var handleTask = () => MatrixRotate.Rotate(matrix);

			handleTask.Should().NotThrow()
				.Which.Should().BeEquivalentTo(expectation);
		}

		[Fact]
		public void Rotate_90Degrees03_RotationSuccessful()
		{
			var matrix = new List<List<int>> {
				new() { 2, 7, 6 },
				new() { 9, 5, 1 },
				new() { 4, 3, 8 }
			};

			var expectation = new List<List<int>> {
				new() { 6, 1, 8 },
				new() { 7, 5, 3 },
				new() { 2, 9, 4 }
			};

			var handleTask = () => MatrixRotate.Rotate(matrix);

			handleTask.Should().NotThrow()
				.Which.Should().BeEquivalentTo(expectation);
		}

		[Fact]
		public void Rotate_90Degrees04_RotationSuccessful()
		{
			var matrix = new List<List<int>> {
				new() { 6, 1, 8 },
				new() { 7, 5, 3 },
				new() { 2, 9, 4 }
			};

			var expectation = new List<List<int>> {
				new() { 8, 3, 4 },
				new() { 1, 5, 9 },
				new() { 6, 7, 2 }
			};

			var handleTask = () => MatrixRotate.Rotate(matrix);

			handleTask.Should().NotThrow()
				.Which.Should().BeEquivalentTo(expectation);
		}
	}

}
