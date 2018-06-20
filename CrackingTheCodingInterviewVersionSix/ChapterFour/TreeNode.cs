using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterviewVersionSix.ChapterFour
{
    public class TreeNode
    {
        public int data;
        public TreeNode leftChild;
        public TreeNode rightChild;

        public TreeNode(int d)
        {
            this.data = d;
        }

        internal void Add(int data)
        {
            if (this.data < data)
            {
                if (this.rightChild == null)
                {
                    this.rightChild = new TreeNode(data);
                }
                else
                {
                    rightChild.Add(data);
                }
            }
            else
            {
                if (this.leftChild == null)
                {
                    this.leftChild = new TreeNode(data);
                }
                else
                {
                    leftChild.Add(data);
                }
            }
        }
    }

    public class BinarySearchTree
    {
        public TreeNode root;

        public BinarySearchTree()
        {

        }

        public void Add(int data)
        {
            if (root == null)
            {
                root = new TreeNode(data);
                return;
            }

            root.Add(data);
        }

        public void PreOrderTraversal(TreeNode node)
        {
            if (node != null)
            {
                Visit(node);
                PreOrderTraversal(node.leftChild);
                PreOrderTraversal(node.rightChild);
            }

        }

        private void Visit(TreeNode root)
        {
            Console.Write(root.data + " ");
        }

        public void InOrderTraversal(TreeNode node)
        {
            if (node != null)
            {
                InOrderTraversal(node.leftChild);
                Visit(node);
                InOrderTraversal(node.rightChild);
            }

        }

        public void PostOrderTraversal(TreeNode node)
        {
            if (node != null)
            {
                PostOrderTraversal(node.leftChild);
                PostOrderTraversal(node.rightChild);
                Visit(node);
            }

        }

        public void PostOrderIterativeTraversal(TreeNode root)
        {
            var values = new List<TreeNode>();
            var stackNode = new Stack<TreeNode>();

            if (root != null)
            {
                stackNode.Push(root);
            }

            while (stackNode.Count > 0)
            {
                var top = stackNode.Pop();
                values.Add(top);

                if (top.leftChild != null)
                {
                    stackNode.Push(top.leftChild);
                }

                if (top.rightChild != null)
                {
                    stackNode.Push(top.rightChild);
                }
            }

            values.Reverse();

        }
    }
}
