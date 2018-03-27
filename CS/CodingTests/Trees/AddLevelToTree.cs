using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTests.Trees
{
    public class AddLevelToTree
    {
        public void AddLevel(TreeNode root, int depth, int value)
        {
            // find nodes at depth -1
            var nodeList = new List<TreeNode>();
            FindNodesAtDepth(root, depth - 1, 1, nodeList);

            // insert  nodes under them
            if (nodeList != null && nodeList.Count > 0)
            {
                foreach (var node in nodeList)
                {
                    var left = node.LeftChild;
                    var right = node.RightChild;

                    var newNode1 = new TreeNode
                    {
                        LeftChild = left,
                        Value = value
                    };

                    node.LeftChild = newNode1;

                    var newNode2 = new TreeNode
                    {
                        RightChild = right,
                        Value = value
                    };

                    node.RightChild = newNode2;
                }
            }
        }

        private void FindNodesAtDepth(TreeNode root, int depth, int currentDepth, List<TreeNode> nodeList)
        {
            if (root == null)
            {
                return;
            }

            if (currentDepth > depth)
            {
                return;
            }

            if (currentDepth == depth)
            {
                nodeList.Add(root);
                return;
            }

            FindNodesAtDepth(root.LeftChild, depth, currentDepth + 1, nodeList);
            FindNodesAtDepth(root.RightChild, depth, currentDepth + 1, nodeList);
        }
    }
}
