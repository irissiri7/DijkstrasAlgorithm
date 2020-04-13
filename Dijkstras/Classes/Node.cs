using System;
using System.Collections.Generic;

namespace Classes
{
    public class Node
    {
        public string Name { get; private set; }
        public int DistanceFromStart { get; set; }
        public List<NodeConnection> Connections { get; private set; }

        public Node(string name)
        {
            Name = name;
        }

        public void AddConnection(Node targetNode, int distance)
        {
            if (targetNode == null)
                throw new ArgumentException("Target node is null");
            if (targetNode == this)
                throw new ArgumentException("Can not add connection to itself");
            if (distance < 0)
                throw new ArgumentException("Distance must be a positive number");

            Connections.Add(new NodeConnection(targetNode, distance));
            targetNode.AddConnection(this, distance);

        }
    }
}
