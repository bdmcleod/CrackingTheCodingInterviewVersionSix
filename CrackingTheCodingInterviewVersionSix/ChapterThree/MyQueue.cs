using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterviewVersionSix.ChapterThree
{
    class MyQueue<T>
    {




    }

    public class QueueNode<T>
    {
        public T data;
        public QueueNode<T> next;

        public QueueNode(T data)
        {
            this.data = data;
        }

        private QueueNode<T> first;
        private QueueNode<T> last;

        public void Add(T item)
        {
            var newNode = new QueueNode<T>(item);

            if (last != null)
            {
                last.next = newNode;
            }
            last = newNode;

            if (first == null)
            {
                first = newNode;
            }
        }

        public T Remove()
        {
            if (first == null)
            {
                throw new Exception();
            }

            var data = first.data;

            first = first.next;

            if (first == null)
            {
                last = null;
            }

            return data;
        }

        public T Peek()
        {
            if (first == null)
            {
                throw new Exception();
            }

            return first.data;
        }

        public bool IsEmpty()
        {
            return first == null;
        } 
    }
}
