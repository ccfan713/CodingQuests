using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTests.DP
{
    public class SubsetSum
    {
        public static void Test()
        {
            ComputeSubsetSums(new int[] { 2, 3, 5, 6, 8, 10 }, 10);
            ComputeSubsetSums(new int[] { 1, 3, 5, 8, 10 }, 18);
        }

        private static void ComputeSubsetSums(int[] array, int targetSum)
        {
            bool[,] sumPossible = new bool[array.Length, targetSum + 1];
            for (int k = 0; k < array.Length; k++)
            {
                sumPossible[k, array[0]] = true;
            }
            for(int i = 1; i < array.Length; i++)
            {
                sumPossible[i, 0] = true;
                for(int j = 1; j <= targetSum; j++)
                {
                    sumPossible[i, j] = array[i] < j ? sumPossible[i, j - array[i]] || sumPossible[i-1, j] : sumPossible[i-1, j];
                }
            }

            FindSubsets(sumPossible, array, array.Length - 1, targetSum, targetSum, new List<int>());
        }

        private static void FindSubsets(bool[,] sumPossible, int[] array, int n, int sum, int targetSum, List<int> subset)
        {
            if (sum == 0 && n == 0)
            {
                Display(subset);
                return;
            }

            if (sum == array[n])
            {
                subset.Add(sum);
                Display(subset);
                return;
            }

            if (sum == targetSum && sumPossible[n-1, sum])
            {
                // try summing without nth element
                subset = new List<int>();
                FindSubsets(sumPossible, array, n - 1, sum, targetSum, subset);
            }

            if (sum >= array[n] && sumPossible[n-1, sum - array[n]])
            {
                // try summing with nth element
                subset.Add(array[n]);
                FindSubsets(sumPossible, array, n - 1, sum - array[n], targetSum, subset);
            }
        }

        private static void Display(List<int> subset)
        {
            foreach(var i in subset)
            {
                Console.Write(" " + i);
            }

            Console.WriteLine();
        }
    }
}
