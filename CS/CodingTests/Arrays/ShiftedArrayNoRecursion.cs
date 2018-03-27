namespace CodingTests.Arrays
{
    public static class ShiftedArrayNoRecursion
    {
        public static void Test()
        {
            var index = ShiftedArrSearch(new int[] { 1, 2 }, 2);
            index = ShiftedArrSearch(new int[] { 0, 1, 2, 3, 4, 5 }, 1);
            index = ShiftedArrSearch(new int[] { 1, 2, 3, 4, 5, 0 }, 0);
        }

        public static int ShiftedArrSearch(int[] shiftArr, int num)
        {
            if (shiftArr[0] == num)
            {
                return 0;
            }

            var pivot = FindOffset(shiftArr);
            if (shiftArr[0] > num)
            {
                return BinarySearch(shiftArr, num, pivot, shiftArr.Length - 1);
            }

            return BinarySearch(shiftArr, num, 0, pivot - 1);
        }

        private static int FindOffset(int[] array)
        {
            int low = 0;
            int high = array.Length - 1;
            int offset = -1;
            while (low <= high && offset == -1 )
            {
                var mid = (low + high) / 2;
                if (mid == 0)
                {
                    offset = 0;
                    continue;
                }

                if (array[mid] < array[mid - 1])
                {
                    offset = mid;
                }
                else if (array[mid - 1] > array[0])
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            if (offset > - 1)
            {
                return offset;
            }

            return 0;
        }

        private static int BinarySearch(int[] array, int num, int low, int high)
        {
            int index = -1;
            while (low <= high && index == -1)
            {
                var mid = (low + high) / 2;
                if (array[mid] == num)
                {
                    index = mid;
                }

                else if (array[mid] > num)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return index;
        }
    }
}
