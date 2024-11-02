namespace HackerRankApp.Tests.TestData
{
	public class PrimeNumberGeneratorTestData : TheoryData<List<int>, List<int>, int>
	{
		public PrimeNumberGeneratorTestData()
		{
			AddTest01();

			AddTest02();

			AddTest03();

			AddTest04();

			AddTest05();

			AddTest06();

			AddTest07();

			AddTest08();
		}

		private void AddTest01()
		{
			var arr = new List<int>
			{
				2, 4
			};

			var brr = new List<int>
			{
				16, 32, 96
			};

			var result = 3;

			Add(arr, brr, result);
		}

		private void AddTest02()
		{
			var arr = new List<int>
			{
				100, 99, 98, 97, 96, 95, 94, 93, 92, 91
			};

			var brr = new List<int>
			{
				1, 2, 3, 4, 5, 6, 7, 8, 9, 10
			};

			var result = 0;

			Add(arr, brr, result);
		}

		private void AddTest03()
		{
			var arr = new List<int>
			{
				1
			};

			var brr = new List<int>
			{
				100
			};

			var result = 9;

			Add(arr, brr, result);
		}

		private void AddTest04()
		{
			var arr = new List<int>
			{
				2
			};

			var brr = new List<int>
			{
				20, 30, 12
			};

			var result = 1;

			Add(arr, brr, result);
		}

		private void AddTest05()
		{
			var arr = new List<int>
			{
				3, 4
			};

			var brr = new List<int>
			{
				24, 48
			};

			var result = 2;

			Add(arr, brr, result);
		}

		private void AddTest06()
		{
			var arr = new List<int>
			{
				51
			};

			var brr = new List<int>
			{
				50
			};

			var result = 0;

			Add(arr, brr, result);
		}

		private void AddTest07()
		{
			var arr = new List<int>
			{
				2, 3, 6
			};

			var brr = new List<int>
			{
				42, 84
			};

			var result = 2;

			Add(arr, brr, result);
		}

		private void AddTest08()
		{
			var arr = new List<int>
			{
				1
			};

			var brr = new List<int>
			{
				72, 48
			};

			var result = 8;

			Add(arr, brr, result);
		}
	}
}
