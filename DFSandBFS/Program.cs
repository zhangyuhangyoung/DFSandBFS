using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DFSandBFS
{
        //Directed graph-Adjacency list representation
        class clsGraph
        {
            //total no of vertices
            private int vertices;
            //adjacency list array for all vertices
            private List<Int32>[] adj;
            //Constructor
            public clsGraph(int V){
                vertices = V;
                adj = new List<Int32>[V];
                //Instantlate adjacency list for all vertices
                for(int i = 0; i < V; i++)
                {
                    adj[i] = new List<Int32>();
                }
        }
            //Add edge from V->W
            public void AddEdge(int v,int w)
            {
                adj[v].Add(w);
            }
            //print BFS traversal
            //S-> start node
            //BFS uses queue as a base
            void BFS(int s)
            {
                bool[] visited = new bool[vertices];
                //Create queue for BFS
                Queue<int> queue = new Queue<int>();
                visited[s] = true;
                queue.Enqueue(s);

                //Loop throght all nodes in queue
                while (queue.Count != 0)
                {
                    //deque a vertex from queue and print it.
                    s = queue.Dequeue();
                    Console.WriteLine(" next->" + s);
                    //GEt all adjacency vertuces of s
                    foreach(Int32 next in adj[s])
                    {
                        if (!visited[next]){
                            visited[next] = true;
                            queue.Enqueue(next);
                        }
                    }
                }

            }
            //DFS traversal DFS uses stack as a base
            public void DFS(int s)
            {
                bool[] visited = new bool[vertices];
                //for DFS use stact
                Stack<int> stack = new Stack<int>();
                visited[s] = true;
                stack.Push(s);
                while (stack.Count != 0)
                {
                    s = stack.Pop();
                    Console.WriteLine(" next-> "+s);
                    foreach(int i in adj[s])
                    {
                        if (!visited[i])
                        {
                            visited[i] = true;
                            stack.Push(i);
                        }
                    }
                }
             }

        public void PrintAdjacencyMatrix()
            {
                for(int i = 0; i < vertices; i++)
                {
                    Console.Write(i + " :[");
                    string s = " ";
                    foreach(var k in adj[i]){
                        s = s + (k + ",");
                    }
                    s = s.Substring(0, s.Length - 1);
                    s = s + "]";
                    Console.Write(s);
                    Console.WriteLine();
                }
            }
        [STAThread]
        public static void Main()
        {
                clsGraph graph = new clsGraph(4);
                graph.AddEdge(0, 1);
                graph.AddEdge(0, 2);
                graph.AddEdge(1, 2);
                graph.AddEdge(2, 0);
                graph.AddEdge(2, 3);
                graph.AddEdge(3, 3);
                //print adjacency matrix
                graph.PrintAdjacencyMatrix();
                Console.WriteLine("BFS traversal starting from vertext 2:");
                graph.BFS(2);
                Console.WriteLine("DFS traversal starting from verticx 2:");
                graph.DFS(2);

            }
        }
}
