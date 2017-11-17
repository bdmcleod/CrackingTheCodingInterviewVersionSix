using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterviewVersionSix.ChapterThree
{
    public class MyStack<T>
    {

        private StackNode<T> top;

        public T Pop()
        {
            var item = top.data;
            top = top.next;

            return item;
        }


        public T Peek()
        {
            return top.data;
        }

        public void Push(T item)
        {
            var newNode = new StackNode<T>(item);

            
            
            newNode.next = top;
            top = newNode;

        }

        public bool IsEmpty()
        {
            return (top == null);
        }

    }

    public class StackNode<T>
    {
        public T data;
        public StackNode<T> next;

        public StackNode(T data)
        {
            this.data = data;
        } 
    }
}
