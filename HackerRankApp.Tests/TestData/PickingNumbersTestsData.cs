using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankApp.Tests.TestData
{
	public class PickingNumbersTestsData : TheoryData<List<int>, int>
	{
		public PickingNumbersTestsData()
		{
			AddTest01();

			AddTest02();
		}

		private void AddTest01()
		{
			var numbers = new List<int>()
			{
				4, 6, 5, 3, 3, 1
			};

			var expectation = 3;

			Add(numbers, expectation);
		}

		private void AddTest02()
		{
			var numbers = new List<int>()
			{
				1, 2, 2, 3, 1, 2
			};

			var expectation = 5;

			Add(numbers, expectation);
		}
	}
}
