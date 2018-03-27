using System;
using System.Collections.Generic;

namespace CodingTests.Trees
{
    public class TopView
    {
        public void Test()
        {

        }

        private List<int> GetTopView(TreeNode root)
        {
            Dictionary<int, TreeNode> topView = new Dictionary<int, TreeNode>();
            int rank = 0;
            var queue = new Queue<Tuple<int, TreeNode>>();
            queue.Enqueue(new Tuple<int, TreeNode>(rank, root));
            while(queue.Count > 0)
            {
                var tuple = queue.Dequeue();
                rank = tuple.Item1;
                root = tuple.Item2;
                if (!topView.ContainsKey(rank))
                {
                    topView[rank] = root;
                }

                if (root.LeftChild != null)
                {
                    queue.Enqueue(new Tuple<int, TreeNode>(rank - 1, root.LeftChild));
                }

                if(root.RightChild != null)
                {
                    queue.Enqueue(new Tuple<int, TreeNode>(rank + 1, root.RightChild));
                }
            }

            var topViewValues = new List<int>();
            foreach(var node in topView.Values)
            {
                topViewValues.Add(node.Value);
            }

            return topViewValues;
        }
    }
}
