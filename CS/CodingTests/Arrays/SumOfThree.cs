using System;
using System.Collections.Generic;

namespace CodingTests.Arrays
{
    public class SumOfThree
    {
        public static void Test()
        {
            var input = new int[] { -2, 10, 3, 4, 7, -5, 1 };
            var found = HasThreeThatSumTo(input, 3);
            found = HasThreeThatSumTo(input, 4);
            found = HasThreeThatSumTo(input, 0);
        }

        private static bool HasThreeThatSumTo(int[] input, int sum)
        {
            bool found = false;
            HashSet<int> hashSet = new HashSet<int>(input);
            int i = 0, j = 0, one = 0;
            while (!found && i < input.Length - 2)
            {
                j = i + 1;
                one = input[i];
                while (!found && j < input.Length)
                {
                    var twoSum = one + input[j];
                    found = hashSet.Contains(sum - twoSum);
                    j++;
                }

                i++;
            }

            if (found)
            {
                Console.WriteLine(string.Format("Three numbers that sum to {3}: {0}, {1}, {2}", input[i - 1], input[j - 1], sum - (input[i - 1] + input[j - 1]), sum));
            }
            return found;
        }
    }
}
