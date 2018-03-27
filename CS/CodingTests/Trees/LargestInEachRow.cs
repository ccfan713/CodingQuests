namespace CodingTests.Trees
{
    using System.Collections.Generic;
    public class LargestInEachRow
    {
        public static List<int> Find(TreeNode tree)
        {
            Queue<TreeNode> q1 = new Queue<TreeNode>(), q2 = new Queue<TreeNode>();
            var maxPerRow = new List<int>();
            q1.Enqueue(tree);
            while (q1.Count > 0 || q2.Count > 0)
            {
                if (q1.Count > 0)
                {
                    maxPerRow.Add(FindMaxWithLevelTraversal(q1, q2));
                }
                else
                {
                    maxPerRow.Add(FindMaxWithLevelTraversal(q2, q1));
                }
            }

            return maxPerRow;
        }

        private static int FindMaxWithLevelTraversal(Queue<TreeNode> currentRow, Queue<TreeNode> nextRow)
        {
            var maxInt = int.MinValue;
            while (currentRow.Count > 0)
            {
                var node = currentRow.Dequeue();
                if (node.Value > maxInt)
                {
                    maxInt = node.Value;
                }

                if (node.LeftChild != null)
                {
                    nextRow.Enqueue(node.LeftChild);
                }

                if (node.RightChild != null)
                {
                    nextRow.Enqueue(node.RightChild);
                }
            }

            return maxInt;
        }

        public static void Test()
        {
            var tree = MaximumTree.CreateTree(new int[] { 3, 2, 1, 6, 0, 5 });
            var max1 = Find(tree);

            var tree2 = MaximumTree.CreateTree(new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 });
            var max2 = Find(tree2);

            var tree3 = MaximumTree.CreateTree(new int[] { 2, 10, 19, 1, 5, 15, 17, 8, 4, 11 });
            var max3 = Find(tree3);
        }
    }
}
