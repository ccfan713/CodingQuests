using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingApp.Code
{
    public class SlidingWindowMax
    {
        public static void Test()
        {
            var output = GetMax(new int[] { 1, -1 }, 1);
            output = GetMax(new int[] { 1, -1, -2 }, 1);
            output = GetMax(new int[] { 1, 3, 1, 2, 0, 5 }, 3);
        }

        public static int[] GetMax(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0)
            {
                return new int [0];
            }

            int[] output = new int[nums.Length - k + 1];
            int maxIndex = 0, secondMaxIndex = 0, j = 0;

            for (int i = 1; i < k; i++)
            {
                if (nums[i] > nums[maxIndex])
                {
                    secondMaxIndex = maxIndex;
                    maxIndex = i;
                }
                else if (nums[i] > nums[secondMaxIndex])
                {
                    secondMaxIndex = i;
                }
            }

            output[j++] = nums[maxIndex];

            for (int windowEnd = k; windowEnd < nums.Length; j++, windowEnd++)
            {
                if (maxIndex < windowEnd - k + 1)
                {
                    maxIndex = secondMaxIndex;
                }

                // last item is largest or maxIndex is outside window along with secondMaxIndex (possible for k = 1)
                if (nums[windowEnd] >= nums[maxIndex] || maxIndex < windowEnd - k + 1)
                {
                    secondMaxIndex = maxIndex;
                    maxIndex = windowEnd;
                }
                else
                {
                    // find second max index
                    var windowStart = windowEnd - k + 1;
                    secondMaxIndex = windowStart == maxIndex ? windowStart + 1: windowStart;
                    var l = secondMaxIndex + 1;
                    while (l <= windowEnd)
                    {
                        if(l != maxIndex && nums[l] >= nums[secondMaxIndex])
                        {
                            secondMaxIndex = l;
                        }

                        l++;
                    }
                }

                output[j] = nums[maxIndex];
            }

            return output;
        }
    }
}
