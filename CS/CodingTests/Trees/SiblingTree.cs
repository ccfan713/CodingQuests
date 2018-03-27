using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTests.Trees
{
    public class SiblingTree
    {
        public static void Test()
        {

        }

        private static void Connect(TreeLinkNode root)
        {
            Queue<TreeLinkNode> queue = new Queue<TreeLinkNode>();
            int nextLevelNodeCount = 0;
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                
                if (queue.Count > 0)
                {
                    if (queue.Count - nextLevelNodeCount > 0)
                    {
                        node.next = queue.Peek();
                    }
                }
                
                if (node.left != null)
                {
                    nextLevelNodeCount++;
                    queue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    nextLevelNodeCount++;
                    queue.Enqueue(node.right);
                }
            }
        }
    }
}
