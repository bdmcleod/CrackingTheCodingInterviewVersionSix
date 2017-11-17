using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterviewVersionSix.ChapterThree
{
    class MyStackWithMin
    {
        private MyStack<int> minStack;
        private MyStack<int> myStack;

        public MyStackWithMin()
        {
            minStack = new MyStack<int>();
            myStack= new MyStack<int>();
        }

        public int Pop()
        {
            var data = myStack.Pop();

            if (minStack.Peek() == data)
            {
                minStack.Pop();
            }


            return data;
        }

        public void Push(int data)
        {
            if (myStack.IsEmpty())
            {
                myStack.Push(data);
                minStack.Push(data);
                return;
            }

            if (data < minStack.Peek())
            {
                minStack.Push(data);
            }

            myStack.Push(data);

        }

        public int GetMin()
        {
            return minStack.Peek();
        }
    }
}
