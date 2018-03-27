namespace CodingTests.Arrays
{
    public class DeleteArrayItems
    {
        public static int DeleteItems(int[] array, int number)
        {
            int size = 0, swapFrom = 0, deletedSpaces = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number)
                {
                    deletedSpaces++;
                    swapFrom = swapFrom == 0 ? i + 1 : swapFrom;
                }

                if (deletedSpaces > 0 && i < array.Length - 1)
                {
                    swapFrom = FindNotNumber(array, swapFrom, number);
                    if (swapFrom < array.Length)
                    {
                        array[i] = array[swapFrom++];
                    }
                    else if (deletedSpaces > 0)
                    {
                        size = i;
                    }
                }
            }

            if (size == 0)
            {
                size = array.Length - deletedSpaces;
            }

            return size;
        }

        private static int FindNotNumber(int[] array, int start, int number)
        {
            bool notFound = true;
            while(notFound && start < array.Length)
            {
                notFound = array[start] == number;
                start++;
            }
            return start - 1;
        }
    }
}
