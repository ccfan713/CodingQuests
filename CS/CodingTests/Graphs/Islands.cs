namespace CodingTests.Graphs
{
    public class Islands
    {
        private static int[] neighborRowIndices = new int[] { -1, 0, 1, 0 };
        private static int[] neighborColIndices = new int[] { 0, -1, 0, 1 };
        public static void Test()
        {
            var matrix1 = new int[,] {{1, 1, 0, 0, 0},
                   {0, 1, 0, 0, 1},
                   {1, 0, 0, 1, 1},
                   {0, 0, 0, 0, 0},
                   {1, 0, 1, 0, 1} };
            var count = GetIslandCount(matrix1);

        }

        private static int GetIslandCount(int[,] matrix)
        {
            bool[,] visited = new bool[matrix.GetLength(0), matrix.GetLength(1)];
            var count = 0;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (CanVisit(matrix, visited, i, j))
                    {
                        count++;
                        Dfs(matrix, visited, i, j);
                    }
                }
            }

            return count;
        }

        private static void Dfs(int[,] matrix, bool[,] visited, int currentRow, int currentCol)
        {
            visited[currentRow, currentCol] = true;
            for(int i = 0; i < 4; i++)
            {
                int row = currentRow + neighborRowIndices[i];
                int col = currentCol + neighborColIndices[i];
                if (CanVisit(matrix, visited, row, col))
                {
                    Dfs(matrix, visited, row, col);
                }
            }
        }

        private static bool CanVisit(int[,] matrix, bool[,] visited, int row, int col)
        {
            return row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1) && !visited[row, col] && matrix[row, col] == 1;
        }
    }
}
