using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTests.Trees
{
    public class RootToLeafSum
    {
        public static void Test()
        {
            var tree = MaximumTree.CreateTree(new int[] { 3, 2, 1, 6, 0, 5 });
            int sum = SumNumbers(tree);
        }

        private static int SumNumbers(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            int sum = 0;
            var numbers = new List<Tuple<int, int>>();
            stack.Push(root);
            stack.Push(root);
            while(stack.Count > 0)
            {
                var node = stack.Pop();
                if (stack.Count > 0 && stack.Peek() == node)
                {
                    if (node.RightChild != null)
                    {
                        stack.Push(node.RightChild);
                        stack.Push(node.RightChild);
                    }

                    if (node.LeftChild != null)
                    {
                        stack.Push(node.LeftChild);
                        stack.Push(node.LeftChild);
                    }
                }
                else
                {
                    if (node.RightChild == null && node.LeftChild == null)
                    {
                        var tuple = new Tuple<int, int>(node.Value, 1);
                        numbers.Add(tuple);
                    }
                    else
                    {
                        int numbersToUpdate = 0;
                        if (node.RightChild != null)
                        {
                            numbersToUpdate++;
                        }

                        if(node.LeftChild != null)
                        {
                            numbersToUpdate++;
                        }

                        int i = 0;
                        while(i < numbersToUpdate)
                        {
                            var index = numbers.Count - 1 - i;
                            var oldTuple = numbers[index];
                            var multiplier = oldTuple.Item2 * 10;
                            var number = oldTuple.Item1 + node.Value * multiplier;
                            var newtTuple = new Tuple<int, int>(number, multiplier);
                            numbers[index] = newtTuple;
                            i++;
                        }
                    }
                }
            }

            for(int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i].Item1;
            }
            return sum;
        }
    }
}
