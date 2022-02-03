using System;

namespace SOURCE
{
    class Program
    {
        static void Main(string[] args)
        {
            AdjacencyMatrix AM1 = new AdjacencyMatrix();
            AM1.ReadData("./input-3.txt");
            var AL1 = AM1.ToAdjacencyList();
            // AM1.PrintGraph();
            // AL1.PrintGraph();
            
            // Cau 2
            // Cau 2a
            if (AM1.IsComplete() >= 0) {
                Console.WriteLine($"Day la do thi day du K{AM1.IsComplete()}");
            } else {
                Console.WriteLine("Day khong phai la do thi day du");
            }
            // Cau 2b
            if (AM1.IsRegular() >= 0) {
                Console.WriteLine($"Day la do thi {AM1.IsRegular()}-chinh quy");
            } else {
                Console.WriteLine("Day khong phai la do thi chinh quy");
            }
            // Cau 2c
            if (AL1.IsCycle()) {
                Console.WriteLine($"Day la do thi vong C{AL1.GetNumberOfVertices()}");
            } else {
                Console.WriteLine("Day khong phai do thi vong");
            }
        }
    }
}
