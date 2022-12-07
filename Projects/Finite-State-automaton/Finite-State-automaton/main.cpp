#include <bits/stdc++.h>
#include <iostream>
using namespace std;

vector<map<char, int> >g;
string x;
int End,Start;
bool state = false;

//Depth-First-Search
void solve(int node,int index)
{
    if(index == x.size())
    {
        if(node == End)state = true;
        return;
    }
    solve(g[node][x[index]],index + 1);
    return;
}



int main()
{
    // Input-Configuration-Section
    cout<< "Checking String On DFA" << endl;
    cout<< "Insert Number Of States" <<endl;
    int node;
    cin>>node;
    cout<< "Insert Number Of Edges" <<endl;
    int edge;
    cin>>edge;
    cout<< "Insert Starting point" <<endl;
    cin >> Start;
    cout<< "Insert Ending point" <<endl;
    cin >> End;
    g.resize(node + 1);
    cout<< "Insert String to checking" <<endl;
    cin>>x;
    // Transitions Handling
    int  current_state,next_state;
    char edge_between;
    for(int i = 0 ; i < edge; i++)
    {
        cout << "This transition number " << i + 1 << endl;
        cout << "Insert Current State" << endl;
        cin>>current_state;
        cout << "Insert Next State" << endl;
        cin>>next_state;
        cout << "Insert the edge between them" << endl;
        cin>>edge_between;
        g[current_state][edge_between] = next_state;
    }
    // Call DFS Methode
    solve(Start,0);
    cout<<"String " << x << " is ";
    if(state) cout<<"Accepted";
    else cout<<"Not Accepted"<<endl;
}
