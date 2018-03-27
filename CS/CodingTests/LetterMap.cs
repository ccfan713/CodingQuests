using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTests
{
    public class LetterMap
    {
        private static List<string> DigitMap = new List<string>
        {
            " ",
            "~",
            "ABC",
            "DEF",
            "GHI",
            "JKL",
            "MNO",
            "PQRS",
            "TUV",
            "WXYZ"
        };

        public static List<StringBuilder> GetAllCombinations(int[] phoneNumber)
        {
            int total = 1;
            for(int a = 0; a < phoneNumber.Length; a++)
            {
                if (phoneNumber[a] < 0 || phoneNumber[a] > 9)
                {
                    return null;
                }

                total *= DigitMap[phoneNumber[a]].Length;
            }

            int grandTotal = total;
            Console.WriteLine($"Combinations to be output: {total}");
            List<StringBuilder> Combinations = new List<StringBuilder>(total);
            for (int i = 0; i < phoneNumber.Length; i++)
            {
                string letters = DigitMap[phoneNumber[i]];
                int reps = total / letters.Length;
                int letterIndex = 0;
                int repCount = 1;
                for (int j = 0; j < grandTotal; j++)
                {
                    if (Combinations.Count < j + 1)
                    {
                        Combinations.Add(new StringBuilder());
                    }

                    Combinations[j].Append(letters[letterIndex]);

                    int repLength = (repCount * reps) - 1;
                    if (j == repLength)
                    {
                        repCount++;
                        letterIndex = letterIndex == letters.Length - 1 ? 0 : letterIndex + 1;
                    }
                }
                
                total = reps;
            }

            return Combinations;
        }
    }
}
