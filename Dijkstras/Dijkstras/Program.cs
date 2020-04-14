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
            graph.AddNode("F");


            //Connections
            graph.AddConnection("A", "B", 20);
            graph.AddConnection("A", "C", 1);
            graph.AddConnection("B", "D", 5);
            graph.AddConnection("D", "C", 1);
            graph.AddConnection("C", "E", 3);
            graph.AddConnection("C", "F", 10);
            graph.AddConnection("D", "F", 2);

            var distances = Dijkstra.CalculateDistances(graph, "A");  // Start from "A"

            Console.WriteLine(distances);
        }
    }
}
