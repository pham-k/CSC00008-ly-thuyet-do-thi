using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CauA
{
    public class AdjacencyList {
        public List<int> Vertices;
        public List<bool> Visited;
        public List<bool> Finished;
        public Dictionary<int, List<int>> Graph;
        public AdjacencyList() {
            this.Graph = new Dictionary<int, List<int>>();
            this.Vertices = new List<int>();
            this.Finished = new List<bool>();
            this.Visited = new List<bool>();
        }
        public void ReadData(string src = "./adjacency-list-3.txt")
        {
            StreamReader file = new StreamReader(src);
            int v = int.Parse(file.ReadLine());
            this.Graph = new Dictionary<int, List<int>>();
            for (int key = 0; key < v; key++) {
                string line = file.ReadLine();
                List<int> val = line.Split(" ").Select(s => int.Parse(s.Trim())).ToList();
                this.Vertices.Add(key);
                this.Graph.Add(key, val);
            }

        }
        public void WriteData(string src = "./adjacency-list.txt") {
            StreamWriter file = new StreamWriter(src);
            file.WriteLine(GetNumberOfVertices());
            foreach (var item in this.Graph) {
                file.WriteLine(string.Join(" ", item.Value));
            }
            file.Close();
        }
        public void PrintGraph()
        {
            Console.WriteLine($"{GetNumberOfVertices()}");
            foreach (var item in this.Graph) {
                Console.Write($"{item.Key}: ");
                item.Value.ForEach(v => {
                    Console.Write($"{v} ");
                });
                Console.WriteLine();
            }
        }
        public int GetNumberOfVertices() {
            return this.Vertices.Count;
        }
        public bool IsUndirected() {
            bool isUndirected = true;
            foreach (var item in this.Graph) {
                item.Value.ForEach(v => {
                    if (!this.Graph[v].Contains(item.Key)) {
                        isUndirected = false;
                    }
                });
            }
            return isUndirected;
        }
        public AdjacencyMatrix ToAdjacencyMatrix() {
            AdjacencyMatrix am = new AdjacencyMatrix();
            int v = GetNumberOfVertices();
            am.Vertices = this.Vertices;
            foreach (var item in this.Graph) {
                // create edges of am with all zeros
                List<int> edgesAM = new List<int>(v);
                for (int i = 0; i < v; i++) {
                    edgesAM.Add(0);
                }
                foreach (var e in item.Value) {
                    edgesAM[e]++;
                }
                am.Graph.Add(item.Key, edgesAM);
            }
            return am;
        }
        public bool IsCycle() {
            if (GetNumberOfVertices() <= 2) {
                return false;
            } else {
                bool isCycle = true;
                int count = 0;
                var start = this.Vertices[0];
                List<int> visited = new List<int>();
                Stack<int> stack = new Stack<int>();
                stack.Push(start);
                while (stack.Count > 0) {
                    var v = stack.Pop();
                    visited.Add(v);
                    var adj = this.Graph[v];
                    if (adj.Count != 2) {
                        isCycle = false;
                        break;
                    }
                    count++;
                    if (count == GetNumberOfVertices() & adj.Contains(start)) {
                        break;
                    }
                    foreach (var w in adj) {
                        if (!visited.Contains(w) & !stack.Contains(w)) {
                            stack.Push(w);
                        }
                    }
                }
                return isCycle;
            }
        }
        
    }
}