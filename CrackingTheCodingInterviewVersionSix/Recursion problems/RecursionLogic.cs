using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterviewVersionSix.Recursion_problems
{
    public class RecursionLogic
    {
        internal int Fib(int num, int[] memo)
        {
            if (num == 0)
            {
                return 0;
            }

            if (num <= 2)
            {
                return 1;
            }

            if(memo[num] == 0)
            {
                memo[num] = Fib(num - 1, memo) + Fib(num - 2, memo);
            }
            
            return memo[num];
        }

        public void PrintNumbersNToOne(int num)
        {
            Console.Write(num + " ");
            if (num > 0)
            {
                PrintNumbersNToOne(--num);
                
            }
            else
            {
                return;
            }

        }

        public void PrintFirstNNaturalNumbers(int target, int numToPrint)
        {
            Console.Write(numToPrint + " ");

            if (target != numToPrint)
            {
                PrintFirstNNaturalNumbers(target, ++numToPrint);
            }
            else
            {
                return;
            }
        }

        public int SumOfFirstNNaturalNumbers(int target, int numToPrint, int runningSum)
        {
            runningSum += numToPrint;

            if (numToPrint != target)
            {
                return (SumOfFirstNNaturalNumbers(target, ++numToPrint, runningSum));
            }
            else
            {
                return runningSum;
            }
            
            
        }

        internal void DisplayIndividualDigits(char[] num, int index)
        {
            Console.Write(num[index] + " ");

            if (index + 1 < num.Length) 
            {
                DisplayIndividualDigits(num, ++index);
            }
            else
            {
                return;
            }
        }

        internal bool IsPrimeRecursive(int num, int divisor)
        {
            if (Math.Sqrt(num) < divisor)
            {
                return true;
            }

            int mod = num % divisor;

            if (mod == 0)
            {
                return false;
            }
            else
            {
                return IsPrimeRecursive(num, divisor++);
            }

        }

        internal bool IsStringAPalindromeRecursive(string source, int left, int right)
        {
            if (left > right)
            {
                return true;
            }

            if (source[left] == source[right])
            {
                return IsStringAPalindromeRecursive(source, ++left, --right);
            }
            else
            {
                return false;
            }

        }
    }
}
