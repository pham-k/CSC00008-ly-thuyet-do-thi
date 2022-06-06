using System;

namespace SOURCE {
    class Program {
        static void Main(string[] args) {
            // VD 1
            // Console.WriteLine("VD1:");
            AdjacencyMatrix AM1 = new AdjacencyMatrix();
            AM1.ReadData("input-1.txt");
            // AM1.PrintGraph();
            Console.WriteLine("Chon thanh pho bat dau: ");
            int source = int.Parse(Console.ReadLine());
            Algorithm.Prim(AM1, source);
            Console.WriteLine();
            Console.WriteLine("Chon thanh pho bat dau: ");
            source = int.Parse(Console.ReadLine());
            Algorithm.PrimMax(AM1, source);
        }
    }
}
