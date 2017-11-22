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
    }
}
