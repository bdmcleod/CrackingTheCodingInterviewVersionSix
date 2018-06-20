using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterviewVersionSix.Recursion_problems
{
    public class RecursionQuestions
    {
        private RecursionLogic rec;

        public RecursionQuestions()
        {
            rec = new RecursionLogic();
        }
        public void FibWithMemoQuestion()
        {

            int intNum = -1;
            do
            {
                Console.Write("Please enter a positive number between 3 and 1000: ");
                var stringAnswer = Console.ReadLine();

                int.TryParse(stringAnswer, out intNum);

            } while (intNum < 0);

            int[] memo = new int[intNum + 1];
            RecursionLogic rec = new RecursionLogic();

            int answer = rec.Fib(intNum - 1, memo);
            Console.WriteLine(answer);

        }

        public void PrintFirstNNaturalNumbers()
        {
            int num = -1;


            while (num < 1)
            {
                Console.Write("Please enter a positive number 'n', and I'll print the first 'n' number of natural numbers: ");
                var numString = Console.ReadLine();

                if (!int.TryParse(numString, out num))
                {
                    num = -1;
                }
            }

            rec.PrintFirstNNaturalNumbers(num, 1);

            
        }

        public void PrintNumbersNTOneQuestion()
        {
            int num = -1;


            while (num < 1)
            {
                Console.Write("Please enter a positive number 'n', and I'll print the 'n' to 1: ");
                var numString = Console.ReadLine();

                if (!int.TryParse(numString, out num))
                {
                    num = -1;
                }
            }

            rec.PrintNumbersNToOne(num);
        }

        public void SumOfFirstNNaturalNumbersQuestion()
        {
            int num = -1;
            while (num < 1)
            {
                Console.Write("Please enter a positive number 'n', and I'll sum 1 through 'n': ");
                var numString = Console.ReadLine();

                if (!int.TryParse(numString, out num))
                {
                    num = -1;
                }
            }
            Console.WriteLine();
            Console.WriteLine("The sum is {0}.", rec.SumOfFirstNNaturalNumbers(num, 1, 0));

        }

        public void DisplayIndividualDigits()
        {
            bool loopExit = false;
            int num = 0;
            while (loopExit == false)
            {
                Console.Write("Please enter a number 'n' and I'll display the individual numbers of it:");
                var numString = Console.ReadLine();

                if (int.TryParse(numString, out num))
                {
                    loopExit = true;
                }
            }

            rec.DisplayIndividualDigits(num.ToString().ToCharArray(), 0);
        }

        public void IsPrimeRecursiveQuestion()
        {
            bool loopExit = false;
            int num = 0;
            while (loopExit == false)
            {
                Console.WriteLine("Please enter a number to see if it's prime: ");
                var stringNum = Console.ReadLine();

                if (int.TryParse(stringNum, out num))
                {
                    loopExit = true;
                }
            }

            if (num == 1)
            {
                Console.WriteLine("Number is prime.");
            }

            

            bool isPrime = rec.IsPrimeRecursive(num, 2);

            if (isPrime)
            {
                Console.WriteLine("Number is prime.");

            }
            else
            {
                Console.WriteLine("Number is not prime.");
            }
        }

        public void IsStringAPalindromeQuestion()
        {
            Console.Write("Please enter a string and I'll tell you if it's a palindrome: ");
            var source = Console.ReadLine();

            if (source.Length < 2)
            {
                Console.WriteLine(source + " is a palindrome.");
            }

            bool answer = rec.IsStringAPalindromeRecursive(source, 0, source.Length - 1);

            if (answer == false)
            {
                Console.WriteLine("This string is NOT a palindrome.");
            }
            else
            {
                Console.WriteLine("This string is a palindrome.");
            }
        }
    }
}
