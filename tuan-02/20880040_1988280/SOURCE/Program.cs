using System;

namespace SOURCE
{
    class Program
    {
        static void Main(string[] args)
        {
            AdjacencyMatrix AM1 = new AdjacencyMatrix();
            AM1.ReadData("./input-1.txt");
            var AL1 = AM1.ToAdjacencyList();
            AL1.PrintGraph();
            AL1.DFS();
        }
    }
}
