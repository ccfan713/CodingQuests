using System;

namespace CodingTests.Strings
{
    public static class ArraysOfStrings
    {
        public static void Test()
        {
            var testInput = new string[5] { "abcd", "הָיְתָהtestالصفحات التّحول", "ǝɹoqɐl ʇn ʇunpᴉpᴉɔuᴉ ɹodɯǝʇ", "𝐓𝐡𝐞 𝐪𝐮𝐢𝐜𝐤 𝐛𝐫𝐨𝐰𝐧", "田中さんにあげて下さい" };
            var output = ToString(testInput, '|');
            Console.WriteLine("ToString with separator: " + output);
            var array = ToArray(output, '|');
            Match(array, testInput);

            int[] indices = new int[1];
            output = ToString(testInput, out indices);
            Console.WriteLine("ToString with indices: " + output);
            array = ToArray(output, indices);
            Match(array, testInput);
        }

        public static string ToString(string[] strings, char separator)
        {
            if (strings == null || strings.Length == 0)
            {
                return string.Empty;
            }

            string concatString = strings[0];
            var i = 1;
            while( i < strings.Length)
            {
                concatString = string.Concat(concatString, separator, strings[i++]);
            }

            return concatString;
        }

        public static string ToString(string[] strings, out int[] indices)
        {
            if (strings == null || strings.Length == 0)
            {
                indices = null;
                return string.Empty;
            }

            indices = new int[strings.Length];
            string concatString = strings[0];
            indices[0] = 0;
            var i = 1;
            while(i < strings.Length)
            {
                indices[i] = concatString.Length;
                concatString = string.Concat(concatString, strings[i++]);
            }

            return concatString;
        }

        public static string[] ToArray(string concatString, char separator)
        {
            int arraySize = GetNumberOfStrings(concatString, separator);
            var array = new string[arraySize];
            int index = 0, arrayIndex = 0;
            while(index < concatString.Length)
            {
                var separatorIndex = concatString.IndexOf(separator, index);
                if (separatorIndex >= 0)
                {
                    array[arrayIndex++] = concatString.Substring(index, separatorIndex - index);
                    index = separatorIndex + 1;
                }
                else
                {
                    array[arrayIndex] = concatString.Substring(index, concatString.Length - index);
                    index = concatString.Length;
                }               
            }

            return array;
        }

        public static string[] ToArray(string concatString, int[] startIndices)
        {
            var array = new string[startIndices.Length];
            int index = 0;
            while (index < startIndices.Length)
            {
                var currentStart = startIndices[index];
                var nextStart = index + 1 == startIndices.Length ? concatString.Length : startIndices[index + 1];
                array[index++] = concatString.Substring(currentStart, nextStart - currentStart);
            }

            return array;
        }

        private static void Match(string[] array1, string[] array2)
        {
            bool valid = array1.Length == array2.Length;
            int i = 0;
            while (valid && i < array1.Length)
            {
                valid = array1[i].Equals(array2[i++]);
            }

            if (valid)
            {
                Console.WriteLine("Converted array matches input.");
            }
            else
            {
                Console.WriteLine("Converted array mismatch.");
            }
        }

        private static int GetNumberOfStrings(string bigString, char separator)
        {
            int index = 0;
            int stringCount = 1;
            while (index < bigString.Length)
            {
                var separatorIndex = bigString.IndexOf(separator, index);
                if (separatorIndex > 0)
                {
                    stringCount++;
                    index = separatorIndex + 1;
                }
                else
                {
                    index = bigString.Length;
                }
            }

            return stringCount;
        }
    }
}
