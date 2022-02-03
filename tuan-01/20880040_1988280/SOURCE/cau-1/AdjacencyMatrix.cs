using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace SOURCE
{
    public class AdjacencyMatrix {
        public List<int> Vertices;
        public Dictionary<int, List<int>> Graph;
        public AdjacencyMatrix() {
            this.Vertices = new List<int>();
            this.Graph = new Dictionary<int, List<int>>();
        }
        public void ReadData(string src = "./adjacency-matrix.txt")
        {
            StreamReader file = new StreamReader(src);
            int v = int.Parse(file.ReadLine());
            for (int i = 0; i < v; i++) {
                string line = file.ReadLine();
                List<int> edges = line.Split(" ").Select(s => int.Parse(s.Trim())).ToList<int>();
                this.Vertices.Add(i);
                this.Graph.Add(i, edges);
            }
            file.Close();
        }
        public void WriteData(string src = "./adjacency-matrix.txt") {
            StreamWriter file = new StreamWriter(src);
            file.WriteLine(GetNumberOfVertices());
            foreach (var item in this.Graph) {
                file.WriteLine(string.Join(" ", item.Value));
            }
            file.Close();
        }
        public void PrintGraph()
        {
            Console.WriteLine(GetNumberOfVertices());
            foreach (var item in this.Graph) {
                item.Value.ForEach(e => {
                    Console.Write($"{e} ");
                });
                Console.WriteLine();
            }
        }
        public bool IsSymmetric() {
            bool isSymmetric = true;
            int v = GetNumberOfVertices();
            for (int i = 0; i < v; i++) {
                for (int j = i; j < v; j++) {
                    if (this.Graph[i][j] != this.Graph[j][i]) {
                        isSymmetric = false;
                        break;
                    }
                }
            }
            return isSymmetric;
        }
        public AdjacencyList ToAdjacencyList() {
            AdjacencyList al = new AdjacencyList();
            al.Vertices = this.Vertices;
            int v = GetNumberOfVertices();
            foreach (var item in this.Graph) {
                int key = item.Key;
                var edgesAM = item.Value;
                List<int> edgesAL = new List<int>();
                for (int i = 0; i < edgesAM.Count; i++) {
                    for (int j = 0; j < edgesAM[i]; j++) {
                        edgesAL.Add(i);
                    }
                }
                al.Graph.Add(key, edgesAL);
            }
            // for (int i = 0; i < v; i++) {
            //     int count = 0;
            //     List<int> val = new List<int>();
            //     for (int j = 0; j < v; j++) {
            //         if (this.Graph[i][j] == 1) {
            //            val.Add(j);
            //            count++;
            //         }
            //     }
            //     val.Insert(0, count);
            //     al.m.Add(i, val);
            // }
            return al;
        }
    
        public int GetNumberOfVertices() {
            return this.Vertices.Count;
        }
        public int GetNumberOfEdges() {
            int number = 0;
            var AL = this.ToAdjacencyList();
            int v = GetNumberOfVertices();
            if (AL.IsUndirected()) {
                for (int i = 0; i < v; i++) {
                    number += GetDegree(i);
                }
                return number / 2;
            } else {
                foreach (var item in this.Graph) {
                    number += item.Value.Sum();
                }
                return number;
            }
        }
        public int GetNumberOfVerticesPairHavingMultipleEdges() {
            int number = 0;
            var AL = this.ToAdjacencyList();
            foreach (var item in this.Graph) {
                foreach (int e in item.Value) {
                    if (e > 1) {
                        number += 1;
                    }
                }
            }
            if (AL.IsUndirected()) {
                return number / 2;
            } else {
                return number;
            }
        }
        public int GetNumberOfPendantVertices() {
            int number = 0;
            int v = GetNumberOfVertices();
            for (int i = 0; i < v; i++) {
                if (GetDegree(i) == 1) {
                    number += 1;
                }
            }
            return number;
        }
        public int GetNumberOfIsolatedVertices() {
            int number = 0;
            int v = GetNumberOfVertices();
            for (int i = 0; i < v; i++) {
                if (GetDegree(i) == 0) {
                    number += 1;
                }
            }
            return number;
        }
        public int GetNumberOfLoops() {
            int number = 0;
            int v = GetNumberOfVertices();
            for (int i = 0; i < v; i++) {
                if (this.Graph[i][i] >= 1) {
                    number += this.Graph[i][i];
                }
            }
            return number;
        }
        public int GetIndegree(int vertex) {
            int degree = 0;
            foreach (var item in this.Graph) {
                degree += item.Value[vertex];
            }
            return degree;
        }
        public int GetOutdegree(int vertex) {
            int degree = 0;
            degree = degree + this.Graph[vertex].Sum();
            return degree;
        }
        public int GetDegree(int vertex) {
            var AL = this.ToAdjacencyList();
            int degree = 0;
            if (AL.IsUndirected()) {
                degree = this.Graph[vertex].Sum() + this.Graph[vertex][vertex];
                return degree;
            } else {
                degree = GetIndegree(vertex) + GetOutdegree(vertex);
                return degree;
            } 
        }
        public string GetGraphType() {
            string type = "";
            var AL = this.ToAdjacencyList();
            if (AL.IsUndirected()) {
                if (GetNumberOfLoops() > 0) {
                    type = "Gia do thi";
                } else if (GetNumberOfVerticesPairHavingMultipleEdges() > 0) {
                    type = "Da do thi";
                } else {
                    type = "Don do thi";
                }
            } else {
                if (GetNumberOfVerticesPairHavingMultipleEdges() > 0) {
                    type = "Da do thi co huong";
                } else {
                    type = "Do thi co huong";
                }
            }
            return type;
        } 
        public int IsComplete() {
            // Chi dung voi don do thi
            int v = GetNumberOfVertices();
            int e = GetNumberOfEdges();
            if (e == (v * (v-1) / 2)) {
                return v;
            } else {
                return -1;
            }
        }
        public int IsRegular() {
            int degree = GetDegree(0);
            int v = GetNumberOfVertices();
            bool isRegular = true;
            for (int i = 0; i < v; i++) {
                if (GetDegree(i) != degree) {
                    isRegular = false;
                    break;
                }
            }
            if (isRegular) {
                return degree;
            } else {
                return -1;
            }
        }
    }
}