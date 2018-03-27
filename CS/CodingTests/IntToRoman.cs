namespace CodingTests
{
    using System.Collections.Generic;

    public static class IntToRoman
    {
        static int[] numbers = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
        static Dictionary<int, string> romanMap = new Dictionary<int, string>()
        {
            { 1000, "M" },
            { 900, "CM" },
            { 500, "D" },
            { 400, "CD" },
            { 100, "C" },
            { 90, "XC" },
            { 50, "L" },
            { 40, "XL" },
            { 10, "X" },
            { 9, "IX" },
            { 8, "VIII" },
            { 7, "VII" },
            { 6, "VI" },
            { 5, "V" },
            { 4, "IV" },
            { 3, "III" },
            { 2, "II" },
            { 1, "I" }
        };

        public static string ConvertIntToRoman(int number)
        {
            string roman = string.Empty;
            while (number > 0)
            {
                roman = roman + GetNumeral(ref number);
            }

            return roman;
        }

        private static string GetNumeral(ref int number)
        {
            int i = 0;
            while (i < romanMap.Count && numbers[i] > number)
            {
                i++;
            }

            number = number - numbers[i];
            return romanMap[numbers[i]];
        }

    }
}