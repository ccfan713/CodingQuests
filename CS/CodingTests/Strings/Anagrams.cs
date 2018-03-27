using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace CodingTests.Strings
{
    public static class Anagrams
    {
        public static void Test()
        {
            var words = new string[8] { "worse", "swore", "wasp", "paws", "rasp", "spar", "pars", "rivet" };
            var runningTime = GetAnagrams(words);
            Console.WriteLine("Running time: " + runningTime.TotalMilliseconds);

            var strings = File.ReadAllLines("../../Input/wordListWithoutApostrophes.txt");
            runningTime = GetAnagrams(strings);
            Console.WriteLine("Running time: " + runningTime.TotalMilliseconds);
        }

        public static TimeSpan GetAnagrams(string[] wordList)
        {
            var start = DateTime.Now;
            if (wordList == null || wordList.Length == 0)
            {
                return TimeSpan.MinValue;
            }

            var anagramMap = new Dictionary<string, List<string>>();
            foreach(var word in wordList)
            {
                var sorted = Alphabetize(word);
                if (!anagramMap.ContainsKey(sorted))
                {
                    anagramMap[sorted] = new List<string>();
                }

                anagramMap[sorted].Add(word);
            }

            var end = DateTime.Now;
            
            foreach(var kvp in anagramMap)
            {
                kvp.Value.ForEach(s => Console.Write(s + "    "));
                Console.WriteLine();
            }

            Console.WriteLine("Total words: " + wordList.Length);
            Console.WriteLine("Anagrams total: " + anagramMap.Count());

            return end.Subtract(start);
        }

        private static string Alphabetize(string word)
        {
            var sorted = string.Concat(word.ToLowerInvariant().OrderBy(c => c, new CharComparer()));
            return sorted;
        }

        private class CharComparer : IComparer<char>
        {
            public int Compare(char x, char y)
            {
                if (x < y)
                {
                    return -1;
                }

                if (x == y)
                {
                    return 0;
                }

                return 1;
            }
        }
    }
}
