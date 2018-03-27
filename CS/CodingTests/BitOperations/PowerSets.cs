using System;
using System.Collections.Generic;
using System.Text;

namespace CodingTests.BitOperations
{
    public class PowerSets
    {
        public static void Test()
        {
            var testInput = new int[3] { 3, -10, 20 };
            GetSets(testInput);
            GetSets(new int[] { 3, 12, 2, -5 });
        }

        private static void GetSets(int[] input)
        {
            var total = 1 << input.Length;
            var setLists = new List<List<int>>();
            for (int i = 0; i < total; i++)
            {
                setLists.Add(new List<int>());
                for(int n = 0; n < input.Length; n++)
                {
                    // if the nth bit is set then add input[n] to current set
                    if ((i & (1<<n)) > 0)
                    {
                        setLists[i].Add(input[n]);
                    }
                }
            }

            foreach(var set in setLists)
            {
                var sb = StartSet();
                int count = set.Count;
                while (count > 1)
                {
                    AppendNumber(sb, set[count - 1], true);
                    count--;
                }

                if (count == 1)
                {
                    AppendNumber(sb, set[0], false);
                }

                sb.Append("}");
                Console.WriteLine(sb.ToString());
            }
        }

        private static StringBuilder StartSet()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");

            return sb;
        }

        private static void AppendNumber(StringBuilder sb, int number, bool appendComma)
        {
            sb.Append(number);

            if (appendComma)
            {
                sb.Append(",  ");
            }
        }

    }
}
