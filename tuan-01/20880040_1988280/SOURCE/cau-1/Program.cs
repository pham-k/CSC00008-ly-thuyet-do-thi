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
            // AM1.PrintGraph();
            // AL1.PrintGraph();
            
            // Cau 1
            // Cau 1a
            AM1.PrintGraph();
            // Cau 1b
            if (AL1.IsUndirected()) {
                Console.WriteLine("Do thi vo huong");
            } else {
                Console.WriteLine("Do thi co huong");
            }
            // Cau 1c
            Console.WriteLine($"So dinh cua do thi: {AM1.GetNumberOfVertices()}");
            // Cau 1d
            Console.WriteLine($"So canh cua do thi: {AM1.GetNumberOfEdges()}");
            // Cau 1e
            Console.WriteLine($"So cap dinh xuat hien canh boi: {AM1.GetNumberOfVerticesPairHavingMultipleEdges()}");
            // Cau 1e
            Console.WriteLine($"So canh khuyen: {AM1.GetNumberOfLoops()}");
            // Cau 1f
            Console.WriteLine($"So dinh treo: {AM1.GetNumberOfPendantVertices()}");
            // Cau 1g
            Console.WriteLine($"So dinh co lap: {AM1.GetNumberOfIsolatedVertices()}");
            if (AL1.IsUndirected()) {
                Console.Write($"Bac cua tung dinh: ");
                for (int i = 0; i < AM1.GetNumberOfVertices(); i++) {
                    Console.Write($"{i}({AM1.GetDegree(i)}), ");
                }
                Console.WriteLine("");
            } else {
                Console.Write($"(Bac vao - Bac ra) cua tung dinh: ");
                for (int i = 0; i < AM1.GetNumberOfVertices(); i++) {
                    Console.Write($"{i}({AM1.GetIndegree(i)}-{AM1.GetOutdegree(i)}), ");
                }
                Console.WriteLine("");
            }
            // Cau 1h
            Console.WriteLine(AM1.GetGraphType());
        }
    }
}
