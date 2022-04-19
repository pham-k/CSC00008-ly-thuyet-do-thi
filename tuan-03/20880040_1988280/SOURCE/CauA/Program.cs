using System;

namespace CauA {
    class Program {
        static void Main(string[] args) {
            // VD 1
            Console.WriteLine("VD1:");
            AdjacencyMatrix AM1 = new AdjacencyMatrix();
            AM1.ReadData("input-1.txt");
            // AM1.PrintGraph();
            Console.WriteLine("Chon dinh bat dau: ");
            int source = int.Parse(Console.ReadLine());
            Algorithm.Prim(AM1, source);
            Console.WriteLine();

            // VD 2
            Console.WriteLine("VD2:");
            AdjacencyMatrix AM2 = new AdjacencyMatrix();
            AM2.ReadData("./input-2.txt");
            Console.WriteLine("Chon dinh bat dau: ");
            source = int.Parse(Console.ReadLine());
            Algorithm.Prim(AM2, source);
            Console.WriteLine();

            // VD 3
            // Console.WriteLine("VD3:");
            // AdjacencyMatrix AM3 = new AdjacencyMatrix();
            // AM3.ReadData("./input-3.txt");
            // // Console.WriteLine("Chon dinh bat dau: ");
            // // source = int.Parse(Console.ReadLine());
            // Algorithm.Prim(AM3, 0);
            // Console.WriteLine();
        }
    }
}
