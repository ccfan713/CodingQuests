using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTests.Graphs
{
    public class Clone
    {
        public Node CloneGraph(Node root)
        {
            if (root == null)
            {
                return null;
            }

            // map of nodes to their clones
            var nodeMap = new Dictionary<Node, Node>();
            var queue = new Queue<Node>();
            queue.Enqueue(root);

            while(queue.Count > 0)
            {
                var node = queue.Dequeue();
                var newNode = GetClonedNode(nodeMap, node);

                // add children
                foreach(var child in node.Children)
                {
                    // add child to queue for BFS
                    queue.Enqueue(child);

                    // create clone if needed and add to children of cloned parent
                    var newChild = GetClonedNode(nodeMap, child);
                    newNode.Children.Add(newChild);
                }
            }

            return nodeMap[root];
        }

        private Node GetClonedNode(Dictionary<Node, Node> nodeMap, Node originalNode)
        {
            if (!nodeMap.ContainsKey(originalNode))
            {
                var newNode = new Node();
                newNode.Data = originalNode.Data;
                nodeMap[originalNode] = newNode;
            }

            return nodeMap[originalNode];
        }
    }

    public class Node
    {
        private List<Node> children;
        public int Data { get; set; }

        public List<Node> Children { get; }
        public Node()
        {
            children = new List<Node>();
        }
    }
}
