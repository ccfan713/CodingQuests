using System;
using SystemDependency;
namespace CodingTests
{
    class Program
    {
        static void Main(string[] args)
        {
            // TestTicTacToeWinner();
            // TestFindMissingSequences();
            // TestLetterMap();
            // Trees.MaximumTree.Test();
            // Trees.DeepestLeftChild.Test();
            // Trees.LargestInEachRow.Test();
            // Trees.SubtreeSum.Test();
            // Strings.Anagrams.Test();
            // Strings.ArraysOfStrings.Test();
            // BitOperations.Palindrome.Test();
            // BitOperations.PowerSets.Test();
            // Arrays.ShiftedArray.Test();
            // Arrays.ShiftedArrayNoRecursion.Test();
            // Strings.BasicRegexParser.Test();
            // Arrays.SumOfThree.Test();
            // Graphs.Islands.Test();
            // Trees.BinaryTreeToDoublyLinkedList.Test();
            // DP.SubsetSum.Test();
            // Trees.LeastCommonAncestor.Test();
            // OverlappingMeetings.Test();
            var processor = new CommandProcessor();
            processor.ProcessCommands(".\\Input\\testInput.txt", ".\\testOutput.txt");
            Console.ReadLine();
        }

        static void TestFindMissingSequences()
        {
            var ranges = FindMissingSequences.Find(new int[] { 3, 10, 34, 35, 80, 91, 93 });
            Console.WriteLine("Missing sequence for 3, 10, 34, 35, 80, 91, 93: " + ranges);

            ranges = FindMissingSequences.Find(new int[] { 0, 99 });
            Console.WriteLine("Missing sequence for 0, 99: " + ranges);

            ranges = FindMissingSequences.Find(new int[] { 99 });
            Console.WriteLine("Missing sequence for 99: " + ranges);

            ranges = FindMissingSequences.Find(new int[] { 0 });
            Console.WriteLine("Missing sequence for 0: " + ranges);

            ranges = FindMissingSequences.Find(new int[] { 41 });
            Console.WriteLine("Missing sequence for 41: " + ranges);

        }

        static void TestTicTacToeWinner()
        {
            int[,] gameBoard = new int[,] { { 0, 0, 0},
                                            { 0, 1, 1 },
                                            { 1, 0, 1 }};
            var winner = TicTacToeWinner.CheckWinner(gameBoard);
            Console.WriteLine("For top row winner 0 grid, method returned: " + winner);

            gameBoard = new int[,]
            {
                {0, 1, 0},
                {0, 1, 1},
                {1, 1, 0}
            };

            winner = TicTacToeWinner.CheckWinner(gameBoard);
            Console.WriteLine("For central column winner 1 grid, method returned: " + winner);

            gameBoard = new int[,]
            {
                {0, 1, 1},
                {1, 0, 0},
                {0, 0, 1}
            };

            winner = TicTacToeWinner.CheckWinner(gameBoard);
            Console.WriteLine("For no winner grid, method returned: " + winner);

            gameBoard = new int[,]
            {
                {1, 0, 0},
                {0, 1, 1},
                {0, 0, 1}
            };

            winner = TicTacToeWinner.CheckWinner(gameBoard);
            Console.WriteLine("For top left diagonal column winner 1 grid, method returned: " + winner);

            gameBoard = new int[,]
            {
                {1, 0, 0},
                {1, 0, 1},
                {0, 0, 1}
            };

            winner = TicTacToeWinner.CheckWinner(gameBoard);
            Console.WriteLine("For top right diagonal column winner 0 grid, method returned: " + winner);
        }

        static void TestLetterMap()
        {
            int[] twoDigit = new int[] { 2, 3 };
            var combinations = LetterMap.GetAllCombinations(twoDigit);
            Console.WriteLine($"Combinations for [{twoDigit[0]}, {twoDigit[1]}]");
            foreach (var combination in combinations)
            {
                Console.WriteLine(combination.ToString());
            }

            Console.ReadKey();

            int[] threeDigit = new int[] { 7, 5, 6 };
            combinations = LetterMap.GetAllCombinations(threeDigit);
            Console.WriteLine($"Combinations for [{threeDigit[0]}, {threeDigit[1]}, {threeDigit[2]}]");
            foreach (var combination in combinations)
            {
                Console.WriteLine(combination.ToString());
            }
        }
    }
}
