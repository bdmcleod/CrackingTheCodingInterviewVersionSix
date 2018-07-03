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
            if (stringOne == null && stringTwo == null)
                return false;
            if (stringOne == null)
                return (stringTwo.Length == 1);
            if (stringTwo == null)
                return (stringOne.Length == 1);

            var lengthDiff = stringOne.Length - stringTwo.Length;
            
            if (lengthDiff > 1 || lengthDiff < -1)
            {
                return false;
            }

            int i = 0;
            int j = 0;
            int editDistance = 0;

            while ( i < stringOne.Length && j < stringTwo.Length)
            {
                if (stringOne[i] != stringTwo[j])
                {
                    if (++editDistance > 1)
                        return false;

                    if (stringOne. Length < stringTwo.Length)
                    {
                        j++;
                        continue;
                    }
                    else if (stringTwo.Length < stringOne.Length)
                    {
                        i++;
                        continue;
                    }
                }
                i++;
                j++;
            }

            editDistance += stringOne.Length - i;
            editDistance += stringTwo.Length - j;

            return (editDistance == 1);

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

        public void DFS(char[,] grid, int row, int col)
        {
            int newRow = grid.GetLength(0);
            int newCol = grid.GetLength(1);

            //check to see if we're out of bounds or if the current record is 0
            if (row < 0 || col < 0 || row >= newRow || col >= newCol || grid[row,col] == 0)
                return;

            grid[row,col] = '0';
            DFS(grid, row - 1, col);
            DFS(grid, row + 1, col);
            DFS(grid, row, col - 1);
            DFS(grid, row, col + 1);

        }

        public int NumIslands(char[,] grid)
        {
            if (grid.Length == 0)
                return 0;

            int total = 0;

            int numRow = grid.GetLength(0);
            int numCol = grid.GetLength(1);

            for (int r = 0; r < numRow; r++)
            {
                for (int c = 0; c < numCol; c++)
                {
                    if (grid[r,c] == '1')
                    {
                        total++;
                        DFS(grid, r, c);
                    }
                }
            }
            return total;
        }

    }
}
