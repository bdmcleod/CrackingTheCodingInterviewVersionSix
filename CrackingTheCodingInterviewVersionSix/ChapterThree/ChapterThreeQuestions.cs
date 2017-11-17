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
    }
}
