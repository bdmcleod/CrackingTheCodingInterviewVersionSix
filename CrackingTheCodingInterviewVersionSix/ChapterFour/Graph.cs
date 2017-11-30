using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterviewVersionSix.ChapterFour
{
    public class Graph
    {
        public List<GraphNode> nodes;

        public bool IsThereAPathBothWays(Graph graph, GraphNode nodeOne, GraphNode nodeTwo)
        {
            if (IsThereAPath(graph, nodeOne, nodeTwo))
            {
                return true;
            }

            return (IsThereAPath(graph, nodeTwo, nodeOne));
        }

        public bool IsThereAPath(Graph graph, GraphNode nodeOne, GraphNode nodeTwo)
        {
            var q = new Queue<GraphNode>();
            nodeOne.visited = true;
            q.Enqueue(nodeOne);

            while (q.Count > 0)
            {
                var n = q.Dequeue();

                foreach (var c in n.children)
                {
                    if (c == nodeTwo)
                    {
                        return true;
                    }
                    else if (c.visited == false)
                    {
                        q.Enqueue(c);
                    }
                }

            }

            return false;

        }

        public TreeNode CreateMinimalTreeFromSortedArray(int[] array)
        {
            return CreateMinimalTree(array, 0, array.Length - 1);
        }

        public TreeNode CreateMinimalTree(int[] array, int start, int end)
        {
            if (start > end)
            {
                return null;
            }

            int mid = (start + end) / 2;

            var node = new TreeNode(array[mid])
            {
                leftChild = CreateMinimalTree(array, start, mid - 1),
                rightChild = CreateMinimalTree(array, mid + 1, end)
            };

            return node;
        }

    }

    public class GraphNode
    {
        public string name;
        public List<GraphNode> children;
        public bool visited = false;

        public GraphNode(string n)
        {
            name = n;
            visited = false;
            children = new List<GraphNode>();
        }

        public void SetChildren(List<GraphNode> c)
        {
            children = c;
        }

        public void AddChild(GraphNode c)
        {
            
            children.Add(c);
        }


    }

    
}
