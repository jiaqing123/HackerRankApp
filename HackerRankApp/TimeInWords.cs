using System.Text;

namespace HackerRankApp
{
	public static class TimeInWords
	{
		private static readonly string OClock = "o' clock";
		private static readonly string Past = "past";
		private static readonly string To = "to";
		private static readonly string Minute = "minute";
		private static readonly string Minutes = "minutes";
		private static readonly Dictionary<int, string> Numbers = new Dictionary<int, string>
		{
			{0, "twelve" },
			{1, "one"},
			{2, "two" },
			{3, "three" },
			{4, "four" },
			{5, "five" },
			{6, "six" },
			{7, "seven" },
			{8, "eight" },
			{9, "nine" },
			{10, "ten" },
			{11, "eleven" },
			{12, "twelve" },
			{13, "thirteen" },
			{14, "forteen" },
			{15, "quarter" },
			{16, "sixteen" },
			{17, "seventeen" },
			{18, "eighteen" },
			{19, "nineteen" },
			{20, "twenty" },
			{30, "half" },
		};

		public static string Run(int hour, int minutes)
		{
			// minutes == 0; o' clock
			// 1 <= minutes <= 30: pass
			// 31 <= minutes <= 59: to

			var builder = new StringBuilder();

			// minutes / verb / hour

			if (minutes == 0)
			{
				// o'clock
				builder.Append(Numbers[hour]);
				builder.Append(' ');
				builder.Append(OClock);
			}
			else if (minutes > 0 && minutes <= 30)
			{
				// pass
				builder.AppendTimeWords(hour, minutes, Past);
			}
			else if (minutes > 30 && minutes < 59)
			{
				var toMinutes = 60 - minutes;
				var toHour = (hour + 1) % 12;

				builder.AppendTimeWords(toHour, toMinutes, To);
			}

			return builder.ToString();
		}

		// 0 <= minutes <= 30
		private static void AppendTimeWords(this StringBuilder builder, int hour, int minutes, string verb)
		{
			if (minutes > 20 && minutes < 30)
			{
				builder.Append(Numbers[20]);
				builder.Append(' ');
				builder.Append(Numbers[minutes % 20]);
				builder.Append(' ');
			}
			else
			{
				builder.Append(Numbers[minutes]);
				builder.Append(' ');
			}

			if (minutes == 1)
			{
				builder.Append(Minute);
				builder.Append(' ');
			}
			else if (minutes % 15 != 0)
			{
				builder.Append(Minutes);
				builder.Append(' ');
			}

			builder.Append(verb);
			builder.Append(' ');

			builder.Append(Numbers[hour]);
		}
	}
}