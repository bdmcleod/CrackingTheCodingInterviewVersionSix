using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterviewVersionSix.ChapterTwo
{
    class ChapterTwoQuestions
    {
        /// <summary>
        /// Remove duplicates from an unsorted linked list
        /// </summary>
        public void QuestionOne()
        {
            var head = new Node(1);
            head.AppendToTail(2);
            head.AppendToTail(3);
            head.AppendToTail(3);

            var head2 = new Node(1);
            head2.AppendToTail(2);
            head2.AppendToTail(3);
            head2.AppendToTail(4);
            head2.AppendToTail(4);
            head2.AppendToTail(5);
            head2.AppendToTail(6);

            var head3 = new Node(1);
            head3.AppendToTail(1);
            head3.AppendToTail(2);
            head3.AppendToTail(4);


            var ll =new LinkedList();
            //Console.WriteLine("Using a buffer");
            //PrintLinkedList(head);
            //PrintLinkedList(ll.RemoveDuplicatesFromAnUnsortedLinkedList(head));
            //PrintLinkedList(head2);
            //PrintLinkedList(ll.RemoveDuplicatesFromAnUnsortedLinkedList(head2));
            //PrintLinkedList(head3);
            //PrintLinkedList(ll.RemoveDuplicatesFromAnUnsortedLinkedList(head3));

            Console.WriteLine("Using No Buffer");
            PrintLinkedList(head);
            PrintLinkedList(ll.RemoveDuplicatesFromAnUnsortedLinkedList(head));
            PrintLinkedList(head2);
            PrintLinkedList(ll.RemoveDuplicatesFromAnUnsortedLinkedList(head2));
            PrintLinkedList(head3);
            PrintLinkedList(ll.RemoveDuplicatesFromAnUnsortedLinkedList(head3));


        }

        /// <summary>
        /// Implement a function to determine if a LinkedList is a palindrome
        /// </summary>
        public void QuestionSix()
        {
            var ll = new LinkedList();
            var head = new Node(1);
            head.AppendToTail(2);
            head.AppendToTail(3);
            head.AppendToTail(2);
            head.AppendToTail(1);

            var head2 = new Node(1);
            head2.AppendToTail(2);
            head2.AppendToTail(2);
            head2.AppendToTail(1);

            var head3 = new Node(1);
            head3.AppendToTail(2);
            head3.AppendToTail(3);
            head3.AppendToTail(2);
            head3.AppendToTail(4);

            Console.WriteLine("Is this a palindrome? ");
            PrintLinkedList(head);
            Console.WriteLine(ll.IsLinkedListPalindrome(head)? "Yes" : "No");

            Console.WriteLine("Is this a palindrome? ");
            PrintLinkedList(head2);
            Console.WriteLine(ll.IsLinkedListPalindrome(head2) ? "Yes" : "No");

            Console.WriteLine("Is this a palindrome? ");
            PrintLinkedList(head3);
            Console.WriteLine(ll.IsLinkedListPalindrome(head3) ? "Yes" : "No");

        }

        /// <summary>
        /// Determine if there's a cylce in a linked list. If there is, return the node at the start
        /// </summary>
        public void QuestionEight()
        {
            Node head = new Node(1);
            head.AppendToTail(2);
            head.AppendToTail(3);
            head.AppendToTail(4);
            Node newNode = new Node(10);
            newNode.next = head;
            newNode.AppendNodeToTail(head);


            var ll = new LinkedList();
            Console.Write("Is there a cycle? ");
            if (ll.IsThereALoop(newNode) == null)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine("Yes. It is: " + ll.IsThereALoop(newNode).data);
            }
        }

        /// <summary>
        /// Determine if two singly linked lists have an intersecting node, if so, return the node
        /// </summary>
        public void QuestionSeven()
        {
            Node head1 = new Node(1);
            head1.AppendToTail(2);
            head1.AppendToTail(3);
            head1.AppendToTail(4);

            Node newNode = new Node(10);

            head1.AppendNodeToTail(newNode);
            head1.AppendToTail(15);

            Node head2 = new Node(21);
            head2.AppendToTail(22);
            head2.AppendToTail(23);
            head2.AppendToTail(25);
            head2.AppendNodeToTail(newNode);
            head2.AppendToTail(35);
            head2.AppendToTail(40);

            PrintLinkedList(head1);
            PrintLinkedList(head2);

            var ll = new LinkedList();

            Console.WriteLine("The intersecting node in thes two linked lists is " + ll.FindIntersection(head1, head2).data);


        }

        /// <summary>
        /// Sum Two linked lists that are in reverse order. So the 1's digit is at the head.
        /// </summary>
        public void QuestionFive()
        {
            Node head1 = new Node(1);
            head1.AppendToTail(3);
            head1.AppendToTail(5);

            Node head2 = new Node(3);
            head2.AppendToTail(4);
            head2.AppendToTail(9);

            var ll = new LinkedList();

            PrintLinkedList(head1);
            PrintLinkedList(head2);

            var total = ll.SumTwoLinkedLists(head1, head2);
            PrintLinkedList(total);
        }

        /// <summary>
        /// Delete a node in the middle of a linked list given only access to that node.
        /// </summary>
        public void QuestionThree()
        {
            Node head = new Node(1);
            head.AppendToTail(2);
            head.AppendToTail(3);

            Node newNode = new Node(4);
            head.AppendNodeToTail(newNode);
            head.AppendToTail(5);

            var ll = new LinkedList();
            PrintLinkedList(head);
            ll.DeleteMiddleNode(newNode);
            PrintLinkedList(head);
        }

        /// <summary>
        /// Find the kth to last node of a singly linked list
        /// </summary>
        public void QuestionTwo()
        {
            Node head = new Node(1);
            head.AppendToTail(2);
            head.AppendToTail(3);
            head.AppendToTail(4);
            head.AppendToTail(5);

            var ll = new LinkedList();

            PrintLinkedList(head);
            Console.WriteLine(("The 2nd to last Node is " + ll.ReturnKthToLastNode(head, 2).data));
            Console.WriteLine(("The fifth to last Node is " + ll.ReturnKthToLastNode(head, 5).data));
            Console.WriteLine(("The 1st to last Node is " + ll.ReturnKthToLastNode(head, 1).data));



        }

        private void PrintLinkedList(Node head)
        {
            while (head != null)
            {
                Console.Write(head.data + " ");
                head = head.next;

            }

            Console.WriteLine();
        }
    }
}
