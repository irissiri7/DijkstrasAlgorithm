using System;
using System.Collections.Generic;

namespace Classes
{
    public class Node
    {
        public string Name { get; private set; }
        public double DistanceFromStart { get; set; }
        public List<string> Path { get; set; }
        public List<NodeConnection> Connections { get; private set; }

        public Node(string name)
        {
            Name = name;
            Connections = new List<NodeConnection>();
            Path = new List<string>();
            Path.Add(name);
        }

        public void AddConnection(Node targetNode, double distance)
        {
            if (targetNode == null)
                throw new ArgumentException("Target node is null");
            if (targetNode == this)
                throw new ArgumentException("Can not add connection to itself");
            if (distance < 0)
                throw new ArgumentException("Distance must be a positive number");

            Connections.Add(new NodeConnection(targetNode, distance));
            targetNode.Connections.Add(new NodeConnection(this, distance));

        }
    }
}
