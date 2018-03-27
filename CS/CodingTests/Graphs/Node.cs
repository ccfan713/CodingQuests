using System.Collections.Generic;

namespace CodingTests.Graphs
{
    public class Node
    {
        public int Value { get; set; }
        public HashSet<Node> Neighbors { get; }

        public Node()
        {
            Neighbors = new HashSet<Node>();
        }
    }
}
