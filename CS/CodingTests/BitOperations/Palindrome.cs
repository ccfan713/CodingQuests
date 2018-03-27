using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTests.BitOperations
{
    public static class Palindrome
    {
        public static void Test()
        {
            Console.WriteLine("Palindrome 3: " + IsPalidrome(3));
            Console.WriteLine("Palindrome 100: " + IsPalidrome(100));
            Console.WriteLine("Palindrome 33: " + IsPalidrome(33));
            Console.WriteLine($"Palindrome {int.MaxValue}: " + IsPalidrome(int.MaxValue));
            Console.WriteLine($"Palindrome {int.MinValue}: " + IsPalidrome(int.MinValue));
        }

        private static bool IsPalidrome(int n)
        {
            // find left-most set bit
            int left = 31;
            while((n & (1 << left)) == 0)
            {
                left--;
            }

            bool palindrome = true;
            int i = left;
            while (palindrome && i > 0)
            {
                int l = n & (1 << i);
                var rightside = left == i ? 1 : 1 << (left - i);
                int r = n & rightside;
                palindrome = (l == 0 && r == 0) || (l > 0 && r > 0);
                i--;
            }

            return palindrome;
        }
    }
}
