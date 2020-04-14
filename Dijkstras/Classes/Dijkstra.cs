using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Classes
{
    public static class Dijkstra
    {
        // MAIN METHOD
        public static string CalculateDistances(Graph graph, string startNode)
        {
            // First checking that our starting Node actually is in the graph.
            if (!graph.Nodes.Any(n => n.Key == startNode))
                throw new ArgumentException("Starting node must be in graph.");

            // Setting all DistancesFromStart to infinite
            InitializeGraph(graph, startNode);
            
            // Calculating DistanceFromStart for every Node
            ProcessGraph(graph);
            
            //Returning a result string displaying both DistanceFromStart and also what
            // Route that resulted in (including start and end Node)
            return ExtractDistances(graph);
        }

        // This method loops through all the Nodes in the graph and sets the 
        // DistanceFromStart to infinity
        private static void InitializeGraph (Graph graph, string startNode)
        {
            foreach (var node in graph.Nodes.Values)
            {
                node.DistanceFromStart = double.PositiveInfinity;
            }

            // The start node of course will have a known distance of 0 (from itself)
            // so we set that here.
            graph.Nodes[startNode].DistanceFromStart = 0;
        }

        // This method will process all the nodes in the graph, setting the DistanceFromStart
        // and Route property of every node. The method will run in a loop until all nodes that
        // CAN be processed (are reachable) are processed.
        private static void ProcessGraph(Graph graph)
        {
            bool finished = false;

            // A list of all the Nodes
            var queue = graph.Nodes.Values.ToList();
            
            while (!finished)
            {
                // Grabbing the node from queue with shortest DistanceFromStart (OrderBy)
                // for processing of that Nodes connections. At first loop it will be the 
                // start Node and that will result in new DFS being calculated. 
                // FirstOrDefault will make
                // sure we are only given reachable Nodes. If there are only nodes left
                // with infinite DistanceFromStart that means they are unreachable and 
                // FirstOrDefault will return null and we exit method.
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

        // This method works through a Nodes connections checking updating the
        // DistanceFromStart and Route.
        // The Node will basically be like:
        // - Hi wazzup? My DistanceFromStart is X and getting here was Z, X+Z = Y.
        // - Hey! Y is way lower than my current DistanceFromStart via this Route,
        // I should definately go via your Route instead.
        // Then the methods updated that connecting Nodes DistanceFromStart and Route 
        // accordningly and everything moves on. If it turns out the DistanceFromStart was
        // higher nothing will happen.
        private static void ProcessNode(Node node, List<Node> queue)
        {
            var connections = node.Connections.Where(c => queue.Contains(c.Node));
            foreach (var connection in connections)
            {
                // Y = X + Z (se comment above)
                double distance = node.DistanceFromStart + connection.Distance;
                // Is tis better than current DFS and Route? Update
                if (distance < connection.Node.DistanceFromStart)
                {
                    // Update DFS
                    connection.Node.DistanceFromStart = distance;
                    // Update Route
                    SetNewRoute(node, connection);
                }
            }
        }

        //Updateing a Nodes Route, basically copying the Route from the Node with a
        // better Route
        private static void SetNewRoute(Node node, NodeConnection connection)
        {
            connection.Node.RouteFromStart.Clear();
            foreach (var n in node.RouteFromStart)
            {
                connection.Node.RouteFromStart.Add(n);
            }
            connection.Node.RouteFromStart.Add(connection.Node.Name);
        }

        //Making a printable result out of everyting.
        private static string ExtractDistances(Graph graph)
        {
            StringBuilder result = new StringBuilder();
            
            foreach (var node in graph.Nodes)
            {
                StringBuilder route = new StringBuilder();
                foreach(var n in node.Value.RouteFromStart)
                {
                    route.Append(n + ",");
                }

                result.Append($"{node.Value.Name}, {node.Value.DistanceFromStart}. Route: {route} \n");
            }

            return result.ToString();
        }
    }

}
