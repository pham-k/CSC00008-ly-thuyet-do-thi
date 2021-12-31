using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace SOURCE
{
    public class AdjacencyList {
        public int v;
        // public int[,] m;
        public Dictionary<int, List<int>> m;
        public AdjacencyList() {
            this.m = new Dictionary<int, List<int>>();
            this.v = 0;
        }
        public void ReadData(string src = "./adjacency-list-3.txt")
        {
            StreamReader file = new StreamReader(src);
            int v = int.Parse(file.ReadLine());
            this.v = v;
            this.m = new Dictionary<int, List<int>>();
            for (int key = 0; key < v; key++) {
                string line = file.ReadLine();
                List<int> val = line.Split(" ").Select(s => int.Parse(s.Trim())).ToList();
                this.m.Add(key, val);
            }

        }
        public void WriteData(string src = "./adjacency-list.txt") {
            StreamWriter file = new StreamWriter(src);
            file.WriteLine(this.v);
            foreach (var item in this.m) {
                file.WriteLine(string.Join(" ", item.Value));
            }
            file.Close();
        }
        public void PrintGraph()
        {
            Console.WriteLine(this.v);
            foreach (var item in this.m) {
                item.Value.ForEach(v => {
                    Console.Write($"{v} ");
                });
                Console.WriteLine();
            }
        }
        public bool IsUndirected() {
            bool isUndirected = true;
            foreach (var item in this.m) {
                item.Value.GetRange(1, item.Value.Count - 1).ForEach(v => {
                    if (!this.m[v].Contains(item.Key)) {
                        isUndirected = false;
                    }
                });
            }
            return isUndirected;
        }
        public AdjacencyMatrix ToAdjacencyMatrix() {
            AdjacencyMatrix am = new AdjacencyMatrix();
            am.v = this.v;
            foreach (var item in this.m) {
                List<int> edgesAM = new List<int>(); // edges of am
                for (int i = 0; i < this.v; i++) {
                    List<int> edgesAL = item.Value.GetRange(1, item.Value.Count -1);
                    if (edgesAL.Contains(i)) {
                        edgesAM.Add(1);
                    } else {
                        edgesAM.Add(0);
                    }
                }
                am.m.Add(item.Key, edgesAM);
            }
            return am;
        }
    }
}