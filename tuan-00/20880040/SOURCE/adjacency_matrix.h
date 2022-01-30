#ifndef ADJACENCY_MATRIX_H
#define ADJACENCY_MATRIX_H

#include <map>
#include <vector>
#include "adjacency_list.h"

using std::vector;
using std::map;

class AdjacencyList;
class AdjacencyMatrix
{
    public:
        int v;
        map <int, vector<int>> g;
        void read();
        void write();
        void print_graph();
        bool is_symmetric();
        AdjacencyList to_adjacency_list();
};

#endif
