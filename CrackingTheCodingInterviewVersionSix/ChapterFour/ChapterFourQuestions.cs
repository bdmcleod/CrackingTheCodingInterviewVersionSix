using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterviewVersionSix.ChapterFour
{
    class ChapterFourQuestions
    {
        public void BasicTraversal()
        {
            var bst = new BinarySearchTree();
            bst.Add(10);
            bst.Add(5);
            bst.Add(12);
            bst.Add(6);
            bst.Add(11);
            bst.Add(1);
            bst.Add(26);
            bst.Add(9);
            bst.Add(13);
            bst.Add(8);

            Console.Write("In-Order Traversal: ");
            bst.InOrderTraversal(bst.root);
            Console.WriteLine();

            Console.Write("Pre-Order Traversal: ");
            bst.PreOrderTraversal(bst.root);
            Console.WriteLine();

            Console.Write("Post-Order Traversal: ");
            bst.PostOrderTraversal(bst.root);
            Console.WriteLine();


        }

        /// <summary>
        /// Given a directed graph, design an algorithm to find out whether there is a route between two nodes
        /// </summary>
        public void QuestionOne()
        {
            var g = new Graph();

            var n1 = new GraphNode("A");
            var n2 = new GraphNode("B");
            var n3 = new GraphNode("C");
            var n4 = new GraphNode("D");
            var n5 = new GraphNode("E");
            var n6 = new GraphNode("F");
            var n7 = new GraphNode("G");
            var n8 = new GraphNode("H");


            n1.AddChild(n2);
            n1.AddChild(n3);
            n2.AddChild(n4);
            n5.AddChild(n6);
            n6.AddChild(n7);
            n6.AddChild(n8);
            n5.AddChild(n8);

            g.nodes = new List<GraphNode> { n1, n2, n3, n4, n5, n6, n7, n8 };

            Console.WriteLine(g.IsThereAPathBothWays(g, n1, n4)? "Yes" : "No");
            Console.WriteLine(g.IsThereAPathBothWays(g, n4, n1) ? "Yes" : "No");


            Console.WriteLine(g.IsThereAPathBothWays(g, n1, n5) ? "Yes" : "No");
            Console.WriteLine(g.IsThereAPathBothWays(g, n5, n1) ? "Yes" : "No");


            Console.WriteLine(g.IsThereAPathBothWays(g, n5, n8) ? "Yes" : "No");
            Console.WriteLine(g.IsThereAPathBothWays(g, n8, n5) ? "Yes" : "No");





        }

        /// <summary>
        /// 
        /// Given a binary sorted array with unique integer elements write an algorithm to createa  binary search tree with minimal height
        /// </summary>
        public void QuestionTwo()
        {
            int[] arr = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            Array.Sort(arr);

            var g = new Graph();
            var root = g.CreateMinimalTreeFromSortedArray(arr);
        }


    }
}
