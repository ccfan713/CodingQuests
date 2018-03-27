using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTests
{
    public class TicTacToeWinner
    {
        public static int CheckWinner(int[,] gameBoard)
        {
            if (gameBoard.Length != 9 || gameBoard.Rank != 2)
            {
                return -1;
            }

            int sum = 0, winner = -1;

            // check rows and columns for winner
            for (int i = 0; i < 3; i++)
            {
                sum = 0;
                for (int j = 0; j < 3; j++)
                {
                    sum += gameBoard[i, j];
                }

                winner = IsResultWinner(sum);
                if (winner > -1)
                {
                    return winner;
                }
            }

            for(int a = 0; a < 3; a++)
            {
                sum = 0;
                for (int b = 0;b < 3; b++)
                {
                    sum += gameBoard[b, a];
                }

                winner = IsResultWinner(sum);
                if (winner > -1)
                {
                    return winner;
                }
            }

            // check diagonals
            sum = 0;
            for (int p = 0; p < 3; p++)
            {
                sum += gameBoard[p, p];
            }

            winner = IsResultWinner(sum);
            if (winner > -1)
            {
                return winner;
            }

            sum = 0;
            for (int q = 0; q < 3; q++)
            {
                sum += gameBoard[q, 2 - q];
            }

            winner = IsResultWinner(sum);
            if (winner > -1)
            {
                return winner;
            }

            return -1;
        }

        private static int IsResultWinner(int total)
        {
            if (total == 0)
            {
                return 0;
            }

            if (total == 3)
            {
                return 1;
            }

            return -1;
        }
    }
}
