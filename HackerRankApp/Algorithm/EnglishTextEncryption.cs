using System.Text;

namespace HackerRankApp.Algorithm
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/encryption/problem
    /// </summary>
    public static class EnglishTextEncryption
    {
        public static string Run(string original)
        {
            // Remove space
            // Floor(L^1/2) <= Row <= Column <= Ceiling(L^1/2)

            var cleaned = original.Replace(" ", "");

            var boundary = Math.Sqrt(cleaned.Length);
            var row = (int)Math.Floor(boundary);
            var column = (int)Math.Ceiling(boundary);

            if (column * row < cleaned.Length)
            {
                row = column;
            }

            var builder = new StringBuilder();

            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    var index = i + column * j;

                    if (index < cleaned.Length)
                    {
                        builder.Append(cleaned[index]);
                    }
                }

                if (i != column - 1)
                {
                    builder.Append(' ');
                }
            }

            var encrypted = builder.ToString();

            return encrypted;
        }
    }
}
