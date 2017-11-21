using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterviewVersionSix.ChapterThree
{
    class ChapterThreeQuestions
    {
        /// <summary>
        /// Use a single array to implement three stacks
        /// </summary>
        public void QuestionOne()
        {
            
        }

        /// <summary>
        /// Design a solution that also maintains a Stack Min at all times. It should return in 0(1) time
        /// </summary>
        public void QuestionTwo()
        {
            var stack = new MyStackWithMin();

            stack.Push(5);
            stack.Push(7);
            stack.Push(6);
            stack.Push(4);
            stack.Push(1);
            stack.Push(2);

            Console.WriteLine("We added 5 7 6 4 1 2 ");
            Console.WriteLine("No pops: " + stack.GetMin());
            stack.Pop();
            Console.WriteLine("1 pop: " + stack.GetMin());

            stack.Pop();
            Console.WriteLine("2 pop: " + stack.GetMin());

            stack.Pop();
            Console.WriteLine("3 pop: " + stack.GetMin());

            stack.Pop();
            Console.WriteLine("4 pop: " + stack.GetMin());

            stack.Pop();
            Console.WriteLine("5 pop: " + stack.GetMin());




        }

        /// <summary>
        /// Imagine if a stack gets too high it will topple. Implement a data structure that behaves like a stack, but limits the size of each stack.
        /// I arbitrarily chose 3 as the max height. 
        /// </summary>
        public void QuestionThree()
        {
            var stackSet = new SetOfStacks<int>();
            stackSet.Push(1);
            stackSet.Push(2);
            stackSet.Push(3);
            stackSet.Push(4);
            stackSet.Push(5);
            stackSet.Push(6);
            stackSet.Push(7);
            stackSet.Push(8);
            stackSet.Push(9);
            stackSet.Push(10);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(stackSet.Pop());
            }
            



        }
    }
}
