using System;

namespace CodingTests.DP
{
    public static class CoinChange
    {
        public static void Test()
        {
            var ways = GetWays(4, new long[] { 1, 2, 3 });
        }

        static long GetWays(long n, long[] c)
        {
            long[] waysForSum = new long[n+1];

            Array.Sort(c);
            int coinIndexToUseInSum = 0;
            waysForSum[0] = 1;
            for (int i = 1; i <= n; i++)
            {
                long ways = 0;
                for (int j = 0; j <= coinIndexToUseInSum; j++)
                {
                    ways += waysForSum[i - c[j]];
                }

                // can we use any additional coins?
                if (coinIndexToUseInSum < c.Length - 1 && i == c[coinIndexToUseInSum + 1])
                {
                    coinIndexToUseInSum++;
                    ways++;
                }

                waysForSum[i] = ways;
            }

            return waysForSum[n];
        }
    }
}
