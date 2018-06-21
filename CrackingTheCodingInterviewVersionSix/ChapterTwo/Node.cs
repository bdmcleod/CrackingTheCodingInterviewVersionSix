using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterviewVersionSix.ChapterTwo
{
    public class Node
    {
        public int data;
        public Node next;

        public Node(int d)
        {
            this.data = d;
        }

        public void AppendToTail(int d)
        {
            Node curr = this;

            while (curr.next != null)
            {
                curr = curr.next;
            }

            curr.next = new Node(d);
        }

        public void AppendNodeToTail(Node n)
        {
            Node curr = this;


            while (curr.next != null)
            {
                curr = curr.next;

            }

            curr.next = n;
        }
    }
}
