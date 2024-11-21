namespace HackerRankApp.Algorithm;

/// <summary>
/// https://www.hackerrank.com/challenges/jumping-on-the-clouds-revisited/problem
/// </summary>
public static class JumpingOnCloudsRevisited
{
	public static int GetRemainingEnergy(int[] clouds, int jump)
	{
		// clouds.Count(n): [2, 25]
		// jump: [1, n]
		// n % k = 0 // not always
		// cloud[i]=0|1

		var energy = 100;
		var i = GetNextIndex(0, jump, clouds.Length);

		while (i > 0)
		{
			energy--;

			if (clouds[i] == 1) energy -= 2;

			i = GetNextIndex(i, jump, clouds.Length);
		}

		energy--;
		if (clouds[0] == 1) energy -= 2;

		return energy;
	}

	private static int GetNextIndex(int i, int k, int count) => (i + k) % count;
}
