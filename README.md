# TubesStima 2
## Aplikasi BFS dan DFS untuk Fitur People You May Know

This program was made to fulfill IF2211 Algorithm Strategy assignment using BFS and DFS algorithm to make friend recommendation and explore friend feature. <br>
Each vertex represents an account and each edge represents its connection with each other. <br>

#

### Features :
* Friend Recommendation will show the 1st degree relation nodes of node A along with the mutual 0th degree relation nodes.
* Explore Friend will show the path from node A to node B. User can choose which algorithm, either BFS or DFS, to use for this feature.

### Guide :
* The program accepts a .txt file with a format explained at the bottom. <br>
User can use the Browse button for choosing the file.
* After a file was chosen, Load button will show the basic graph and add the options for Account and Explore input.
* Search button will show the result of both feature explained above. <br> 
If no node were chosen for Account input, the program will return an error. <br>
If no node were chosen for Explore input, the program will simply ignore the Explore feature.
* The vertices on the graph will change color to show the Explore friend path.

### Requirements :
* Windows

<br>

A bit of disclaimer : <br>
I didn't explore many edge cases for this program and currently only works with alphabet node name because of time limitation. <br>

#

### Author : Muhammad Iqbal Sigid - 13519152

#

<br>

TXT file format :
```
13      // number of edges
A B     // edge
A C
A D
B C
B E
B F
C F
C G
D G
D F
E H
E F
F H
```
// is comment, dont put it on the file