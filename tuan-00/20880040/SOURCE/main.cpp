#include <iostream>
#include <fstream>
#include <string>
#include <map>
#include <vector>
#include "adjacency_matrix.h"
#include "adjacency_list.h"

using std::string;
using std::vector;
using std::map;
using std::pair;

int main ()
{
    AdjacencyMatrix AM;
    AM.v = 3;
    map <int, vector<int>> g;
    vector<int> v1 = {0, 1, 2};
    vector<int> v2 = {1, 0, 1};
    vector<int> v3 = {1, 1, 0};
    g.insert(pair<int, vector<int>>(0, v1));
    g.insert(pair<int, vector<int>>(1, v2));
    g.insert(pair<int, vector<int>>(2, v3));
    AM.g = g;
    std::cout << AM.g[0][2] << std::endl;
}