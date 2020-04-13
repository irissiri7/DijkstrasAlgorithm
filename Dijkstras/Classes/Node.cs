using System;
using System.Collections.Generic;

namespace Classes
{
    public class Node
    {
        public string Name { get; private set; }
        public int DistanceFromStart { get; private set; }
        public List<NodeConnection> Connections { get; private set; }

        public Node(string name)
        {
            Name = name;
        }

        public void AddConnection(Node node, int distance)
        {

        }
    }
}
