using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTests.Graphs
{
    public class Bipartite
    {
        private bool IsBipartite(List<Node> graph)
        {
            var nodeSet1 = new HashSet<Node>();
            var nodeSet2 = new HashSet<Node>();

            var isBipartite = true;
            var nodesToBeVisited = new Queue<KeyValuePair<Node, HashSet<Node>>>();
            nodeSet1.Add(graph[0]);
            nodesToBeVisited.Enqueue(new KeyValuePair<Node, HashSet<Node>>(graph[0], nodeSet1));
            while (isBipartite && nodesToBeVisited.Count > 0 && nodeSet1.Count + nodeSet2.Count < graph.Count)
            {
                // handle the emtpy queue case in case of disjoint graphs
                var nodekvp = nodesToBeVisited.Dequeue();
                var currentNodeSet = nodekvp.Value;
                HashSet<Node> otherNodeSet = null;
                if(currentNodeSet == nodeSet1)
                {
                    otherNodeSet = nodeSet2;
                }
                else
                {
                    otherNodeSet = nodeSet1;
                }

                foreach (var neighbor in nodekvp.Key.Neighbors)
                {
                    // null check first
                    // is this edge breaking bipartiteness?
                    isBipartite = !currentNodeSet.Contains(neighbor);
                    if (!isBipartite)
                    {
                        break;
                    }

                    otherNodeSet.Add(neighbor);
                    nodesToBeVisited.Enqueue(new KeyValuePair<Node, HashSet<Node>>(neighbor, otherNodeSet));
                }
            }

            return isBipartite;
        }
    }
}
