using System;
using System.Collections.Generic;

namespace CodingTests.Trees
{
    public class LeastCommonAncestor
    {
        public static void Test()
        {
            var tree = MaximumTree.CreateTree(new int[] { 3, 2, 1, 6, 0, 5 });
            var value = GetLeastCommonAncestorWithPaths(tree, 3, 0);
            Console.WriteLine("LCA 3 /0: " + value);
            value = GetLeastCommonAncestorWithPaths(tree, 5, 0);
            Console.WriteLine("LCA 6 /0: " + value);
            value = GetLeastCommonAncestorWithPaths(tree, 1, 0);
            Console.WriteLine("LCA 1 /0: " + value);
            value = GetLeastCommonAncestorWithPaths(tree, 8, 0);
            Console.WriteLine("LCA 8 /0: " + value);

            var tree2 = MaximumTree.CreateTree(new int[] { 2, 10, 19, 1, 5, 15, 17, 8, 4, 11 });
            value = GetLeastCommonAncestorWithPaths(tree2, 2, 4);
            Console.WriteLine("LCA 2 /4: " + value);

            value = GetLeastCommonAncestorWithPaths(tree2, 2, 19);
            Console.WriteLine("LCA 2 /19: " + value);

            value = GetLeastCommonAncestorWithPaths(tree2, 1, 8);
            Console.WriteLine("LCA 1 /8: " + value);
        }

        private static TreeNode GetLeastCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
            {
                return null;
            }

            if (root == p || root == q)
            {
                return root;
            }

            TreeNode left = GetLeastCommonAncestor(root.LeftChild, p, q);
            TreeNode right = GetLeastCommonAncestor(root.RightChild, p, q);

            return left != null && right != null ? root : left ?? right;
        }

        private static int GetLeastCommonAncestorWithPaths(TreeNode root, int value1, int value2)
        {
            var success = false;
            var list1 = new List<TreeNode>() { root };
            var list2 = new List<TreeNode>() { root };
            success = GetAncestorsDFS(root, value1, list1);
            if (success)
            {
                success &= GetAncestorsDFS(root, value2, list2);
            }

            int lca = -1;
            if (success)
            {
                int index1 = 0, index2 = 0;
                while(index1 < list1.Count && index2 < list2.Count && list1[index1].Value == list2[index2].Value)
                {
                    index1++;
                    index2++;
                }

                lca = list1[index1 - 1].Value;
            }

            return lca;
        }

        private static bool GetAncestorsDFS(TreeNode root, int nodeValue, List<TreeNode> ancestors)
        {
            if (root == null)
            {
                return false;
            }

            if (root.Value == nodeValue)
            {
                return true;
            }

            var success = false;
            if (root.LeftChild != null)
            {
                ancestors.Add(root.LeftChild);
                success = GetAncestorsDFS(root.LeftChild, nodeValue, ancestors);
                if (!success)
                {
                    ancestors.Remove(root.LeftChild);
                }
            }

            if (root.RightChild != null && !success)
            {
                ancestors.Add(root.RightChild);
                success = GetAncestorsDFS(root.RightChild, nodeValue, ancestors);
                if (!success)
                {
                    ancestors.Remove(root.RightChild);
                }
            }

            return success;
        }
    }
}
