using System;

namespace SOURCE
{
    class Program
    {
        static void Main(string[] args)
        {
            // AdjacencyMatrix AM = new AdjacencyMatrix();
            // AM.ReadData("./adjacency-matrix-2.txt");
            // AM.PrintGraph();
            // if (AM.IsSymmetric()) {
            //     Console.WriteLine("Ma tran doi xung");
            // } else {
            //     Console.WriteLine("Ma tran khong doi xung");
            // }
            // var al = AM.ToAdjacencyList();
            // al.WriteData("./adjacency-list.txt");

            AdjacencyList AL = new AdjacencyList();
            AL.ReadData("./adjacency-list-2.txt");
            // AL.PrintGraph();
            // if (AL.IsUndirected()) {
            //     Console.WriteLine("Do thi vo huong");
            // } else {
            //     Console.WriteLine("Do thi co huong");
            // }
            var am = AL.ToAdjacencyMatrix();
            am.WriteData("./adjacency-matrix.txt");
        }
    }
}
