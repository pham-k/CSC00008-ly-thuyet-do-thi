using System;

namespace SOURCE
{
    class Program
    {
        static void Main(string[] args)
        {
            // VD 1
            Console.WriteLine("VD1:");
            AdjacencyList AL1 = new AdjacencyList();
            AL1.ReadData("./input-1.txt");
            var AM1 = AL1.ToAdjacencyMatrix();
            // AM1.PrintGraph();
            // AL1.DFS();
            // Console.WriteLine();
            // AM1.PrintPathMatrix();
            AM1.PrintConnectedType();
            AL1.Tarjan();
            Console.WriteLine();

            // VD 2
            Console.WriteLine("VD2:");
            AdjacencyList AL2 = new AdjacencyList();
            AL2.ReadData("./input-2.txt");
            var AM2 = AL2.ToAdjacencyMatrix();
            // AM2.PrintPathMatrix();
            AM2.PrintConnectedType();
            AL2.Tarjan();
            Console.WriteLine();

            // VD 3
            Console.WriteLine("VD3:");
            AdjacencyList AL3 = new AdjacencyList();
            AL3.ReadData("./input-3.txt");
            var AM3 = AL3.ToAdjacencyMatrix();
            // AM3.PrintPathMatrix();
            AM3.PrintConnectedType();
            AL3.Tarjan();
            Console.WriteLine();

            // VD 4
            Console.WriteLine("VD4:");
            AdjacencyList AL4 = new AdjacencyList();
            AL4.ReadData("./input-4.txt");
            var AM4 = AL4.ToAdjacencyMatrix();
            // AM4.PrintPathMatrix();
            AM4.PrintConnectedType();
            AL4.Tarjan();
            Console.WriteLine();

            // VD 5
            // Console.WriteLine("VD5:");
            // AdjacencyList AL5 = new AdjacencyList();
            // AL5.ReadData("./input-5.txt");
            // var AM5 = AL5.ToAdjacencyMatrix();
            // // AM5.PrintPathMatrix();
            // AM5.PrintConnectedType();
            // Console.WriteLine();
        }
    }
}
