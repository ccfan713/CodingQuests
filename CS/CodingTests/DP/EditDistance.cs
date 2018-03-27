
namespace CodingTests.DP
{
    public class EditDistance
    {
        public static void Test()
        {
            var edit = GetEditDistance("ago", "agog");
            edit = GetEditDistance("hour", "our");
            edit = GetEditDistance("mickey", "mouse");
        }

        private static int GetEditDistance(string x, string y)
        {
            int[,] editMap = new int[x.Length + 1, y.Length + 1];
            for(int i = 0; i < x.Length + 1; i++)
            {
                editMap[i, 0] = i;
            }

            for (int i = 0; i < y.Length + 1; i++)
            {
                editMap[0, i] = i;
            }

            for (int i = 1; i < x.Length + 1; i++)
            {
                for (int j = 1; j < y.Length + 1; j++)
                {
                    if (x[i-1] == y[j-1])
                    {
                        editMap[i, j] = editMap[i - 1, j - 1];
                    }
                    else
                    {
                        var cInsert = editMap[i, j - 1] + 1;
                        var cDelete = editMap[i - 1, j] + 1;
                        var cReplace = editMap[i - 1, j - 1] + 1;
                        editMap[i,j] = Min(cInsert, cDelete, cReplace);
                    }
                }
            }

            return editMap[x.Length, y.Length];
        }

        private static int Min(int i, int j, int k)
        {
            var min = i;
            if (j < min)
            {
                min = j;
            }

            if (k < min)
            {
                min = k;
            }

            return min;
        }
    }
}
