using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTests.Arrays
{
    public class AltenatePosNeg
    {
        public static void Test()
        {
            var result = ArrangeAlternate(new int[] { 1, 2, 3, -4, -1, 4 });
            result = ArrangeAlternate(new int[] { -5, -2, 5, 2, 4, 7, 1, 8, 0, -8 });
        }

        private static int[] ArrangeAlternate(int[] a)
        {
            var result = new int[a.Length];
            int posIndex = 0, negIndex = 0;
            bool findNegative = true, doneAlternating = false;
            int resultIndex = 0;
            while (resultIndex < result.Length && !doneAlternating)
            {
                if (findNegative)
                {
                    negIndex = ScanArray(a, true, negIndex);
                    if (negIndex >= 0)
                    {
                        result[resultIndex++] = a[negIndex++];
                        findNegative = false;
                    }
                    else
                    {
                        // no more negative numbers left
                        doneAlternating = true;
                        findNegative = false;
                    }
                }
                else
                {
                    posIndex = ScanArray(a, false, posIndex);
                    if(posIndex >= 0)
                    {
                        result[resultIndex++] = a[posIndex++];
                        findNegative = true;
                    }
                    else
                    {
                        // no more positive numbers left
                        doneAlternating = true;
                        findNegative = true;
                    }                    
                }
            }

            var copyIndex = negIndex < 0 ? posIndex : negIndex;
            while(resultIndex < result.Length)
            {
                copyIndex = ScanArray(a, findNegative, copyIndex);
                if (copyIndex >= 0)
                {
                    result[resultIndex++] = a[copyIndex++];
                }
            }

            return result;
        }

        private static int ScanArray(int[] a, bool findNegative, int index)
        {
            int returnIndex = -1;
            while(returnIndex < 0 && index < a.Length)
            {
                if (findNegative && a[index] < 0)
                {
                    returnIndex = index;
                }
                else if (!findNegative && a[index] >= 0)
                {
                    returnIndex = index;
                }

                index++;
            }

            return returnIndex;
        }
    }
}
