using System;
using System.Linq;

namespace CodingApp.Code
{
    public class ProductWithoutSelf
    {
        public static void Test()
        {
            var outputArray = GetWithoutDivision(new int[] { 2, 3, 4, 5 });
            Console.WriteLine("Output: " + string.Join(",", outputArray.Select(i => i.ToString())));
            outputArray = GetWithoutDivision(new int[] { 0, 3, 4, 5 });
            Console.WriteLine("Output: " + string.Join(",", outputArray.Select(i => i.ToString())));
            outputArray = GetWithoutDivision(new int[] { 2, 3, -4, 5 });
            Console.WriteLine("Output: " + string.Join(",", outputArray.Select(i => i.ToString())));
            outputArray = GetWithoutDivision(new int[] { 2, 3, 4, 0, -2 });
            Console.WriteLine("Output: " + string.Join(",", outputArray.Select(i => i.ToString())));
            outputArray = GetWithoutDivision(new int[] { 0, 3, 0, 5 });
            Console.WriteLine("Output: " + string.Join(",", outputArray.Select(i => i.ToString())));
        }

        private static int[] GetWithoutDivision(int[] array)
        {
            var outputArray = new int[array.Length];

            var runningProduct = 1;
            for (int i = 0; i < array.Length; i++)
            {
                outputArray[i] = runningProduct;
                runningProduct *= array[i];
            }

            runningProduct = 1;
            for(int j = array.Length - 1; j > -1; j--)
            {
                outputArray[j] *= runningProduct;
                runningProduct *= array[j];
            }

            return outputArray;
        }
    }
}
