using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterviewVersionSix.ChapterOne
{
    class ArraysAndStrings
    {
        public bool DoesStringContainAllUniqueCharacters(string source)
        {
            if (source.Length == 1)
                return true;

            var hash = new HashSet<char>();

            foreach (var letter in source)
            {
                if (hash.Contains(letter))
                {
                    return false;
                }

                hash.Add(letter);
            }

            return true;
        }

        public bool AreTwoStringsAnagrams(string stringOne, string stringTwo)
        {
            if (stringOne.Length != stringTwo.Length)
            {
                return false;
            }

            var dict = new Dictionary<char, int>();

            foreach (var letter in stringOne)
            {
                if (dict.ContainsKey(letter))
                {
                    dict[letter]++;
                }
                else
                {
                    dict[letter] = 1;
                }
            }

            foreach (var letter in stringTwo)
            {
                if (!dict.ContainsKey(letter))
                {
                    return false;
                }
                else
                {
                    dict[letter]--;
                }
            }

            foreach (var letter in dict.Keys)
            {
                if (dict[letter] != 0)
                {
                    return false;
                }
            }

            return true;
        }

        public string Urlify(string source)
        {
            var retString = source.Replace(" ", "%20");
            return retString;
        }

        public bool IsStringPalindromePermutation(string source)
        {
            var dict = new Dictionary<char, int>();

            //load all the letters into a dictionary
            foreach (var letter in source)
            {
                if (dict.ContainsKey(letter))
                {
                    dict[letter]++;
                }
                else
                {
                    dict[letter] = 1;
                }
            }

            bool haveSeenOdd = source.Length%2 == 0;

            foreach (var letters in dict.Keys)
            {
                if (dict[letters] % 2 == 0)
                {
                    continue;
                }
                else
                {
                    if (haveSeenOdd == true)
                    {
                        return false;
                    }
                    else
                    {
                        haveSeenOdd = true;
                    }
                }
            }

            return true;

        }

        public bool OneEditAway(string stringOne, string stringTwo)
        {
            var lengthDiff = stringOne.Length - stringTwo.Length;
            bool haveSeenEdit = false;

            if (lengthDiff > 1 || lengthDiff < -1)
            {
                return false;
            }

            int i;
            for (i=0; i < stringOne.Length; i++)
            {
                var checkHaveSeenEdit = false;
                if (i >= stringTwo.Length)
                {
                    checkHaveSeenEdit = true;
                }
                else if (stringTwo[i] != stringOne[i])
                {
                    checkHaveSeenEdit = true;
                }


                if (checkHaveSeenEdit)
                {
                    if (haveSeenEdit)
                    {
                        return false;
                    }
                    else
                    {
                        haveSeenEdit = true;
                    }
                }
            }

            if (i + 1 < stringTwo.Length)
            {
                if (haveSeenEdit)
                {
                    return false;
                }
            }

            return true;
        }

        public string StringCompression(string source)
        {
            if (source.Length == 1)
            {
                return source;
            }

            var priorLetter = source[0];
            int currentCount = 1;
            int newCount = 0;
            var sB = new StringBuilder();

            for (int i = 1; i < source.Length; i++)
            {
                if (source[i] == priorLetter)
                {
                    currentCount++;
                }
                else
                {
                    sB.Append(priorLetter);
                    sB.Append(currentCount);
                    priorLetter = source[i];
                    currentCount = 1;
                    newCount += 2;
                }

                if (newCount >= source.Length)
                {
                    return source;
                }
            }

            sB.Append(priorLetter);
            sB.Append(currentCount);
            newCount += 2;

            if (newCount >= source.Length)
            {
                return source;
            }
            else
            {
                return sB.ToString();

            }

        }

    }
}
