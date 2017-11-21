using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterviewVersionSix.ChapterThree
{
    public class MyStack<T>
    {

        private int _count;
        private StackNode<T> top;

        public T Pop()
        {

            var item = top.data;
            top = top.next;
            _count--;
            return item;
        }

        public MyStack()
        {
            _count = 0;
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
            _count++;

        }

        public bool IsEmpty()
        {
            return (top == null);
        }

        public int Count()
        {
            return _count;
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

    public class SetOfStacks<T>
    {
        private const int MAX_NUMBER = 3;
        private List<MyStack<T>> stacks;


        public SetOfStacks()
        {
            stacks = new List<MyStack<T>>();
            var stack = new MyStack<T>();
            stacks.Add(stack);
        }

        public void Push(T data)
        {
            if (stacks[stacks.Count - 1].Count() == MAX_NUMBER)
            {
                var newStack = new MyStack<T>();
                newStack.Push(data);
                stacks.Add(newStack);

            }
            else
            {
                stacks[stacks.Count - 1].Push(data);
            }
        }

        public T Pop()
        {
            if (stacks[stacks.Count-1].Count() == 0)
            {
                stacks.RemoveAt(stacks.Count - 1);
            }
            return (stacks[stacks.Count - 1].Pop());
        }
    }
}
