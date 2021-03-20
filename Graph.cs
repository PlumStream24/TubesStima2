using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubesStima2
{
    class Graph
    {
        // Attributes
        int numOfVertices;      //number of vertices
        List<String> vertices;  //list of vertices
        List<String[]> edges;   //list of edges
        
        // Constructor
        public Graph()
        {
            numOfVertices = 0;
            vertices = new List<String>();
            edges = new List<String[]>();
            
        }

        // Add edge to the graph
        // Will automatically add the vertices too
        public void AddEdge(String A, String B)
        {
            // add vertex
            if (!vertices.Contains(A))
            {
                vertices.Add(A);
                numOfVertices++;
            }
            if (!vertices.Contains(B))
            {
                vertices.Add(B);
                numOfVertices++;
            }
            // add edge
            String[] temp = { A, B };
            edges.Add(temp);
            vertices.Sort();

        }

        // Explore Friend Feature with BFS Algorithm
        public List<String> ExploreBFS(String A, String B)
        {
            bool found = false;                             //flag for if B has been visited of not
            bool[] visited = new bool[numOfVertices];       //for marking visited vertices
            for (int i = 0; i < numOfVertices; i++)
            {
                visited[i] = false;
            }

            String[] parent = new String[numOfVertices];    //for backtracking
            List<String> queue = new List<String>();        //active vertices

            visited[vertices.IndexOf(A)] = true;
            queue.Add(A);
            
            //explore the first active node until all connected node visited
            while (queue.Any())
            {
                String v1 = queue.First();
                queue.Remove(v1);

                List<String> adj = AdjVertices(v1);         //get adjacent vertices of v1

                //explore those adjacent vertices
                foreach (String val in adj)
                {
                    // if not visited, add to queue, set as visited, and add the parent
                    if (!visited[vertices.IndexOf(val)])
                    {
                        visited[vertices.IndexOf(val)] = true;
                        queue.Add(val);
                        parent[vertices.IndexOf(val)] = v1;

                        //if B is visited, mark the flag
                        if (val == B)
                        {
                            found = true;
                        }
                    }   
                }
            }

            //backtrack to find the path from A to B
            //result is a list of vertices from A to B, e.g. -> [A, E, G, B]
            List<String> path;
            if (found)
            {
                path = Backtrace(A, B, parent);
            } else
            {
                path = new List<String>();
                path.Add("-1");
            }

            return path;

        }

        //Friend Recommendation using BFS Algorithm
        public List<List<String>> FriendRecBFS(String A)
        {
            bool[] visited = new bool[numOfVertices];       //for marking visited vertices
            for (int i = 0; i < numOfVertices; i++)
            {
                visited[i] = false;
            }

            List<String> adjA = AdjVertices(A);             //adjacent vertices of A
            List<String> queue = new List<String>();        //active vertices
            List<String> vertices2 = new List<String>();    //2nd degree vertices

            visited[vertices.IndexOf(A)] = true;
            queue.Add(A);

            //getting the 2nd degree vertices
            int degree = 1;
            while (degree <= 2)
            {
                //adding the unvisited adjacent vertices to vertices2
                foreach (String v in queue)
                {
                    List<String> adjV = AdjVertices(v);
                    foreach (String val in adjV)
                    {
                        if (!visited[vertices.IndexOf(val)])
                        {
                            vertices2.Add(val);
                            visited[vertices.IndexOf(val)] = true;
                        }
                    }
                }
                
                //move vertices2 to queue if it's the first loop
                if (degree < 2)
                {
                    queue.Clear();
                    queue = new List<string>(vertices2);
                    vertices2.Clear();
                }

                degree++;
            }

            //grouping common adjacent vertices of A and 2nd degree vertices
            //result is [[E,B,C,D], ...] means E and A is adjacent to B, C, and D
            List<List<String>> firstDegree = new List<List<String>>(adjA.Count());
            int idx = 0;
            foreach (String v in vertices2)
            {
                firstDegree.Add(new List<String>());
                List<String> adjV = AdjVertices(v);
                firstDegree[idx].Add(v);
                foreach (String a in adjA)
                {
                    if (adjV.Contains(a))
                    {
                        firstDegree[idx].Add(a);
                    }
                }
                idx++;
            }

            return firstDegree;
            
        }
        
        //Return the adjacent vertices of vertex A
        public List<String> AdjVertices(String A)
        {
            List<String> adjA = new List<String>();
            foreach (String[] v in edges)
            {
                if (v[0] == A && !adjA.Contains(v[1]))
                {
                    adjA.Add(v[1]);
                }
                if (v[1] == A && !adjA.Contains(v[0]))
                {
                    adjA.Add(v[0]);
                }
            }

            return adjA;
        }

        //backtracking from end to start by exploring the parent array
        public List<String> Backtrace(String start, String end, String[] parent)
        {
            List<String> path = new List<String>();
            String prev = end;
            path.Add(end);
            while (prev != start)
            {
                String par = parent[vertices.IndexOf(prev)];
                path.Add(par);
                prev = par;
            }

            path.Reverse();

            return path;
        }


    }
}
