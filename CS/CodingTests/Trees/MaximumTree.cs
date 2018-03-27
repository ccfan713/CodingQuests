namespace CodingTests.Trees
{
    using System.Collections.Generic;

    public class MaximumTree
    {
        public static TreeNode CreateTree(int[] array)
        {
            // find the order of descending ints without changing the order in the array
            return FormTree(array, 0, array.Length - 1);          
        }

        static TreeNode FormTree(int[] array, int startIndex, int endIndex)
        {
            var maxIndex = FindMax(array, startIndex, endIndex);
            if (maxIndex == -1)
            {
                return null;
            }

            var root = new TreeNode { Value = array[maxIndex] };
            root.LeftChild = FormTree(array, startIndex, maxIndex - 1);
            root.RightChild = FormTree(array, maxIndex + 1, endIndex);
            return root;
        }

        static int FindMax(int[] array, int startIndex, int endIndex)
        {
            if (startIndex < 0 || endIndex >= array.Length || startIndex > endIndex)
            {
                return -1;
            }

            int maxIndex = startIndex;
            int i = startIndex + 1;
            while (i <= endIndex)
            {
                if (array[i] > array[maxIndex])
                {
                    maxIndex = i;
                }

                i++;
            }

            return maxIndex;
        }

        public static void Test()
        {
            var testArray1 = new int[] { 3, 2, 1, 6, 0, 5 };
            var root = CreateTree(testArray1);

            var testArray2 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            var root2 = CreateTree(testArray2);

            var testArray3 = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            var root3 = CreateTree(testArray3);
        }
    }
}
