using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace SOURCE
{
    public class AdjacencyList {
        public List<int> Vertices;
        public int Start;
        public int Goal;
        public List<bool> Visited;
        public List<bool> Finished;
        public Dictionary<int, List<int>> Graph;
        public int Id;
        public int SCCCount;
        public List<int> Ids;
        public List<int> Low;
        public List<bool> OnStack;
        public Stack<int> Stack;
        public AdjacencyList() {
            this.Graph = new Dictionary<int, List<int>>();
            this.Vertices = new List<int>();
            this.Finished = new List<bool>();
            this.Visited = new List<bool>();
            this.Ids = new List<int>();
            this.Low = new List<int>();
            this.OnStack = new List<bool>();
            this.Stack = new Stack<int>();
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
                this.Graph.Add(key, val.GetRange(1, val.Count - 1));
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
            // Console.WriteLine($"{GetNumberOfVertices()}");
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
            am.GetPathMatrix();
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
        public void DFS() {
            List<int> visited = new List<int>();
            Stack<int> stack = new Stack<int>();
            List<int> parent = new List<int>();
            for (int i = 0; i < GetNumberOfVertices(); i++) {
                parent.Add(-1);
            }
            stack.Push(this.Start);
            while (stack.Count > 0) {
                var v = stack.Pop();
                if (!visited.Contains(v)) {
                    visited.Add(v);
                }
                // Goal found
                if (v == this.Goal) {
                    break;
                }
                // Adjacency list of current vertex, sort decending
                var adj = this.Graph[v];
                if (adj.Count > 0) {
                    adj.Sort((a, b) => b.CompareTo(a));
                    foreach (var w in adj) {
                        if (!visited.Contains(w)) {
                            stack.Push(w);
                            parent[w] = v;
                        }
                    }
                }
            }
            // Print visited
            Console.Write("Danh sach dinh da duyet theo thu tu: ");
            visited.ForEach(e => {
                Console.Write($"{e} ");
            });
            Console.WriteLine();
            // Print parent
            // Console.Write("parent: ");
            // parent.ForEach(e => {
            //     Console.Write($"{e} ");
            // });
            Console.WriteLine();
            // Print path
            Console.Write($"Duong di in kieu nguoc: {this.Goal}");
            int c = this.Goal;
            while (c != this.Start) {
                Console.Write($" <- {parent[c]}");
                c = parent[c];
            }
            Console.WriteLine();
        }
        public void BFS() {
            List<int> visited = new List<int>();
            Queue<int> queue = new Queue<int>();
            List<int> parent = new List<int>();
            for (int i = 0; i < GetNumberOfVertices(); i++) {
                parent.Add(-1);
            }
            queue.Enqueue(this.Start);
            while (queue.Count > 0) {
                var v = queue.Dequeue();
                if (!visited.Contains(v)) {
                    visited.Add(v);
                }
                // Goal found
                if (v == this.Goal) {
                    break;
                }
                // Adjacency list of current vertex, sort decending
                var adj = this.Graph[v];
                if (adj.Count > 0) {
                    adj.Sort((a, b) => a.CompareTo(b));
                    foreach (var w in adj) {
                        if ((!visited.Contains(w)) & (!queue.Contains(w))) {
                            parent[w] = v;
                            queue.Enqueue(w);
                        }
                    }
                }
            }
            // Print visited
            Console.Write("Danh sach dinh da duyet theo thu tu: ");
            visited.ForEach(e => {
                Console.Write($"{e} ");
            });
            Console.WriteLine();
            // Print parent
            // Console.Write("parent: ");
            // parent.ForEach(e => {
            //     Console.Write($"{e} ");
            // });
            Console.WriteLine();
            // Print path
            Console.Write($"Duong di in kieu nguoc: {this.Goal}");
            int c = this.Goal;
            while (c != this.Start) {
                Console.Write($" <- {parent[c]}");
                c = parent[c];
            }
            Console.WriteLine();
        }
        public void Visit(int vertex, int label, int[] labels) {
            labels[vertex] = label;
            var adj = this.Graph[vertex];
            foreach (var w in adj) {
                if (labels[w] == 0) {
                    Visit(w, label, labels);
                }
            }
        }
        public void GetNumberOfComponents() {
            int v = GetNumberOfVertices();
            int label = 0;
            int[] labels = new int[GetNumberOfVertices()];
            for (int i = 0; i < v; i++) {
                labels[i] = 0;
            }
            for (int i = 0; i < v; i++) {
                if (labels[i] == 0) {
                    label++;
                    Visit(i, label, labels);
                }
            }
            int number = labels.Max();
            Console.WriteLine($"So thanh phan lien thong: {number}");
            for (int i = 1; i <= number; i++) {
                Console.Write($"Thanh phan lien thong thu {i}: ");
                for (int j = 0; j < v; j++) {
                    if (labels[j] == i) {
                        Console.Write($"{j} ");
                    }
                }
                Console.WriteLine();
            }
        }
        public void Tarjan() {
            int v = GetNumberOfVertices();
            this.Id = 0;
            this.SCCCount = 0;
            this.Stack.Clear();
            this.Ids.Clear();
            this.Low.Clear();
            this.OnStack.Clear();
            // initialize
            for (int i = 0; i < v; i++) {
                this.Ids.Add(-1); // -1 is unvisited
                this.Low.Add(-1);
                this.OnStack.Add(false);
            }
            for (int i = 0; i < v; i++) {
                if (this.Ids[i] == -1) {
                    TarjanUtil(i);
                }
            }
        }
        public void TarjanUtil(int v) {
            this.Ids[v] = this.Id;
            this.Low[v] = this.Id;
            this.Id = this.Id + 1;
            this.OnStack[v] = true;
            this.Stack.Push(v);
            foreach (int w in this.Graph[v]) {
                if (this.Ids[w] == -1) {
                    TarjanUtil(w);
                    this.Low[v] = Math.Min(this.Low[v], this.Low[w]);
                }
                else if (this.OnStack[w]) {
                    this.Low[v] = Math.Min(this.Low[v], this.Low[w]);
                }
            }
            int node = -1;
            if (this.Ids[v] == this.Low[v]) {
                Console.Write("Thanh phan lien thong manh ");
                while (node != v) {
                    node = this.Stack.Pop();
                    Console.Write($"{node}, ");
                    this.OnStack[node] = false;
                }
                Console.WriteLine();
                this.SCCCount++;
            }
        }
    }
}