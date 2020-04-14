using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public static class Dijkstra
    {
        public static string CalculateDistances(Graph graph, string startNode)
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
                {
                    connection.Node.DistanceFromStart = distance;
                    SetNewRoute(node, connection);
                }
            }
        }

        private static void SetNewRoute(Node node, NodeConnection connection)
        {
            connection.Node.Path.Clear();
            foreach (var n in node.Path)
            {
                connection.Node.Path.Add(n);
            }
            connection.Node.Path.Add(connection.Node.Name);
        }

        private static string ExtractDistances(Graph graph)
        {
            StringBuilder str1 = new StringBuilder();
            foreach (var node in graph.Nodes)
            {
                StringBuilder str2 = new StringBuilder();
                foreach(var n in node.Value.Path)
                {
                    str2.Append(n + ",");
                }

                str1.Append($"{node.Key}, {node.Value.DistanceFromStart}. Route: {str2.ToString()} \n");
            }

            return str1.ToString();
        }
    }

}
