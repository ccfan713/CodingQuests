using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTests
{
    public class FindMissingSequences
    {
        private const int RangeMin = 0;
        private const int RangeMax = 99;
        private const string RangeFormat = "{0}-{1}";
        public static string Find(int[] input)
        {
            if(input.Length == 0)
            {
                return string.Format(RangeFormat, RangeMin, RangeMax);
            }
            
            if(input.Length == RangeMax - RangeMin + 1)
            {
                return string.Empty;
            }

            List<KeyValuePair<int, int>> ranges = new List<KeyValuePair<int, int>>();
            if (input[0] > RangeMin)
            {
                ranges.Add(new KeyValuePair<int, int>(RangeMin, input[0] - 1));
            }

            int i = 0;
            while(i < input.Length - 1)
            {
                ranges.Add(new KeyValuePair<int, int>(input[i] + 1, input[i + 1] - 1));
                i++;
            }

            if (input[input.Length - 1] < RangeMax)
            {
                ranges.Add(new KeyValuePair<int, int>(input[input.Length - 1] + 1, RangeMax));
            }

            StringBuilder rangeString = new StringBuilder();
            int count = 0;
            foreach(var kvp in ranges)
            {
                if (kvp.Key == kvp.Value)
                {
                    if (count > 0)
                    {
                        rangeString.Append(",");
                    }

                    rangeString.Append(string.Format("{0}", kvp.Key));
                    count++;
                }
                else if (kvp.Key < kvp.Value)
                {
                    if (count > 0)
                    {
                        rangeString.Append(",");
                    }

                    rangeString.Append(string.Format(RangeFormat, kvp.Key, kvp.Value));
                    count++;
                }
            }

            return rangeString.ToString();
        }
    }
}
