using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CauB {
    public class Edge {
        public int v { get; set; }
        public int w { get; set; }
        public int weight { get; set; }
        public Edge(int v, int w, int weight) {
            this.v = v;
            this.w = w;
            this.weight = weight;
        }
        public void Print() {
            Console.WriteLine($"{v} - {w}: {weight}");
        }
    }
}