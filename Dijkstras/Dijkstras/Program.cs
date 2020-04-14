using System;
using Classes;

namespace Dijkstras
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();

            //Nodes
            graph.AddNode("A");
            graph.AddNode("B");
            graph.AddNode("C");
            graph.AddNode("D");
            graph.AddNode("E");

            //Connections
            graph.AddConnection("A", "B", 6);
            graph.AddConnection("A", "D", 1);
            graph.AddConnection("D", "B", 2);
            graph.AddConnection("D", "E", 1);
            graph.AddConnection("E", "B", 2);
            graph.AddConnection("E", "C", 5);
            graph.AddConnection("B", "C", 5);

            var distances = Dijkstra.CalculateDistances(graph, "A");  // Start from "A"

            foreach (var d in distances)
            {
                Console.WriteLine("{0}, {1}", d.Key, d.Value);
            }
        }
    }
}
