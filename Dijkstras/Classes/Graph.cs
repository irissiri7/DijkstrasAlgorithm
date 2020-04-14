using System;
using System.Collections.Generic;

namespace Classes
{
    public class Graph
    {
        public Dictionary<string, Node> Nodes { get; private set; }

        public Graph()
        {
            Nodes = new Dictionary<string, Node>();
        }

        public void AddNode(string name)
        {
            Node node = new Node(name);
            Nodes.Add(name, node);
        }

        public void AddConnection(string fromNode, string toNode, double distance)
        {
            if (Nodes.ContainsKey(fromNode) && Nodes.ContainsKey(toNode))
            {
                Nodes[fromNode].AddConnection(Nodes[toNode], distance);
            }
            else
            {
                throw new ArgumentException("One or both of the nodes do not exist");
            }
        }
    }
}
