using System;

namespace SOURCE
{
    class Program
    {
        static void Main(string[] args)
        {
            AdjacencyMatrix AM = new AdjacencyMatrix();
            AM.ReadData("./input.txt");
            var AL = AM.ToAdjacencyList();

            // Cau a
            AM.PrintGraph();
            // Cau b
            if (AL.IsUndirected()) {
                Console.WriteLine("Do thi vo huong");
            } else {
                Console.WriteLine("Do thi co huong");
            }
            // Cau c
            Console.WriteLine($"So dinh cua do thi: {AM.GetNumberOfVertices()}");
            // Cau d
            Console.WriteLine($"So dinh cua do thi: {AM.GetNumberOfEdges()}");
            // Cau e
            Console.WriteLine($"So cap dinh xuat hien canh boi: ");
            // Cau e
            Console.WriteLine($"So canh khuyen: {AM.GetNumberOfLoops()}");
            // Cau f
            Console.WriteLine($"So dinh treo: {AM.GetNumberOfPendantVertices()}");
            // Cau g
            Console.WriteLine($"So dinh co lap: {AM.GetNumberOfIsolatedVertices()}");
        }
    }
}
