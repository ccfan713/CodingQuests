using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTests.Trees
{
    public class SubtreeSum
    {
        public static List<int> GetSubtreeSums(TreeNode root)
        {
            var sumFrequency = new Dictionary<int, int>();
            var highestFrequency = 0;
            GetSubtreeSums(root, sumFrequency, ref highestFrequency);
            var orderedList = new List<int>();
            
            // find all the sums with the highest frequency
            foreach(var keyValuePair in sumFrequency)
            {
                if (keyValuePair.Value == highestFrequency)
                {
                    orderedList.Add(keyValuePair.Key);
                }
            }

            return orderedList;
        }

        private static int GetSubtreeSums(TreeNode root, Dictionary<int, int> sumFrequency, ref int highestFrequency)
        {
            if (root.LeftChild == null && root.RightChild == null)
            {
                AddSumToFrequencyDictionary(sumFrequency, root.Value, ref highestFrequency);
                return root.Value;
            }

            int leftSum = 0, rightSum = 0;

            if (root.LeftChild != null)
            {
                leftSum = GetSubtreeSums(root.LeftChild, sumFrequency, ref highestFrequency);
            }

            if (root.RightChild != null)
            {
                rightSum = GetSubtreeSums(root.RightChild, sumFrequency, ref highestFrequency);
            }

            var sum = leftSum + rightSum + root.Value;
            AddSumToFrequencyDictionary(sumFrequency, sum, ref highestFrequency);
            return sum;
        }

        private static void AddSumToFrequencyDictionary(Dictionary<int, int> sumFrequency, int sum, ref int highestFrequency)
        {
            if (sumFrequency.ContainsKey(sum))
            {
                sumFrequency[sum] += 1;
            }
            else
            {
                sumFrequency[sum] = 1;
            }

            highestFrequency = highestFrequency < sumFrequency[sum] ? sumFrequency[sum] : highestFrequency;
        }

        public static void Test()
        {
            var tree = MaximumTree.CreateTree(new int[] { 3, 2, 1, 6, 0, 5 });
            var freq1 = GetSubtreeSums(tree);

            var node1 = new TreeNode { Value = 2 };
            var node2 = new TreeNode { Value = -3 };
            var tree2 = new TreeNode { Value = 5, LeftChild = node1, RightChild = node2 };
            var freq2 = GetSubtreeSums(tree2);

            var node3 = new TreeNode { Value = 2 };
            var node4 = new TreeNode { Value = -5 };
            var tree3 = new TreeNode { Value = 5, LeftChild = node3, RightChild = node4 };
            var freq3 = GetSubtreeSums(tree3);
        }
    }
}
