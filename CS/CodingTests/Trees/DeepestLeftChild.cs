using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTests.Trees
{
    public static class DeepestLeftChild
    {
        public static TreeNode Driver(TreeNode root)
        {
            var tuple = Dfs(root, 0, 0, false);
            return tuple?.Item1;
        }

        private static Tuple<TreeNode, int> Dfs(TreeNode root, int currentDepth, int deepest, bool isLeftChild)
        {
            if (root.LeftChild == null && root.RightChild == null)
            {
                if (isLeftChild && currentDepth > deepest)
                {
                    return new Tuple<TreeNode, int>(root, currentDepth);
                }

                return null;
            }

            Tuple<TreeNode, int> lc = null, rc = null;
            if (root.LeftChild != null)
            {
                lc = Dfs(root.LeftChild, currentDepth + 1, deepest, true);
                deepest = lc != null && lc.Item2 > deepest ? lc.Item2 : deepest;
            }

            if (root.RightChild != null)
            {
                rc = Dfs(root.RightChild, currentDepth + 1, deepest, false);
            }

            if (rc != null)
            {
                return rc;
            }

            return lc;
        }

        public static void Test()
        {
            var tree = MaximumTree.CreateTree(new int[] { 3, 2, 1, 6, 0, 5 });
            var deepestLeft = Driver(tree);

            var tree2 = MaximumTree.CreateTree(new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 });
            var deepestLeft2 = Driver(tree2);

            var tree3 = MaximumTree.CreateTree(new int[] { 2, 10, 19, 1, 5, 15, 17, 8, 4, 11 });
            var deepestLeft3 = Driver(tree3);
        }
    }
}
