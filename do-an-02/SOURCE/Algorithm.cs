using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace SOURCE {
    public class Algorithm {
        public static List<int> AdjacentVertices(AdjacencyMatrix g, int v) {
            List<int> adj = new List<int>();
            for (int k = 0; k < g.GetNumberOfVertices(); k++) {
                if (g.Graph[v][k] > 0) {
                    adj.Add(k);
                }
            }
            return adj;
        }
        public static void Prim(AdjacencyMatrix g, int source = 0) {
            Console.WriteLine("Running Prim");
            int n = g.GetNumberOfVertices();
            List<Edge> T = new List<Edge>();
            int nEdges = 0;
            List<bool> marked = new List<bool>();
            for (int i = 0; i < n; i++) {
                marked.Add(false);
            }
            marked[source] = true;
            
            while (nEdges < n - 1) {
                int minimum = 999999;
                int x = 0;
                int y = 0;
                for (int v = 0; v < n; v++) {
                    if (marked[v]) {
                        foreach (int w in AdjacentVertices(g, v)) {
                            if (!marked[w]) {
                                if (minimum > g.Graph[v][w]) {
                                    minimum = g.Graph[v][w];
                                    x = v;
                                    y = w;
                                }
                            }
                        }
                        
                    }
                }
                marked[y] = true;
                nEdges += 1;
                Edge edge = new Edge(x, y, minimum);
                T.Add(edge);
            }
            // In ket qua
            int sum = 0;
            foreach (var e in T) {
                sum += e.weight;
            }
            Console.WriteLine($"Tong chi phi thap nhat: {sum}");
            Console.WriteLine("Danh sach tinh lo:");
            foreach (var e in T) {
                e.Print();
            }
        }
        public static void PrimMax(AdjacencyMatrix g, int source = 0) {
            Console.WriteLine("Running Prim");
            int n = g.GetNumberOfVertices();
            List<Edge> T = new List<Edge>();
            int nEdges = 0;
            List<bool> marked = new List<bool>();
            for (int i = 0; i < n; i++) {
                marked.Add(false);
            }
            marked[source] = true;
            
            while (nEdges < n - 1) {
                int maximum = -999999;
                int x = 0;
                int y = 0;
                for (int v = 0; v < n; v++) {
                    if (marked[v]) {
                        foreach (int w in AdjacentVertices(g, v)) {
                            if (!marked[w]) {
                                if (maximum < g.Graph[v][w]) {
                                    maximum = g.Graph[v][w];
                                    x = v;
                                    y = w;
                                }
                            }
                        }
                        
                    }
                }
                marked[y] = true;
                nEdges += 1;
                Edge edge = new Edge(x, y, maximum);
                T.Add(edge);
            }
            // In ket qua
            int sum = 0;
            foreach (var e in T) {
                sum += e.weight;
            }
            Console.WriteLine($"Tong chi phi lon nhat: {sum}");
            Console.WriteLine("Danh sach tinh lo:");
            foreach (var e in T) {
                e.Print();
            }
        }
    
    }
}