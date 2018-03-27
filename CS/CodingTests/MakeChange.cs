namespace CodingTests
{
    public static class MakeChange
    {
        static readonly int[] Denominations = new int[] { 25, 10, 5, 1 };

        private static int Make(int n)
        {
            int[,] sums = new int[n + 1,Denominations.Length];
            return CountWays(n, sums, 0);
        }
        private static int CountWays(int amount, int[,] sums, int index)
        {
            if(sums[amount,index] > 0)
            {
                return sums[amount,index];
            }

            if (index >= Denominations.Length - 1)
            {
                return 1;
            }

            int ways = 0;
            for (int i = 0; i * Denominations[index] < amount; i++)
            {
                int amountRemaining = amount - i * Denominations[index];
                ways += CountWays(amountRemaining, sums, index + 1);
            }

            sums[amount,index] = ways;
            return ways;
        }        
    }
}
