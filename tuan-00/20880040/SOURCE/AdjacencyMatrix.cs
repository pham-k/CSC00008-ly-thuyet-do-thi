using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace SOURCE
{
    public class AdjacencyMatrix {
        public int v;
        public Dictionary<int, List<int>> m;
        public AdjacencyMatrix() {
            this.v = 0;
            this.m = new Dictionary<int, List<int>>();
        }
        public void ReadData(string src = "./adjacency-matrix.txt")
        {
            StreamReader file = new StreamReader(src);
            int v = int.Parse(file.ReadLine());
            this.v = v;
            for (int i = 0; i < v; i++) {
                string line = file.ReadLine();
                List<int> edges = line.Split(" ").Select(s => int.Parse(s.Trim())).ToList<int>();
                this.m.Add(i, edges);
            }
            file.Close();
        }
        public void WriteData(string src = "./adjacency-matrix.txt") {
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
                item.Value.ForEach(e => {
                    Console.Write($"{e} ");
                });
                Console.WriteLine();
            }
        }
        public bool IsSymmetric() {
            bool isSymmetric = true;
            for (int i = 0; i < this.v; i++) {
                for (int j = i; j < this.v; j++) {
                    if (this.m[i][j] != this.m[j][i]) {
                        isSymmetric = false;
                        break;
                    }
                }
            }
            return isSymmetric;
        }
        public AdjacencyList ToAdjacencyList() {
            AdjacencyList al = new AdjacencyList();
            al.v = this.v;
            for (int i = 0; i < v; i++) {
                int count = 0;
                List<int> val = new List<int>();
                for (int j = 0; j < v; j++) {
                    if (m[i][j] == 1) {
                       val.Add(j);
                       count++;
                    }
                }
                val.Insert(0, count);
                al.m.Add(i, val);
            }
            return al;
        }
    }
}