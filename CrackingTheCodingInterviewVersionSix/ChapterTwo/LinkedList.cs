using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterviewVersionSix.ChapterTwo
{
    class LinkedList
    {
        public Node DeleteNode(Node head, int d)
        {
            Node curr = head;

            if (curr.data == d)
            {
                return curr.next;
            }

            
            while (curr.next != null)
            {
                if (curr.next.data == d)
                {
                    if (curr.next.next == null)
                    {
                        curr.next = null;
                    }
                    else
                    {
                        curr.next = curr.next.next;
                    }
                    
                    return head;
                }
                curr = curr.next;
            }

            return head;
        }

        public Node RemoveDuplicatesFromAnUnsortedLinkedList(Node head)
        {
            
            if (head.next == null)
            {
                return head;
            }

            var hash = new HashSet<int>();
            var prev = head;
            var curr = head.next;
            hash.Add(prev.data);

            while (curr != null)
            {
                if (hash.Contains(curr.data))
                {   
                    prev.next = curr.next;
                }
                else
                {
                    hash.Add(curr.data);
                }
                
                prev = curr;
                curr = curr.next;
            }


            return head;
        }

        public Node RemoveDuplicatesFromUnsortedListNoBuffer(Node head)
        {
            if (head.next == null)
            {
                return head;
            }

            Node curr = head;
            Node prev = curr;
            curr = curr.next;
            Node runner = head;

            while (runner != null)
            {
                while (curr != null)
                {
                    if (runner.data == curr.data)
                    {
                        //remove
                        prev.next = curr.next;
                    }

                    prev = curr;
                    curr = curr.next;
                }
                runner = runner.next;
                curr = runner.next;
                prev = runner;
            }

            return head;
        }

        public bool IsLinkedListPalindrome(Node head)
        {
            var curr = head;
            var stack = new Stack<int>();

            while (curr != null)
            {
                stack.Push(curr.data);
                curr = curr.next;
            }

            curr = head;
            while (curr != null)
            {
                var popped = stack.Pop();
                if (curr.data != popped)
                {
                    return false;
                }

                curr = curr.next;
            }

            return true;
        }

        public Node IsThereALoop(Node head)
        {
            var curr = head;
            var hash = new HashSet<Node>();

            while (curr != null)
            {
                if (hash.Contains(curr))
                {
                    return curr;
                }
                else
                {
                    hash.Add(curr);
                }

                curr = curr.next;
            }

            return null;

        }

        public Node FindIntersection(Node head1, Node head2)
        {
            var hash = new HashSet<Node>();

            var curr = head1;

            while (curr != null)
            {
                hash.Add(curr);

                curr = curr.next;
            }

            curr = head2;

            while (curr != null)
            {
                if (hash.Contains(curr))
                {
                    return curr;
                }

                curr = curr.next;
            }

            return null;
        }

        public Node SumTwoLinkedLists(Node headOne, Node headTwo)
        {
            int totalOne = 0;
            int multiplier = 1;

            var curr = headOne;

            while (curr != null)
            {
                var tempTotal = multiplier * curr.data;
                totalOne += tempTotal;

                multiplier *= 10;
                curr = curr.next;
            }

            int totalTwo = 0;
            multiplier = 1;
            curr = headTwo;

            while (curr != null)
            {
                var tempTotal = multiplier * curr.data;
                totalTwo += tempTotal;

                multiplier *= 10;
                curr = curr.next;
            }

            int total = totalOne + totalTwo;
            Node endNode = null;

            //1474 -> 4741
            
            while (total >= 1)
            {
                int val = total % 10;

                if (endNode == null)
                {
                    endNode = new Node(val);
                }
                else
                {
                    endNode.AppendToTail(val);
                }
                
                total = total/10;
            }
            

            return endNode;
        }

        public void DeleteMiddleNode(Node nodeToDelete)
        {
            Node curr = nodeToDelete;
            Node prevNode = curr;

            while (curr.next != null)
            {
                curr.data = curr.next.data;

                curr = curr.next;

                if (curr.next == null)
                {
                    prevNode.next = null;
                    return;
                }
                else
                {
                    prevNode = prevNode.next;
                }
            }

            curr = null;

        }

        public Node ReturnKthToLastNode(Node head, int k)
        {
            var curr = head;

            int totalNodes = 0;

            while (curr != null)
            {
                totalNodes++;
                curr = curr.next;
            }

            if (k - totalNodes > 0)
            {
                return null;
            }

            var nodeToSend = totalNodes - k;
            curr = head;
            while (nodeToSend > 0)
            {
                curr = curr.next;
                nodeToSend--;
            }


            return curr;
        }
    }
}
