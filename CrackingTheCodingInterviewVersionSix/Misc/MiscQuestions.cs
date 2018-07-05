using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrackingTheCodingInterviewVersionSix.ChapterTwo;
using CrackingTheCodingInterviewVersionSix.ChapterFour;

namespace CrackingTheCodingInterviewVersionSix.Misc
{
    public class MiscQuestions
    {
        public void AddTwoBinaryNumbersQuestion()
        {
            Console.Write("Please enter a binary string: ");
            var binaryOne = Console.ReadLine();

            Console.Write("Please enter another binary string: ");
            var binaryTwo = Console.ReadLine();

            var result = SumTwoBinaryNumbers(binaryOne, binaryTwo);
            Console.WriteLine("Decimal value is " + result);

        }
        /// <summary>
        /// Given a pointer to the head of a singly linked list, iterate it backwards printing the values in reverse. Give 2 implementations - a recursive one, and an iterative one.  
        /// </summary>
        public void IterateThroughASinglyLinkedListQuestion()
        {
            Node head = new Node(1);
            head.AppendToTail(2);
            head.AppendToTail(3);
            head.AppendToTail(4);
            head.AppendToTail(5);

            IterativelyWalkThroughLinkedListFromHead(head);
            RecursivelyWalkThroughLinkedListFromHead(head);
        }

        /// <summary>
        /// Prints a linked list in reverse, recursive
        /// </summary>
        /// <param name="head"></param>
        private void RecursivelyWalkThroughLinkedListFromHead(Node head)
        {
            if (head == null)
            {
                return;
            }
            else {
                RecursivelyWalkThroughLinkedListFromHead(head.next);
            }

            Console.Write(head.data + " ");

        }

        /// <summary>
        /// Prints a linked list in reverse, iterative
        /// </summary>
        /// <param name="head"></param>
        private void IterativelyWalkThroughLinkedListFromHead(Node head)
        {
            var nodeStack = new Stack<Node>();

            while (head != null)
            {
                nodeStack.Push(head);
                head = head.next;

            }

            while (nodeStack.Count > 0)
            {
                Console.Write(nodeStack.Peek().data + " ");
                nodeStack.Pop();
            }
        }

        public void ReverseAnArrayWithoutAffectingSpecialCharsQuestion()
        {
            string s1 = "abcdefg";
            string s2 = "!abcdefg#";
            string s3 = "abcd$efg";

            Console.Write("First string to reverse is {0}: ", s1);
            ReverseStringMaintainSpecChars(s1.ToCharArray());
            Console.WriteLine();
            Console.Write("Second string to reverse is {0}: ", s2);
            ReverseStringMaintainSpecChars(s2.ToCharArray());
            Console.WriteLine();
            Console.Write("Third string to reverse is {0}: ", s3);
            ReverseStringMaintainSpecChars(s3.ToCharArray());
            Console.WriteLine();


        }

        private void ReverseStringMaintainSpecChars(char[] s1)
        {
            int left = 0;
            int right = s1.Length - 1;

            while (left < right)
            {
                if (!char.IsLetterOrDigit(s1[left]))
                {
                    left++;
                }
                else if (!char.IsLetter(s1[right]))
                {
                    right--;
                }
                else
                {
                    char temp = s1[left];
                    s1[left] = s1[right];
                    s1[right] = temp;
                    left++;
                    right--;
                }
            }
            
            foreach (var letter in s1)
            {
                Console.Write(letter);
            }
        }

        public void CountTripletsWithSumSmallerInArray()
        {
            int[] arr = { 5, 1, 3, 4, 7 };

            Console.WriteLine("Starting array = \"5, 1, 3, 4, 7\"");
            int sum = 12;
            int answer = CountTriplesLessThanSumInArray(arr, sum);

            Console.WriteLine("Answer: " + answer);

        }

        public void AddBinaryQuestion()
        {
            string input = "";
            string input2 = "";

            while (input != "-1")
            {
                Console.Write("Please enter the first binary number: ");
                input = Console.ReadLine();

                Console.Write("Please enter the 2nd binary number: ");
                input2 = Console.ReadLine();

                var a = AddBinary(input, input2);
                Console.WriteLine(a);
            }
        }

        public string AddBinary(string a, string b)
        {

            bool carry = false;
            char[] arr = new char[Math.Max(a.Length, b.Length) + 1];

            string longer = String.Empty;
            string shorter = String.Empty;
            if (a.Length < b.Length)
            {
                a = a.PadLeft(b.Length, '0');
            }
            else
            {
                b = b.PadLeft(a.Length, '0');
            }

            for (int i = a.Length - 1; i >= 0; i--)
            {
                char l = (a[i] == b[i] ? '0' : '1');

                if (l == '1' && carry == true)
                {
                    l = '0';
                }
                else if (l == '0' && carry == true)
                {
                    l = '1';
                    carry = false;
                }
                else if (a[i] == '1' && b[i] == '1')
                {
                    carry = true;
                }
                else
                {
                    carry = false;
                }

                arr[i+1] = l;
            }

            if (carry)
            {
                arr[0] = '1';
            }

            return new string(arr);
        }

        private int CountTriplesLessThanSumInArray(int[] array, int sum)
        {
            int total = 0;
            for (int i =0; i < array.Length-2; i++)
            {
                for (int j=i+1; j < array.Length-1; j++)
                {
                    for (int k = j+1; k < array.Length; k++)
                    {
                        var currTotal = array[i] + array[j] + array[k];
                        if (currTotal < sum)
                        {
                            total++;
                        }
                    }
                }
            }

            return total;
        }

        public int SumTwoBinaryNumbers(string numOne, string numTwo)
        {
            int multiplier = 1;
            int total = 0;

            for (int i=numTwo.Length-1; i >=0; i--)
            {
                if (numTwo[i] != '0' && numTwo[i] != '1')
                {
                    throw new ArgumentException();
                }

                total = total + (multiplier * (int)(numTwo[i]-'0'));
                multiplier *= 2;   
            }

            multiplier = 1;

            for (int i=numOne.Length-1; i>= 0; i--)
            {
                if (numOne[i] != '0' && numOne[i] != '1')
                {
                    throw new ArgumentException();
                }

                total = total + (multiplier * (int)(numOne[i]-'0'));
                multiplier *= 2;
            }

            return total;
        }

        /// <summary>
        /// 
        /// Given an unsorted array which has a number in the majority (a number appears more than 50% in the array), find that number
        /// </summary>
        public void FindMajorityNumberInUnsortedArray()
        {
            int[] arr = new int[] { 1, 2, 3, 1, 2, 1, 1 };
            Console.Write("Given this array, produce the majority element '(1, 2, 3, 1, 2, 1, 1)': ");
            int? answer = FindMajorityElement(arr);
            if (answer == null)
            {
                Console.Write("None exist");
            }
            else
            {
                Console.Write(answer);
            }
            
            Console.WriteLine();



        }

        private int? FindMajorityElement(int[] arr)
        {
            var dict = new Dictionary<int, int>();
            foreach (var value in arr)
            {
                if (dict.ContainsKey(value))
                {
                    dict[value]++;
                }
                else
                {
                    dict[value] = 1;
                }
            }

            int goal = (arr.Length / 2) + 1;
            

            foreach(var element in dict.Keys)
            {
                if (dict[element] >= goal)
                {
                    return element;
                }
            }

            return null;
        }

        public void MergeTwoSortedLinkedLists()
        {
            Node n1 = new Node(1);
            n1.AppendToTail(3);
            n1.AppendToTail(6);

            Node n2 = new Node(2);
            n2.AppendToTail(4);
            n2.AppendToTail(5);
            n2.AppendToTail(6);

            Node result = MergeTwoSortedLinkedLists(n1, n2);

            Node curr = result;
            while (curr != null)
            {
                Console.Write(curr.data + " ");
                curr = curr.next;
            }

        }

        private Node MergeTwoSortedLinkedLists(Node n1, Node n2)
        {
            Node Node1Head = n1;
            Node Node2Head = n2;
            Node newListHead = null;
            

            if (Node2Head.data < Node1Head.data)
            {
                newListHead = Node2Head;
                Node2Head = Node2Head.next;
            }
            else
            {
                newListHead = Node1Head;
                Node1Head = Node1Head.next;
            }

            Node curr = newListHead;

            while (true)
            {
                if (Node1Head == null && Node2Head == null)
                {
                    return newListHead;
                }
                else if (Node1Head == null)
                {
                    curr.next = Node2Head;
                    Node2Head = Node2Head.next;
                    
                }
                else if (Node2Head == null)
                {
                    curr.next = Node1Head;
                    Node1Head = Node1Head.next;
                    
                }
                else if (Node1Head.data < Node2Head.data)
                {
                    curr.next = Node1Head;
                    Node1Head = Node1Head.next;
                }
                else
                {
                    curr.next = Node2Head;
                    Node2Head = Node2Head.next;
                }

                curr = curr.next;
            }
        }

        /// <summary>
        /// How to find the 3rd element from end, in a singly linked list, in a single pass? (Solution)
        /// </summary>
        public void FindThirdFromLastNodeInLinkedListInOnePass()
        {
            Node n1 = new Node(1);
            n1.AppendToTail(2);

            PrintLinkedList(n1);
            PrintThirdFromLastNode(n1);

            n1.AppendToTail(3);
            n1.AppendToTail(4);

            PrintLinkedList(n1);
            PrintThirdFromLastNode(n1);

            n1.AppendToTail(5);
            n1.AppendToTail(6);

            PrintLinkedList(n1);
            PrintThirdFromLastNode(n1);

        }

        private void PrintThirdFromLastNode(Node n1)
        {
            Node head = n1;
            Node curr = n1;

            for (int i =0; i < 3; i++)
            {
                if (curr == null)
                {
                    Console.WriteLine("There's less than 3 nodes in the list.");
                    return;
                }
                else
                {
                    curr = curr.next;
                }
            }

            while (curr != null)
            {
                curr = curr.next;
                head = head.next;
            }

            Console.WriteLine("The third to last node is " + head.data);
            return;
        }

        private void PrintLinkedList(Node n1)
        {
            while (n1 != null)
            {
                Console.Write(n1.data + " ");
                n1 = n1.next;
            }
            Console.WriteLine();
            return;
        }

        public void GetLongestSubstring()
        {
            string input = "";

            while (input != "-1")
            {
                Console.Write("Please enter a string to get the longest substring: ");
                input = Console.ReadLine();

                

                if (input != "-1")
                {
                    int count = LengthOfLongestSubstring(input);
                    Console.WriteLine(count);
                }
            }

        }

        public int LengthOfLongestSubstringOld(string s)
        {
            int runningTotal = 0;
            int index = 0;
            var hashSet = new HashSet<char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (hashSet.Contains(s[i]))
                {
                    if (runningTotal < hashSet.Count)
                    {
                        runningTotal = hashSet.Count;
                    }
                    index++;
                    i = index;
                    i--;
                    hashSet = new HashSet<char>();

                }
                else
                {
                    hashSet.Add(s[i]);
                }
            }

            if (hashSet.Count > runningTotal)
            {
                runningTotal = hashSet.Count;
            }

            return runningTotal;
        }

        public void ReverseIntegerQuestion()
        {
            string input = "";

            while (input != "-1")
            {
                Console.Write("Please enter an integer to reverse it: ");
                input = Console.ReadLine();

                if (input != "-1")
                {
                    int count = Reverse(int.Parse(input));
                    Console.WriteLine(count);
                }
            }
        }

        public void MyAtoiQuestion()
        {
            string input = "";

            while (input != "-1")
            {
                Console.Write("Please enter an integer to ATOI it: ");
                input = Console.ReadLine();

                if (input != "-1")
                {
                    var ans = MyAtoi(input);
                    Console.WriteLine(ans);
                }
            }
        }

        public int Reverse(int x)
        {
            bool isNeg = (x < 0);
            char[] arr;

            if (isNeg)
            {
                arr = x.ToString().Substring(1).ToCharArray();
            }
            else
            {
                arr = x.ToString().ToCharArray();
            }

            Array.Reverse(arr);

            int result = 0;
            try
            {
                checked
                {
                    result = int.Parse(new string(arr));
                    if (isNeg)
                        result *= -1;
                }
            }
            catch (OverflowException ex)
            {
                return 0;
            }

            return result;
        }

        public int MyAtoi(string str)
        {
            str = str.Trim();
            var sb = new StringBuilder();
            bool isNeg = false;
            bool haveSeenOperand = false;

            foreach (var letter in str)
            {
                if (sb.Length == 0 && (letter == '-' || letter == '+'))
                {
                    if (haveSeenOperand)
                    {
                        return 0;
                    }
                    haveSeenOperand = true;
                    if (letter == '-')
                    {
                        
                        isNeg = true;
                    }
                }
                else if (char.IsNumber(letter))
                {
                    sb.Append(letter);
                }
                else
                {
                    break;
                }
            }
            try
            {
                if (sb.Length == 0)
                {
                    return 0;
                }

                var val = int.Parse(sb.ToString());
                if (isNeg)
                {
                    return (-1 * val);
                }
                else
                {
                    return val;
                } 
            }  
            catch (OverflowException ex)
            {
                if (isNeg)
                {
                    return int.MinValue;
                }
                else
                {
                    return int.MaxValue;
                }
            }

            return 0;
        }

        public int[] TwoSum(int[] nums, int target)
        {
            //key is the target value, value is the index where we found it
            var dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    return new int[] { dict[nums[i]], i };
                }
                else if (!dict.ContainsKey(target - nums[i]))
                {
                    dict.Add(target - nums[i], i);
                }
            }

            return new int[] { -1, -1 };
        }

        public void TwoSumQuestion()
        {
            var arr = new int[] { 2, 7, 11, 15 };

            var result = TwoSum(arr, 9);

            foreach (var ans in result )
            {
                Console.WriteLine(ans);
            }
        }

        public int RomanToInt(string s)
        {
            int total = 0;
            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case 'I':
                        total += 1;
                        break;
                    case 'V':
                        total += 5;
                        break;
                    case 'X':
                        total += 10;
                        break;
                    case 'L':
                        total += 50;
                        break;
                    case 'C':
                        total += 100;
                        break;
                    case 'D':
                        total += 500;
                        break;
                    case 'M':
                        total += 1000;
                        break;
                    default:
                        return 0;
                        break;
                }
            }

             for (int i=0; i < s.Length-1; i++)
             {
                switch (s[i])
                {
                    case 'I':
                        if (s[i+1] == 'V' || s[i + 1] == 'X')
                        {
                            total -= 2;
                        }
                        break;
                    case 'X':
                        if (s[i + 1] == 'L' || s[i + 1] == 'C')
                        {
                            total -= 20;
                        }
                        break;
                    case 'C':
                        if (s[i + 1] == 'D' || s[i + 1] == 'M')
                        {
                            total -= 200;
                        }
                        break;
                    default:
                        break;
                }
             }

            return total;

        }

        public void RomanToIntQuestion()
        {
            string input = "";

            while (input != "-1")
            {
                Console.Write("Please enter an integer to get the Roman Numeral: ");
                input = Console.ReadLine();

                if (input != "-1")
                {
                    var ans = RomanToInt(input);
                    Console.WriteLine(ans);
                }
            }
        }

        public int HammingDistance(int x, int y)
        {
            string num1 = Convert.ToString(x, 2).PadLeft(8, '0');
            string num2 = Convert.ToString(y, 2).PadLeft(8, '0');

            int runningTotal = 0;

            for (int i =0; i < num1.Length; i++)
            {
                if (num1[i] != num2[i])
                {
                    runningTotal++;
                }
            }

            return runningTotal;
        }

        public void HammingDistanceQuestion()
        {
            string input = "";
            string input2 = "";

            while (input != "-1")
            {
                Console.Write("Please enter two numbers to get the Hamming Distance: ");
                input = Console.ReadLine();
                input2 = Console.ReadLine();

                if (input != "-1")
                {
                    var ans = HammingDistance(int.Parse(input), int.Parse(input2));
                    Console.WriteLine(ans);
                }
            }
        }

        public Node ReverseList(Node head)
        {
            var stack = new Stack<Node>();

            var curr = head;

            while (curr != null)
            {
                stack.Push(curr);
                curr = curr.next;
            }

            Node newHead = null;
            curr = null;

            if (stack.Count > 0)
            {
                curr = stack.Pop();
                newHead = curr;
            }

            while (stack.Count > 0)
            {

                curr.next = stack.Pop();
                curr = curr.next;

            }

            return newHead;
        }

        public Node ReverseLinkedListIterativeNoStack(Node head)
        {
            if (head == null)
                return null;

            Node newHead = null;
            var curr = head;

            while (curr != null)
            {
                var temp = curr.next;
                curr.next = newHead;
                newHead = curr;

                curr = temp;
            }

            return newHead;
        }

        /// <summary>
        /// Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.
        /// 
        /// </summary>
        public void IsPalindromeQuestion()
        {
            var testText = "A man, a plan, a canal: Panama";
            if (IsPalindromeIgnoreCase(testText))
            {
                Console.WriteLine("true");
            }
            else{
                Console.WriteLine("false");
            }
        }

        public bool IsPalindromeIgnoreCase(string s)
        {
            var lower = s.ToLower();
            var sb = new StringBuilder();
            

            foreach (var letter in lower)
            {
                if (Char.IsLetterOrDigit(letter))
                {
                    sb.Append(letter);
                }
                    
            }

            var trimmedString = sb.ToString();

            for (int i=0, j= trimmedString.Length-1; i < j; i++, j--)
            {
                if (trimmedString[i] != trimmedString[j])
                {
                    return false;
                }
            }

            return true;
        }

        public IList<IList<int>> Subsets(int[] nums)
        {
            //list to return
            var allSubsets  = new List<IList<int>>();

            //empty set
            allSubsets.Add(new List<int>());


            for (int i =0; i < nums.Length; i++)
            {
                var newSubsets = new List<IList<int>>();
                for (int j =0; j < allSubsets.Count; j++)
                {
                    var curr = new List<int>(allSubsets[j]);
                    curr.Add(nums[i]);
                    newSubsets.Add(curr);
                }

                for (int j=0; j < newSubsets.Count; j++)
                {
                    allSubsets.Add(newSubsets[j]);
                }
            }

            return allSubsets;
        }

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
            {
                return null;
            }

            if (root == p || root == q)
            {
                return root;
            }

            var left = LowestCommonAncestor(root.leftChild, p, q);
            var right = LowestCommonAncestor(root.rightChild, p, q);

            if (left != null && right != null)
            {
                return root;
            }

            return left ?? right;
        }

        /// <summary>
        /// Given a string S, we can transform every letter individually to be lowercase or uppercase to create another string.  Return a list of all possible strings we could create.
        /// Examples:
        //        Input: S = "a1b2"
        //Output: ["a1b2", "a1B2", "A1b2", "A1B2"]

        //        Input: S = "3z4"
        //Output: ["3z4", "3Z4"]

        //        Input: S = "12345"
        //Output: ["12345"]
        /// </summary>
        public void LetterCasePermutationQuestion()
        {
            var input = "a1b2";

            var result = LetterCasePermutation(input);
        }

        public static IList<string> LetterCasePermutation(string S)
        {
            if (string.IsNullOrEmpty(S))
            {
                return new List<string>() { string.Empty };
            }
                
            var list = new List<string>();
            list.Add(S);
            Permutation(S.ToCharArray(), 0, list);
            return list;
        }

        public static void Permutation(char[] s, int i, List<string> list)
        {
            if (i == s.Length) return;
            if (char.IsLetter(s[i]))
            {
                var temp = s[i];
                Permutation(s, i + 1, list);
                s[i] = char.IsLower(s[i]) ? char.ToUpper(s[i]) : char.ToLower(s[i]);
                Permutation(s, i + 1, list);
                list.Add(new string(s));
                s[i] = temp;
            }
            else Permutation(s, i + 1, list);
        }

        public Node ReverseListRecursive(Node head)
        {
            return SwapNext(null, head);
        }

        private Node SwapNext(Node current, Node next)
        {
            if (next == null)
                return current;

            Node nextNext = next.next;
            next.next = current;
            return SwapNext(next, nextNext);
        }

        public void ReverseLLRecursiveQuestion()
        {
            Node n = new Node(1);
            n.AppendToTail(2);
            n.AppendToTail(3);
            n.AppendToTail(4);
            n.AppendToTail(5);


            var r = ReverseLinkedListIterativeNoStack(n);

            while (r!= null)
            {
                Console.Write(r.data + " ");
                r = r.next;
            }
        }

        public void MakePermutation(char[] arr, int start, int end)
        {
            if (start == end)
            {
                Console.Write(arr);
                Console.WriteLine();
            }
            else
            {
                for (int i=start; i <= end; i++)
                {
                    Swap(ref arr[start], ref arr[i]);
                    MakePermutation(arr, start + 1, end);
                    Swap(ref arr[start], ref arr[i]);

                }
            }

        }

        private void Swap(ref char a, ref char b)
        {
            if (a == b)
                    return;

            a ^= b;
            b ^= a;
            a ^= b;
        }

        public void PermQuestion()
        {
            string input = "";

            while (input != "-1")
            {
                Console.Write("Please enter a string to get all the permutations: ");
                input = Console.ReadLine();

                if (input != "-1")
                {
                    MakePermutation(input.ToCharArray(), 0, input.Length - 1);
                    
                }
            }
        }

        /// <summary>
        /// Given two sorted integer arrays nums1 and nums2, merge nums2 into nums1 as one sorted array.
        /// Input:
        //        nums1 = [1,2,3,0,0,0], m = 3
        //nums2 = [2,5,6],       n = 3

        //Output: [1,2,2,3,5,6]
        /// </summary>
        public void MergeSortedArrayQuestion()
        {

        }

        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            for (int i = m, j = 0; i < m + n; i++, j++)
            {
                nums1[i] = nums2[j];
            }

            Array.Sort(nums1);

        }



        /// <summary>
        /// Given a set of distinct integers, nums, return all possible subsets (the power set).
        /// Input: nums = [1,2,3]
        //        Output:
        //[
        //  [3],
        //  [1],
        //  [2],
        //  [1,2,3],
        //  [1,3],
        //  [2,3],
        //  [1,2],
        //  []
        //]
        /// </summary>
        public void SubSetQuestion()
        {

        }



        /// <summary>
        /// Move all zeroes to the end, in place without an extra buffer.
        /// </summary>
        /// <param name="nums"></param>
        public void MoveZeroes(int[] nums)
        {
            int lastNonZeroIndex = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    //swap
                    int temp = nums[lastNonZeroIndex];
                    nums[lastNonZeroIndex] = nums[i];
                    nums[i] = temp;

                    lastNonZeroIndex++;
                }
            }
        }

        public void MoveZeroesQuestion()
        {
            var arr = new int[] { 0, 1, 0, 3, 12 };

            MoveZeroes(arr);

            foreach (var e in arr)
            {
                Console.Write(e + " ");
            }
        }

        /// <summary>
        /// Input: ["eat", "tea", "tan", "ate", "nat", "bat"],
        //        Output:
        //[
        //  ["ate","eat","tea"],
        //  ["nat","tan"],
        //  ["bat"]
        //]
        /// 
        /// </summary>
        public void GroupAnagramsQuestion()
        {
            var arr = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };
            var result = GroupAnagrams(arr);

            foreach(var firstLevel in result)
            {
                foreach (var secondLevel in firstLevel)
                {
                    Console.Write(secondLevel + " ");
                }

                Console.WriteLine();
            }
        }

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            foreach (string s in strs)
            {
                string temp = String.Concat(s.OrderBy(c => c));

                if (dict.ContainsKey(temp))
                {
                    dict[temp].Add(s);
                    continue;
                }

                dict.Add(temp, new List<string>() { s });
            }

            return new List<IList<string>>(dict.Values);
        }

        public int MaxProfit(int[] prices)
        {

            int profit = 0;
            int minIndex = prices.Length > 0 ? 0 : -1;

            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < prices[minIndex])
                {
                    minIndex = i;
                }
                else
                {
                    profit = Math.Max(profit, prices[i] - prices[minIndex]);
                }
            }
            return profit;


        }
        /// <summary>
        /// Given an array nums of n integers where n > 1,  return an array output such that output[i] is equal to the product of all the elements of nums except nums[i].
        /// Input:  [1,2,3,4]
        /// Output: [24,12,8,6]
        /// </summary>
        public void ProductExceptSelfQuestion()
        {
            var arr = new int[] {1, 2, 3, 4};

            var result = ProductExceptSelf(arr);

            foreach (var r in result)
            {
                Console.Write(r + " ");
            }
        }

        public int[] ProductExceptSelf(int[] nums)
        {
            int[] result = new int[nums.Length];

            int left = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                result[i] = left;
                left = left * nums[i];
            }

            int right = 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                result[i] = right * result[i];
                right = right * nums[i];
            }

            return result;
        }

        public void LevelOrderTraversalOfBinaryTreeQuestion()
        {
            BinaryTreeNode root = new BinaryTreeNode(1);
            var bt = new BinaryTree(root);
            bt.AddChild(2);
            bt.AddChild(3);
            bt.AddChild(4);
            bt.AddChild(5);
            bt.AddChild(6);
            bt.AddChild(7);
            bt.AddChild(8);
            bt.AddChild(9);
            bt.AddChild(10);
            bt.AddChild(11);

            //Level order traversal can be considered a BFS search as you're printing one level at a time.

            Console.Write("BFS: ");
            BreadthFirstSearch(bt.root);

            Console.WriteLine();
            Console.Write("DFS: ");
            DepthFirstSearch(bt.root);

        }

        public void BreadthFirstSearch(BinaryTreeNode root)
        {
            var queue = new Queue<BinaryTreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var e = queue.Dequeue();
                Console.Write(e.data + " ");


                //add all child nodes
                if (e.leftChild != null)
                {
                    queue.Enqueue(e.leftChild);
                }

                if (e.rightChild != null)
                {
                    queue.Enqueue(e.rightChild);
                }
            }
        }

        void DepthFirstSearch(BinaryTreeNode root)
        {
            if (root == null)
            {
                return;
            }
            var stack = new Stack<BinaryTreeNode>();
            var visited = new HashSet<BinaryTreeNode>();

            stack.Push(root);

            while (stack.Count > 0)
            {
                var temp = stack.Pop();
                Console.Write(temp.data + " ");

                visited.Add(temp);

                //walks down the right side first, then the left side
                if (temp.leftChild != null && !visited.Contains(temp.leftChild))
                {
                    stack.Push(temp.leftChild);
                }

                if (temp.rightChild != null && !visited.Contains(temp.rightChild))
                {
                    stack.Push(temp.rightChild);
       
                }       
            }
        }

        /// <summary>
        /// The count-and-say sequence is the sequence of integers with the first five terms as following:
        /// 
        //1.     1
        //2.     11
        //3.     21
        //4.     1211
        //5.     111221
        // 1 is read off as "one 1" or 11.
        //11 is read off as "two 1s" or 21.
        //21 is read off as "one 2, then one 1" or 1211.
        //Given an integer n, generate the nth term of the count-and-say sequence.

        //Note: Each term of the sequence of integers will be represented as a string.
        /// </summary>
        public void CountAndSayQuestion()
        {
            Console.WriteLine(CountAndSay(5));
        }

        public string CountAndSay(int n)
        {
            return Count(n - 1, "1");
        }

        public string Count(int n, string prev)
        {

            if (n == 0) return prev;

            int count = 0;
            char compare = prev[0];
            string result = "";

            foreach (char a in prev)
            {
                if (compare == a)
                {
                    count++;
                }
                else
                {
                    result = result + count + compare;
                    compare = a;
                    count = 1;
                }
            }
            result = result + count + compare;

            return Count(n - 1, result);
        }

        /// <summary>
        /// 
        /// You are given two non-empty linked lists representing two non-negative integers. 
        /// The digits are stored in reverse order and each of their nodes contain a single digit. 
        /// Add the two numbers and return it as a linked list.
        /// Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
        /// Output: 7 -> 0 -> 8
        /// Explanation: 342 + 465 = 807.
        /// </summary>
        public void AddTwoNumbersQuestion()
        {
            Node n = new Node(9);
            //n.AppendToTail(4);
            //n.AppendToTail(3);

            Node m = new Node(1);
            m.AppendToTail(9);
            m.AppendToTail(9);
            m.AppendToTail(9);
            m.AppendToTail(9);
            m.AppendToTail(9);
            m.AppendToTail(9);
            m.AppendToTail(9);
            m.AppendToTail(9);
            m.AppendToTail(9);
            

            var r = AddTwoNumbers(n, m);

            while (r != null)
            {
                Console.Write(r.data + " ");
                r = r.next;
            }
        }

        public Node AddTwoNumbers(Node l1, Node l2)
        {
            var stackOne = new Stack<Node>();
            var stackTwo = new Stack<Node>();


            while (l1 != null)
            {
                stackOne.Push(l1);
                l1 = l1.next;
            }

            while (l2 != null)
            {
                stackTwo.Push(l2);
                l2 = l2.next;
            }

            double multiplier = Math.Pow(10, stackOne.Count-1);
            double totalOne = 0;
            while (stackOne.Count > 0)
            {
                totalOne += (stackOne.Pop().data * multiplier);
                multiplier /= 10;
            }

            multiplier = Math.Pow(10, stackTwo.Count - 1);
            double totalTwo = 0;
            while (stackTwo.Count > 0)
            {
                totalTwo += (stackTwo.Pop().data * multiplier);
                multiplier /= 10;
            }

            double actualTotal = totalTwo + totalOne;
            var arr = actualTotal.ToString().ToCharArray();
            Node curr = null;
            Node newHead = null;

            for (int i = arr.Length-1; i >= 0; i--)
            {
                if (curr == null)
                {
                    curr = new Node(arr[i] - '0');
                    newHead = curr;
                }
                else
                {
                    curr.next = new Node(arr[i] - '0');
                    curr = curr.next;
                }
            }

            return newHead;
        }

        public Node AddTwoNumbersNonMath(Node l1, Node l2)
        {
            Node dummyHead = new Node(0);
            Node p = l1, q = l2, curr = dummyHead;
            int carry = 0;
            while (p != null || q != null)
            {
                int x = (p != null) ? p.data : 0;
                int y = (q != null) ? q.data : 0;
                int sum = carry + x + y;
                carry = sum / 10;
                curr.next = new Node(sum % 10);
                curr = curr.next;
                if (p != null) p = p.next;
                if (q != null) q = q.next;
            }
            if (carry > 0)
            {
                curr.next = new Node(carry);
            }
            return dummyHead.next;
        }

        public int GetSum(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }

            return (GetSum(a ^ b, (a & b) << 1));
        }

        public void NeedleHaystackQuestion()
        {
            string input = String.Empty;
            while (input != "-1")
            {
                Console.Write("Please enter a haystack: ");
                input = Console.ReadLine();

                Console.WriteLine();
                Console.Write("Please enter a needle: ");
                var needle = Console.ReadLine();
                
                if (input != "-1")
                {
                    var result = StrStr(input, needle);

                    Console.WriteLine(result);
                }
            }
        }

        public void StrStrQuestion()
        {
            string input = "";
            string input2 = "";

            while (input != "-1")
            {
                Console.Write("Please enter the needle: ");
                input = Console.ReadLine();

                Console.Write("Please enter the haystack: ");
                input2 = Console.ReadLine();

                var a = StrStr(input2, input);
                Console.WriteLine(a);
            }
        }

        public int StrStr(string haystack, string needle)
        {
            if (haystack.Length < needle.Length)
            {
                return -1;
            }

            if (needle.Length == 0)
            {
                return 0;
            }

            for (int i = 0; i <= haystack.Length - needle.Length; i++)
            {
                if (haystack[i] == needle[0])
                {
                    for (int j = 0; j < needle.Length; j++)
                    {
                        if (haystack[i + j] != needle[j])
                        {
                            j = needle.Length;
                        }

                        if (j == needle.Length - 1)
                            return i;

                        
                    }
                }
            }

            return -1;
        }


        public int FindMissingContinguousTriplet(string source)
        {
            if (source.Length < 2)
            {
                throw new Exception();
            }
            for (int number = 1, i =2; i < source.Length; number++, i+=3)
            {
                if ((source[i] - '0') != number)
                {
                    return number;
                }
            }

            return -1;
        }

        public void MissingContiguousTripletQuestion()
        {
            string input = String.Empty;

            while (input != "-1")
            {
                Console.Write("Please enter a series of contiguous numbers, starting with 1, and doing triplets. I'll tell you the missing triplet: ");
                input = Console.ReadLine();

                if (input != "-1")
                {
                    var ans = FindMissingContinguousTriplet(input);
                    Console.WriteLine(ans);
                }
            }
        }

        public void IsValidOpenCloseBracketsQuestion()
        {
            string input = String.Empty;

            while (input != "-1")
            {
                Console.Write("Please enter a series of brackets, paranthesis, and curly brackets and i'll tell you if it's valid: ");
                input = Console.ReadLine();

                if (input != "-1")
                {
                    var ans = IsValid(input);
                    if (ans)
                        Console.WriteLine("true");
                    else
                        Console.WriteLine("false");
                }
            }
        }

        public bool IsValid(string s)
        {
            if (s.Length == 0)
                return true;

            var stack = new Stack<char>();
            var hash = new HashSet<char>() { '[', '{', '(' };

            for (int i = 0; i < s.Length; i++)
            {
                if (hash.Contains(s[i]))
                {
                    stack.Push(s[i]);
                }
                else
                {
                    if (stack.Count == 0)
                        return false;

                    var c = stack.Pop();
                    if (c == '(' && s[i] != ')')
                        return false;
                    else if (c == '{' && s[i] != '}')
                        return false;
                    else if (c == '[' && s[i] != ']')
                        return false;
                }
            }

            return stack.Count == 0;
        }

        public Node MergeKLists(Node[] lists)
        {
            var listNodes = new List<Node>();

            foreach (var n in lists)
            {
                Node curr = n;
                while (curr != null)
                {
                    listNodes.Add(curr);
                    curr = curr.next;
                }
            }

            var newList = listNodes.OrderBy(o => o.data).ToArray();
            Node head = new Node(newList[0].data);
            Node currNew = head;

            for (int i = 1; i < newList.Length; i++)
            {
                currNew.next = new Node(newList[i].data);
                currNew = currNew.next;
            }

            return head;
        }

        public void MergeListQuestion()
        {
            Node n1 = new Node(1);
            n1.AppendToTail(4);
            n1.AppendToTail(5);

            Node n2 = new Node(1);
            n2.AppendToTail(3);
            n2.AppendToTail(4);

            Node n3 = new Node(2);
            n3.AppendToTail(6);
            var input = new Node[]
            {
                n1, n2, n3
            };

            var result = MergeKLists(input);

            while (result != null)
            {
                Console.Write(result + " ");
                result = result.next;
            }
        }

        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var list = new List<IList<int>>();
            LevelOrder(root, list, 0);
            return list;
        }

        public void LevelOrder(TreeNode root, IList<IList<int>> list, int depth)
        {
            if (root == null)
                return;
            while (list.Count < depth + 1)
                list.Add(new List<int>());

            list[depth].Add(root.data);
            LevelOrder(root.leftChild, list, depth + 1);
            LevelOrder(root.rightChild, list, depth + 1);
        }

        /// <summary>
        /// Given a binary tree, return the level order traversal of its nodes' values. (ie, from left to right, level by level).
        //        For example:
        //  Given binary tree[3, 9, 20, null, null, 15, 7],
        //    3
        //   / \
        //  9  20
        //    /  \
        //   15   7
        //  return its level order traversal as:
        //  [
        //    [3],
        //    [9,20],
        //    [15,7]
        //  ]
        /// </summary>
        public void LevelOrderQuestion()
        {


        }

        public IList<string> LetterCombinations(string digits)
        {

            if (digits.Length == 0)
            {
                return new List<string>();
            }
            var dict = new Dictionary<int, string>();
            dict.Add(2, "abc");
            dict.Add(3, "def");
            dict.Add(4, "ghi");
            dict.Add(5, "jkl");
            dict.Add(6, "mno");
            dict.Add(7, "pqrs");
            dict.Add(8, "tuv");
            dict.Add(9, "wxyz");
            dict.Add(0, "");
            dict.Add(1, "");

            var list = new List<string>();
            list.Add(String.Empty);

            for (int i = 0; i < digits.Length; i++)
            {
                var letters = dict[digits[i] - '0'];
                if (letters.Length == 0)
                    continue;

                var tempResult = new List<string>();

                for (int j = 0; j < list.Count(); j++)
                {
                    for (int k = 0; k < letters.Length; k++)
                    {
                        string n = list[j] + letters[k];
                        tempResult.Add(n);
                    }
                }

                list = tempResult;
            }

            return list;
        }
    

        public void LetterCombinationsQuestion()
        {
            var result = LetterCombinations("123");

            foreach (var word in result)
            {
                Console.WriteLine(word);
            }
        }


        public void LRUCacheQuestion()
        {
            var cache = new LRUCache(2);
            cache.Put(2, 1);
            cache.Put(1, 2);
            cache.Put(2, 3);
            cache.Put(4, 1);
            cache.Get(1);
            cache.Get(2);
        }

        public String LongestPalindrome(string source)
        {
            int start = 0, end = 0;
            for (int i = 0; i < source.Length; i++)
            {
                //check for an odd number length solution
                int len1 = ExpandAroundCenter(source, i, i);

                //check for an even number length solution
                int len2 = ExpandAroundCenter(source, i, i + 1);
                
                //find the longest solution of these 2
                int len = Math.Max(len1, len2);

                //see if it's the new longest
                if (len > end-start)
                {
                    //if so, set starting and ending position, from the known middle index.
                    start = i -(len - 1) / 2;
                    end = i + len / 2;
                }
            }

            return source.Substring(start, end - start + 1);
        }

        public int ExpandAroundCenter(string source, int left, int right)
        {
            int L = left;
            int R = right;
            while (L >= 0 && R < source.Length && source[L] == source[R])
            {
                L--;
                R++;
            }

            return R - L - 1;
        }

        /// <summary>
        /// Given a string s, find the longest palindromic substring in s. You may assume that the maximum length of s is 1000.
        /// Example 1:

        //Input: "babad"
        //Output: "bab"
        //Note: "aba" is also a valid answer.
        //Example 2:
        //Input: "cbbd"
        //Output: "bb"
        /// 
        /// </summary>
        public void LongestPalindromeQuestion()
        {
            string startingString = "bb";
            Console.WriteLine(startingString);
            Console.WriteLine(LongestPalindrome(startingString));
        }

        public void FindLengthOfLCISQuestion()
        {
            var arr = new int[] {1,3,5,4,2,3,4,5};
            foreach (var element in arr)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
            var x = FindLengthOfLCIS(arr);
            Console.WriteLine(x);
        }

        public int FindLengthOfLCIS(int[] nums)
        {
            int start = 0, end = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int len1 = CheckMiddle(nums, i, i);
                int len2 = CheckMiddle(nums, i, i + 1);
                int len = Math.Max(len1, len2);
                if (len > end - start)
                {
                    start = i - (len - 1) / 2;
                    end = 1 + (len / 2);
                }
            }

            return end - start + 1;
        }

        public int CheckMiddle(int[] arr, int start, int end)
        {
            int prev = start - 1;
            int next = end + 1;

            if (start < 0 || end >= arr.Length || arr[start] == arr[end] || arr[start] > arr[end])
            {
                return 0;
            }

            while (prev >= 0 && next < arr.Length && arr[prev] < arr[start] && arr[next] > arr[end])
            {
                start--;
                prev--;
                end++;
                next++;
            }

            return end - start + 1;
        }

        public string ReverseStringInPlace(StringBuilder source)
        {

            for (int i =0, j = source.Length-1; i < j; i++, j--)
            {
                var temp = source[j];
                source[j] = source[i];
                source[i] = temp;
            }

            return source.ToString();
        }

        //public void ReverseStringInPlaceQuestion()
        //{
        //    string input = "";
        //    while (input != "-1")
        //    {
        //        Console.Write("Please enter a string to reverse: ");
        //        input = Console.ReadLine();

        //        Console.WriteLine(ReverseStringInPlace(input));
        //    }
        //}

        public int CountPalindromicSubstrings(string s)
        {
            var allSubsets = new List<IList<char>>();
            int count = 0;
            allSubsets.Add(new List<char>() { });

            for (int i = 0; i < s.Length; i++)
            {
                var newSubsets = new List<IList<char>>();
                char curr = s[i];
                for (int j = 0; j < allSubsets.Count; j++)
                {
                    var temp = new List<char>(allSubsets[j]); ;
                    temp.Add(curr);
                    newSubsets.Add(new List<char>(temp));
                }

                foreach (var newList in newSubsets)
                {
                    allSubsets.Add(newList);
                }
            }


            foreach (List<char> subset in allSubsets)
            {
                if (IsPalindrome(subset))
                {
                    count++;
                }
            }

            return count;
        }

        public bool IsPalindrome(List<char> list)
        {
            if (list.Count == 1)
                return true;

            if (list.Count == 0)
                return false;

            for (int i = 0, j = list.Count - 1; i < j; i++, j--)
            {
                if (list[i] != list[j])
                    return false;
            }

            return true;
        }

        public void CountPalidromicSubstringsQuestion()
        {
            var input = "aaa";

            Console.WriteLine(CountPalindromicSubstrings(input));
        }

        public int MaxSubArray(int[] nums)
        {
            var len = nums.Length;
            int[] maxArray = new int[len];
            int max = int.MinValue;

            for (int i = len-1; i >=0; i--)
            {
                maxArray[i] = Math.Max(nums[i], i + 1 < len ? maxArray[i + 1] + nums[i] : int.MinValue);
                if (maxArray[i] > max)
                    max = maxArray[i];
            }

            return max;
        }

        public bool WordBreak(String s, List<String> wordDict)
        {
            bool[] boolArr = new bool[s.Length + 1];
            boolArr[0] = true;

            for (int i = 0; i < boolArr.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (boolArr[j] && wordDict.Contains(s.Substring(j, i-j)))
                    {
                        boolArr[i] = true;
                        break;
                    }
                }
            }

            return boolArr[s.Length];
        }

        public void WordBreakQuestion()
        {
            WordBreak("catsandog", new List<string>(){ "cats", "dog", "sand", "and", "cat"});
        }

        public void LeastIntervalQuestion()
        {
            var tasks = new char[]{ 'A', 'A', 'A', 'B', 'B', 'B'};
            int n = 2;

            Console.WriteLine(LeastInterval(tasks, n));
        }


        public List<string> RemoveInvalidParentheses(String s)
        {
            List<string> ans = new List<string>();
            Remove(s, ans, 0, 0, new char[] { '(', ')' });

            return ans;
        }

        private void Remove(string s, List<string> ans, int lastI, int lastJ, char[] parantheses)
        {
            for (int stack = 0, i = lastI; i < s.Length; i++)
            {
                if (s[i] == parantheses[0])
                    stack++;
                else if (s[i] == parantheses[1])
                    stack--;

                if (stack >= 0)
                    continue;

                for (int j = lastJ; j <= i; j++)
                {
                    if (s[j] == parantheses[1] && (j == lastJ || s[j-1] != parantheses[1]))
                    {
                        Remove(s.Substring(0, j) + s.Substring(j + 1, s.Length), ans, i, j, parantheses);
                    }

                    return;
                }

                var reversed = s.ToArray().Reverse().ToString();
                if (parantheses[0] == '(')
                    Remove(reversed, ans, 0, 0, new char[] { ')', '(' });

                else
                    ans.Add(reversed);
            }
        }

        public int LengthOfLongestSubstring(string s)
        {
            //our index to track the last element. Initialize it to a value it'll never be. 
            int[] lastInd = Enumerable.Repeat(-1, 256).ToArray();

            int start = -1;
            int res = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (lastInd[s[i]] > start)
                    start = lastInd[s[i]];
                lastInd[s[i]] = i;
                res = Math.Max(res, i - start);
            }
            return res;
        }

        public void LengthOfLongestSubstringQuestion()
        {
            Console.WriteLine(LengthOfLongestSubstring("dvdf"));
        }

        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int i = 0;
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[j] != nums[i])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }
            return i + 1;
        }

        public void RemoveDuplicatesQuestion()
        {
            var arr = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };

            RemoveDuplicates(arr);

            foreach (var rec in arr)
            {
                Console.Write(rec + " ");
            }
        }

        public int[] PlusOne(int[] digits)
        {

            bool carry = false;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                digits[i] = digits[i] + 1;

                if (digits[i]  == 10)
                {
                    carry = true;
                    digits[i] = 0;
                }
                else
                {
                    carry = false;
                    break;
                }
            }

            if (carry)
            {
                var arr = new int[digits.Length + 1];
                arr[0] = 1;
                for (int i = 1; i < arr.Length; i++)
                    arr[i] = digits[i - 1];

                return arr;
            }


            return digits;
        }

        public void PlusOneQuestion()
        {
            Console.WriteLine(PlusOne(new int[] { 9 }));
        }

        public int LeastInterval(char[] tasks, int n)
        {
            var dict = new Dictionary<char, int>();

            foreach (var rec in tasks)
            {
                if (dict.ContainsKey(rec))
                    dict[rec]++;
                else
                    dict.Add(rec, 1);
            }

            var list = dict.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            int max = dict.First().Value;
            int count = dict.Count(o => o.Value == max);

            int iteration = (n + 1) * (max - 1) + count;

            return (iteration >= tasks.Length ? iteration : tasks.Length);

        }

        public double Pow(double x, int n)
        {
            long N = n;
            if (N < 0)
            {
                x = 1 / x;
                N = -N; //make it positive
            }
            double ans = 1;
            for (long i = 0; i < N; i++)
            {
                ans = ans * x;
            }

            return ans;
        }

        public void PrintLinkedListInReverse(Node head)
        {
            if (head.next == null)
            {
                Console.WriteLine(head.data + " ");
                return;
            }
            else
            {
                PrintLinkedListInReverse(head.next);
                Console.WriteLine(head.data + " ");
            }
                

        }

        public void PrintLinkedListInReverseIterative(Node head)
        {

        }

        public void PrintLinkedListInReverseQuestion()
        {
            var node = new Node(1);
            node.AppendToTail(2);
            node.AppendToTail(3);
            node.AppendToTail(4);
            node.AppendToTail(5);

            PrintLinkedListInReverse(node);
        }

        public bool IsValidBST(TreeNode root)
        {
            if (root == null)
                return false;

            long maxValue = long.MinValue;

            return IsValidBST(root, ref maxValue);


        }

        public bool IsValidBST(TreeNode root, ref long maxValue)
        {
            if (root == null)
                return true;

            if (!IsValidBST(root.leftChild, ref maxValue))
                return false;

            if (root.data <= maxValue)
                return false;
            else
                maxValue = root.data;

            if (!IsValidBST(root.rightChild, ref maxValue))
                return false;

            return true;
        }

        public string ReverseStr(string s, int k)
        {
            if (string.IsNullOrEmpty(s) || k < 2) return s;

            char[] arr = s.ToCharArray();

            for (int i = 0; i < s.Length; i += 2 * k)
            {
                // Determine where the current reverse should end: either (a) after transversing k characters or (b) coming to the end of the string (whichever is smaller)
                int end = Math.Min(i + k, s.Length);

                // Inner-loop performs the actual reversing of the characters
                for (int j = i; j < end; j++)
                {
                    // Calculate position of character within group e.g. first character is pos 0, second pos 1 ...
                    int pos = j - i;

                    // Calculate the position of the new character, which is simply at the end of the group - pos
                    int newPos = end - pos - 1;

                    // Place the character in the new position
                    arr[newPos] = s[j];
                }
            }

            return new string(arr);
        }

        public void ReverseStrQuestion()
        {
            string s = "abcdefghij";
            int k = 4;
                
            Console.WriteLine(ReverseStr(s, k));
        }



    }
}
