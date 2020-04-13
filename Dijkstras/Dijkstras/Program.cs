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
            graph.AddNode("G");
            graph.AddNode("H");
            graph.AddNode("I");
            graph.AddNode("J");
            graph.AddNode("Z");

            //Connections
            graph.AddConnection("A", "B", 14);
            graph.AddConnection("A", "C", 10);
            graph.AddConnection("A", "D", 14);
            graph.AddConnection("A", "E", 21);
            graph.AddConnection("B", "C", 9);
            graph.AddConnection("B", "E", 10);
            graph.AddConnection("B", "F", 14);
            graph.AddConnection("C", "D", 9);
            graph.AddConnection("D", "G", 10);
            graph.AddConnection("E", "H", 11);
            graph.AddConnection("F", "C", 10);
            graph.AddConnection("F", "H", 10);
            graph.AddConnection("F", "I", 9);
            graph.AddConnection("G", "F", 8);
            graph.AddConnection("G", "I", 9);
            graph.AddConnection("H", "J", 9);
            graph.AddConnection("I", "J", 10);

            var distances = Dijkstra.CalculateDistances(graph, "G");  // Start from "G"

            foreach (var d in distances)
            {
                Console.WriteLine("{0}, {1}", d.Key, d.Value);
            }
        }
    }
}
