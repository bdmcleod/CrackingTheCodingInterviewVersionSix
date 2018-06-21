using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterviewVersionSix.ChapterFour
{
    public class BinaryTree
    {
        public BinaryTreeNode root;
        private Queue<BinaryTreeNode> prevNodes;

        public BinaryTree(BinaryTreeNode r)
        {
            root = r;
            prevNodes = new Queue<BinaryTreeNode>();
            prevNodes.Enqueue(r);
        }

        public void AddChild(int data)
        {
            var newNode = new BinaryTreeNode(data);
            BinaryTreeNode lastNodeAdded = prevNodes.Peek();

            if (lastNodeAdded.leftChild == null)
            {
                lastNodeAdded.leftChild = newNode;
            }
            else
            {
                lastNodeAdded.rightChild = newNode;
                prevNodes.Dequeue();
            }

            prevNodes.Enqueue(newNode);

        }
    }

    public class BinaryTreeNode
    {
        public int data { get; set; }
        public BinaryTreeNode leftChild { get; set; }
        public BinaryTreeNode rightChild { get; set; }

        public BinaryTreeNode(int d)
        {
            this.data = d;
        }

    }


}
