using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterviewVersionSix.ChapterOne
{
    class ChapterOneQuestions
    {
        /// <summary>
        /// Determine if a string contains all unique characters
        /// </summary>
        public void QuestionOne()
        {
            string s1 = "abcdefgh";
            string s2 = "aabcdefg";
            string s3 = "abcdefgg";
            string s4 = "abbcdefgh";
            string s5 = "a";

            var aas = new ArraysAndStrings();

            Console.WriteLine("Is " + s1 + " unique? " + (aas.DoesStringContainAllUniqueCharacters(s1) ? "Yes" : "No"));
            Console.WriteLine("Is " + s2 + " unique? " + (aas.DoesStringContainAllUniqueCharacters(s2) ? "Yes" : "No"));
            Console.WriteLine("Is " + s3 + " unique? " + (aas.DoesStringContainAllUniqueCharacters(s3) ? "Yes" : "No"));
            Console.WriteLine("Is " + s4 + " unique? " + (aas.DoesStringContainAllUniqueCharacters(s4) ? "Yes" : "No"));
            Console.WriteLine("Is " + s5 + " unique? " + (aas.DoesStringContainAllUniqueCharacters(s5) ? "Yes" : "No"));



        }
        /// <summary>
        /// Are two strings anagrams?
        /// </summary>
        public void QuestionTwo()
        {
            string s1 = "star";
            string s2 = "rats";
            string s3 = "rates";
            string s4 = "stare";
            string s5 = "Baseball";
            string s6 = "is fun";

            var aas = new ArraysAndStrings();

            Console.WriteLine("Are {0} and {1} anagrams? ", s1, s2);
            Console.Write(aas.AreTwoStringsAnagrams(s1, s2)? "Yes": "No");

            Console.WriteLine();

            Console.WriteLine("Are {0} and {1} anagrams? ", s1, s3);
            Console.Write(aas.AreTwoStringsAnagrams(s1, s3) ? "Yes" : "No");

            Console.WriteLine();

            Console.WriteLine("Are {0} and {1} anagrams? ", s1, s4);
            Console.Write(aas.AreTwoStringsAnagrams(s1, s4) ? "Yes" : "No");

            Console.WriteLine();

            Console.WriteLine("Are {0} and {1} anagrams? ", s3, s4);
            Console.Write(aas.AreTwoStringsAnagrams(s3, s4) ? "Yes" : "No");
            Console.WriteLine();

            Console.WriteLine("Are {0} and {1} anagrams? ", s5, s6);
            Console.Write(aas.AreTwoStringsAnagrams(s5, s6) ? "Yes" : "No");

            Console.WriteLine();

            Console.WriteLine("Are {0} and {1} anagrams? ", s1, s6);
            Console.Write(aas.AreTwoStringsAnagrams(s1, s6) ? "Yes" : "No");

        }

        /// <summary>
        /// Write a method to replace all spaces with %20
        /// </summary>
        public void QuestionThree()
        {
            var aas = new ArraysAndStrings();

            var s1 = "John Smith";
            var s2 = "John Smith the Programmer";

            var s3 = " Space in front";
            var s4 = "Space at end ";

            Console.WriteLine("\"" +  s1 + "\" becomes " + aas.Urlify(s1));
            Console.WriteLine("\"" + s2 + "\" becomes " + aas.Urlify(s2));
            Console.WriteLine("\"" + s3 + "\" becomes " + aas.Urlify(s3));
            Console.WriteLine("\"" + s4 + "\" becomes " + aas.Urlify(s4));



        }

        /// <summary>
        /// Is a string a permutation of a palindrome
        /// </summary>
        public void QuestionFour()
        {
            var s1 = "TacocaT";
            var s2 = "racecar";
            var s3 = "odd";
            var s4 = "odds";
            var s5 = "racecars";
            var s6 = "lewd did I live,evil I did dwel";
            var s7 = "pizza";
            var aas = new ArraysAndStrings();

            Console.WriteLine("Is {0} a permutation of a palindrome? " + (aas.IsStringPalindromePermutation(s1)? "Yes" : "No"), s1 );
            Console.WriteLine("Is {0} a permutation of a palindrome? " + (aas.IsStringPalindromePermutation(s2) ? "Yes" : "No"), s2);
            Console.WriteLine("Is {0} a permutation of a palindrome? " + (aas.IsStringPalindromePermutation(s3) ? "Yes" : "No"), s3);
            Console.WriteLine("Is {0} a permutation of a palindrome? " + (aas.IsStringPalindromePermutation(s4) ? "Yes" : "No"), s4);
            Console.WriteLine("Is {0} a permutation of a palindrome? " + (aas.IsStringPalindromePermutation(s5) ? "Yes" : "No"), s5);
            Console.WriteLine("Is {0} a permutation of a palindrome? " + (aas.IsStringPalindromePermutation(s6) ? "Yes" : "No"), s6);
            Console.WriteLine("Is {0} a permutation of a palindrome? " + (aas.IsStringPalindromePermutation(s7) ? "Yes" : "No"), s7);

        }

        /// <summary>
        /// Are two strings one edit away? That edit could be add, remove, or change a letter.
        /// </summary>
        public void QuestionFive()
        {
            var aas = new ArraysAndStrings();

            var s1 = "cars";
            var s2 = "care";
            var s3 = "Car";
            var s4 = "Cars";
            var s5 = "bar";
            var s6 = "bad";
            var s7 = "rad";
            
            Console.WriteLine("Is {0} one edit away from {1}? " + (aas.OneEditAway(s1, s2)? "Yes" : "No"), s1, s2);
            Console.WriteLine("Is {0} one edit away from {1}? " + (aas.OneEditAway(s1, s3) ? "Yes" : "No"), s1, s3);
            Console.WriteLine("Is {0} one edit away from {1}? " + (aas.OneEditAway(s1, s4) ? "Yes" : "No"), s1, s4);
            Console.WriteLine("Is {0} one edit away from {1}? " + (aas.OneEditAway(s3, s4) ? "Yes" : "No"), s3, s4);
            Console.WriteLine("Is {0} one edit away from {1}? " + (aas.OneEditAway(s1, s5) ? "Yes" : "No"), s1, s5);
            Console.WriteLine("Is {0} one edit away from {1}? " + (aas.OneEditAway(s5, s6) ? "Yes" : "No"), s5, s6);
            Console.WriteLine("Is {0} one edit away from {1}? " + (aas.OneEditAway(s4, s3) ? "Yes" : "No"), s4, s3);
            Console.WriteLine("Is {0} one edit away from {1}? " + (aas.OneEditAway(s5, s7) ? "Yes" : "No"), s5, s7);
        }

        /// <summary>
        /// Perform basic string compression using counts of repeated characters. If the compressed string is not smaller than the original, return the original.
        /// </summary>
        public void QuestionSix()
        {
            var s1 = "aaabcccc";
            var s2 = "abcccddeee";
            var s3 = "abcde444444444444444";
            var s4 = "aabbccdd";
            var s5 = "abbbbcc";

            var aas = new ArraysAndStrings();

            Console.WriteLine("The string compression for {0} is " + aas.StringCompression(s1), s1);
            Console.WriteLine("The string compression for {0} is " + aas.StringCompression(s2), s2);
            Console.WriteLine("The string compression for {0} is " + aas.StringCompression(s3), s3);
            Console.WriteLine("The string compression for {0} is " + aas.StringCompression(s4), s4);
            Console.WriteLine("The string compression for {0} is " + aas.StringCompression(s5), s5);

        }


    }
}
