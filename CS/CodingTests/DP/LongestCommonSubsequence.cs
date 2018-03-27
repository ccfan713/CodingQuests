using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTests.DP
{
    public class LongestCommonSubsequence
    {
        public static void Test()
        {
            var lcs = GetLCS("thou shalt not", "you shall not");
        }

        private static int GetLCS(string a, string b)
        {
            int[,] editMap = new int[a.Length + 1, b.Length + 1];
            for(int i = 0; i <= a.Length; i++)
            {
                editMap[i, 0] = 0;
            }

            for (int i = 0; i <= b.Length; i++)
            {
                editMap[0, i] = 0;
            }

            for(int i = 1; i <= a.Length; i++)
            {
                for(int j = 1; j <= b.Length; j++)
                {
                    var maxLcs = Match(a[i - 1], b[j - 1]) + editMap[i - 1, j - 1];
                    var insertCost = Insert(b[j-1]) + editMap[i, j - 1];
                    maxLcs = insertCost < maxLcs ? maxLcs : insertCost;
                    var deleteCost = Delete(a[i-1]) + editMap[i - 1, j];
                    maxLcs = deleteCost < maxLcs ? maxLcs : deleteCost;

                    editMap[i, j] = maxLcs;
                }
            }

            return editMap[a.Length, b.Length];
        }

        private static int Match(char a, char b)
        {
            if (a == b)
            {
                return 1;
            }

            return 0;
        }

        private static int Insert(char a)
        {
            return 0;
        }

        private static int Delete(char a)
        {
            return 0;
        }
    }
}
