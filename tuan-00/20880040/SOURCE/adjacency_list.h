#ifndef ADJACENCY_LIST_H
#define ADJACENCY_LIST_H

#include <iostream>
#include <fstream>
#include <string>
#include <map>
#include <vector>
#include "adjacency_matrix.h"

using std::vector;
using std::map;

class AdjacencyMatrix;
class AdjacencyList
{
    public:
        int v;
        map <int, vector<int>> g;
        void read();
        void write();
        void print_graph();
        bool is_undirected();
        AdjacencyMatrix to_adjacency_matrix();
};

#endif // !ADJACENCY_LIST_H