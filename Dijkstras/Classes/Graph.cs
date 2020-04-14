using System;
using System.Collections.Generic;

namespace Classes
{
    //This class is the structure responsible for holding all the Nodes and 
    // making new connections
    public class Graph
    {
        //Keeping all Nodes in a Dictionary
        public Dictionary<string, Node> Nodes { get; private set; }

        public Graph()
        {
            Nodes = new Dictionary<string, Node>();
        }

        // Add node to Dictionary
        public void AddNode(string name)
        {
            Node node = new Node(name);
            Nodes.Add(name, node);
        }

        // Establish new relationships
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
