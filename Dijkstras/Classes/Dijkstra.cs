using System;
using System.Collections.Generic;
using System.Linq;

namespace Classes
{
    public static class Dijkstra
    {
        public static Dictionary<string, double> CalculateDistances(Graph graph, string startNode)
        {
            if (!graph.Nodes.Any(n => n.Key == startNode))
                throw new ArgumentException("Starting node must be in graph.");

            InitializeGraph(graph, startNode);
            ProcessGraph(graph, startNode);
            return ExtractDistances(graph);
        }

        private static void InitializeGraph (Graph graph, string startNode)
        {
            foreach(var node in graph.Nodes.Values)
            {
                node.DistanceFromStart = double.PositiveInfinity;
            }

            graph.Nodes[startNode].DistanceFromStart = 0;
        }

        private static void ProcessGraph(Graph graph, string startNode)
        {
            bool finished = false;
            var queue = graph.Nodes.Values.ToList();
            while (!finished)
            {
                Node nextNode = queue.OrderBy(n => n.DistanceFromStart).FirstOrDefault(
                    n => !double.IsPositiveInfinity(n.DistanceFromStart));
                if (nextNode != null)
                {
                    ProcessNode(nextNode, queue);
                    queue.Remove(nextNode);
                }
                else
                {
                    finished = true;
                }
            }
        }

        private static void ProcessNode(Node node, List<Node> queue)
        {
            var connections = node.Connections.Where(c => queue.Contains(c.Node));
            foreach (var connection in connections)
            {
                double distance = node.DistanceFromStart + connection.Distance;
                if (distance < connection.Node.DistanceFromStart)
                    connection.Node.DistanceFromStart = distance;
            }
        }

        private static Dictionary<string, double> ExtractDistances(Graph graph)
        {
            return graph.Nodes.ToDictionary(n => n.Key, n => n.Value.DistanceFromStart);
        }
    }

}
