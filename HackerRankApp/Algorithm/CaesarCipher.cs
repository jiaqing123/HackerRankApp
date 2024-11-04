using System.Text;

namespace HackerRankApp.Algorithm
{
	/// <summary>
	/// https://www.hackerrank.com/challenges/caesar-cipher-1/problem
	/// </summary>
	public static class CaesarCipher
	{
		private static readonly CharRange EmptyRange = new('0', '0');
		private static readonly CharRange LowerRange = new('a', 'z');
		private static readonly CharRange UpperRange = new('A', 'Z');

		private class CharRange(char start, char end)
		{
			public char Start { get; } = start;

			public char End { get; } = end;

			public int Count { get; } = end - start + 1;
		}

		public static string Run(string clearText, int rotationFactor)
		{
			if (!Verify(clearText, rotationFactor)) return clearText;

			var builder = new StringBuilder();

			foreach (char chr in clearText)
			{
				var range = GetRange(chr);

				builder.Append(CipherChar(chr, range, rotationFactor));
			}

			return builder.ToString();
		}

		private static char CipherChar(char chr, CharRange range, int rotationFactor)
		{
			if (range == EmptyRange) return chr;

			var ciphered = (chr - range.Start + rotationFactor) % range.Count;

			return (char)(range.Start + ciphered);
		}

		private static CharRange GetRange(char chr)
		{
			if (chr >= LowerRange.Start && chr <= LowerRange.End) return LowerRange;

			if (chr >= UpperRange.Start && chr <= UpperRange.End) return UpperRange;

			return EmptyRange;
		}

		private static bool Verify(string clearText, int rotationFactor)
		{
			if (string.IsNullOrEmpty(clearText)) return false;

			if (rotationFactor < 0) return false;

			return true;
		}
	}
}
