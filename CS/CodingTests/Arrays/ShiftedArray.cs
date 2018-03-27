
namespace CodingTests.Arrays
{
    public static class ShiftedArray
    {
        public static void Test()
        {
            var index = ShiftedArrSearch(new int[] { 1, 2 }, 2);
            index = ShiftedArrSearch(new int[] { 0, 1, 2, 3, 4, 5 }, 1);
        }

        public static int ShiftedArrSearch(int[] shiftArr, int num)
        {
            if (shiftArr[0] == num)
            {
                return 0;
            }

            var offset = FindOffset(shiftArr, 0, shiftArr.Length - 1);
            if (shiftArr[0] > num)
            {
                return BinarySearch(shiftArr, num, shiftArr.Length - offset, shiftArr.Length - 1);
            }

            return BinarySearch(shiftArr, num, 0, shiftArr.Length - offset - 1);
        }

        private static int FindOffset(int[] array, int low, int high)
        {
            if (low < 0 || high > array.Length - 1 || low > high)
            {
                return 0;
            }

            var mid = (low + high) / 2;
            if (mid == 0)
            {
                return 0;
            }

            if (array[mid] < array[mid - 1])
            {
                return array.Length - mid;
            }

            if (array[mid - 1] > array[0])
            {
                return FindOffset(array, mid + 1, high);
            }

            return FindOffset(array, low, mid - 1);
        }

        private static int BinarySearch(int[] array, int num, int low, int high)
        {
            if (high > array.Length - 1 || low < 0)
            {
                return -1;
            }

            if (high < low)
            {
                return -1;
            }

            var mid = (high + low) / 2;
            if (array[mid] == num)
            {
                return mid;
            }

            if (array[mid] > num)
            {
                return BinarySearch(array, num, low, mid - 1);
            }

            return BinarySearch(array, num, mid + 1, high);
        }
    }
}
