using System;
class program
{
    static void Main()
    {
        string[] s = Console.ReadLine().Split(' ');

        int n = int.Parse(s[0]);
        int B = int.Parse(s[1]);

        s = Console.ReadLine().Split(' ');

        int[] moneys = new int[2 * B];

        for (int i = 0; i < s.Length; i++)
        {
            moneys[i] = int.Parse(s[i]);
        }
        Console.WriteLine(MinCost(n, B, moneys));

    }

    private static long MinCost(int n, int B, int[] moneys)
    {
        long[,,] DP = new long[2, B + 1, B + 1];
        DP[0, 0, 0] = long.MaxValue;
        DP[1, 0, 0] = long.MaxValue;


        for (int i = 0; i <= B; i++)
        {
            DP[0, 0, i] = long.MaxValue;
            DP[1, i, 0] = long.MaxValue;

        }
        for (int i = 1; i <= B; i++)
        {
            for (int j = 1; j <= B; j++)
            {
                DP[0, i, j] = Math.Min(DP[0, i - 1, j], DP[1, i - 1, j] + moneys[i + j - 1]);
                DP[1, i, j] = Math.Min(DP[1, i, j-1], DP[0, i, j - 1] + moneys[i + j - 1]);
            }
        }
        return Math.Min(DP[0, B, B], DP[1, B, B]);
    }
}

