using System;
using System.Collections.Generic;

namespace Classes
{
    public class Node
    {
        //Name, this is kept as key-string in the graphs Dictionary
        public string Name { get; private set; }
        // DFS for short
        public double DistanceFromStart { get; set; }
        // Keeping track of the route resulting in the DFS
        public List<string> RouteFromStart { get; set; }
        //Keeping List of the Connections
        public List<NodeConnection> Connections { get; private set; }

        public Node(string name)
        {
            Name = name;
            Connections = new List<NodeConnection>();
            RouteFromStart = new List<string>();
            //Assuming the Node is it's own starting point
            RouteFromStart.Add(name);
        }

        //This method always adds a twoway connection A -> B means A <- B. 
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
