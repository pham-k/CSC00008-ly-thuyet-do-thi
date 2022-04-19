using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CauB {
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
        public static int Find(List<int> parent, int i) {
            if (parent[i] == i) {
                return i;
            }
            else {
                return Find(parent, parent[i]);
            }
        }
        public static void Union(List<int> parent, List<int> rank, int x, int y) {
            var xRoot = Find(parent, x);
            var yRoot = Find(parent, y);
            if (rank[xRoot] < rank[yRoot]) {
                parent[xRoot] = yRoot;
            }
            else if (rank[xRoot] > rank[yRoot]) {
                parent[yRoot] = xRoot;
            }
            else {
                parent[yRoot] = xRoot;
                rank[xRoot] += 1;
            }
        }
        public static void Kruskal(AdjacencyMatrix am) {
            Console.WriteLine("Running Kruskal");
            List<Edge> mst = new List<Edge>();
            List<int> parent = new List<int>();
            List<int> rank = new List<int>();
            int i = 0;
            int e = 0;
            int n = am.GetNumberOfVertices();
            PriorityQueue<Edge, int> lstEdges = new PriorityQueue<Edge, int>();
            for (int v = 0; v < n; v++) {
                parent.Add(v);
                rank.Add(0);
                // Create sorted list of edges by weight
                for (int w = v; w < n; w++) {
                    if (am.Graph[v][w] > 0) {
                        var edge = new Edge(v, w, am.Graph[v][w]);
                        lstEdges.Enqueue(edge, edge.weight);
                    }
                }
            }
            // Print lstEdges
            // while (lstEdges.TryDequeue(out Edge edge, out int priority))
            // {
            //     Console.WriteLine($"{edge.v} - {edge.w}: {priority}");
            // }
            while (e < n - 1) {
                var minEdge = lstEdges.Dequeue();
                int x = Find(parent, minEdge.v);
                int y = Find(parent, minEdge.w);
                if (x != y) {
                    // Console.WriteLine($"{minEdge.v} - {minEdge.w}: {minEdge.weight}");
                    e += 1;
                    mst.Add(minEdge);
                    Union(parent, rank, x, y);
                }
            }
            // In ket qua
            Console.WriteLine("Tap canh cua cay khung:");
            int sum = 0;
            foreach (var edge in mst) {
                edge.Print();
                sum += edge.weight;
            }
            Console.WriteLine($"Trong so cua cay khung nho nhat: {sum}");
                   
        }
    }
}