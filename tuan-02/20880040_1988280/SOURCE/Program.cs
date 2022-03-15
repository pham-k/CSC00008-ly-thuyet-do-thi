using System;

namespace SOURCE
{
    class Program
    {
        static void Main(string[] args)
        {
            // VD 1
            Console.WriteLine("VD1:");
            AdjacencyMatrix AM1 = new AdjacencyMatrix();
            AM1.ReadData("./input-1.txt");
            var AL1 = AM1.ToAdjacencyList();
            // AL1.PrintGraph();
            AL1.DFS();
            Console.WriteLine();

            // VD 2
            Console.WriteLine("VD2:");
            AdjacencyMatrix AM2 = new AdjacencyMatrix();
            AM2.ReadData("./input-2.txt");
            var AL2 = AM2.ToAdjacencyList();
            // AL2.PrintGraph();
            AL2.DFS();
            Console.WriteLine();

            // VD 3
            Console.WriteLine("VD3:");
            AdjacencyMatrix AM3 = new AdjacencyMatrix();
            AM3.ReadData("./input-3.txt");
            var AL3 = AM3.ToAdjacencyList();
            // AL3.PrintGraph();
            AL3.BFS();
            Console.WriteLine();

            // VD 4
            Console.WriteLine("VD4:");
            AdjacencyMatrix AM4 = new AdjacencyMatrix();
            AM4.ReadData("./input-4.txt");
            var AL4 = AM4.ToAdjacencyList();
            // AL1.PrintGraph();
            AL4.BFS();
            Console.WriteLine();

            // VD 5
            Console.WriteLine("VD5:");
            AdjacencyMatrix AM5 = new AdjacencyMatrix();
            AM5.ReadData("./input-5.txt");
            var AL5 = AM5.ToAdjacencyList();
            // AL5.PrintGraph();
            AL5.GetNumberOfComponents();
            Console.WriteLine();

            // VD 6
            Console.WriteLine("VD6:");
            AdjacencyMatrix AM6 = new AdjacencyMatrix();
            AM6.ReadData("./input-6.txt");
            var AL6 = AM6.ToAdjacencyList();
            // AL5.PrintGraph();
            AL6.GetNumberOfComponents();
            Console.WriteLine();
        }
    }
}
