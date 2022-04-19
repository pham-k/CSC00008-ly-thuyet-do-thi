using System;

namespace CauB {
    class Program {
        static void Main(string[] args) {
            // VD 1
            Console.WriteLine("VD1:");
            AdjacencyMatrix AM1 = new AdjacencyMatrix();
            AM1.ReadData("input-1.txt");
            // AM1.PrintGraph();
            Algorithm.Kruskal(AM1);
            Console.WriteLine();

            // VD 2
            Console.WriteLine("VD2:");
            AdjacencyMatrix AM2 = new AdjacencyMatrix();
            AM2.ReadData("./input-2.txt");
            Algorithm.Kruskal(AM2);
            Console.WriteLine();

            // VD 3
            // Console.WriteLine("VD3:");
            // AdjacencyMatrix AM3 = new AdjacencyMatrix();
            // AM3.ReadData("./input-3.txt");
            // Algorithm.Kruskal(AM3);
            // Console.WriteLine();
        }
    }
}
