using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTests.Trees
{
    public class BinaryTreeToDoublyLinkedList
    {
        public static void Test()
        {
            var tree1 = MaximumTree.CreateTree(new int[] { 3, 2, 1, 6, 0, 5 });
            var result = Convert(tree1);
        }

        public static TreeNode Convert(TreeNode root)
        {
            TreeNode first = null;
            TreeNode last = null;
            TreeNode unresolved = null;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            
            while(root != null || stack.Count > 0)
            {
                while(root != null)
                {
                    stack.Push(root);
                    root = root.LeftChild;
                }

                root = stack.Pop();
                last = root;
                if (first == null)
                {
                    first = root;
                }

                if (unresolved != null)
                {
                    unresolved.RightChild = root;
                    root.LeftChild = unresolved;
                    unresolved = null;
                }

                if (root.RightChild == null)
                {
                    if (stack.Count > 0)
                    {
                        root.RightChild = stack.Peek();
                        stack.Peek().LeftChild = root;
                    }

                    root = null;
                }
                else
                {
                    unresolved = root;
                    root = root.RightChild;
                }
            }

            first.LeftChild = last;
            last.RightChild = first;
            return first;
        }
    }
}
