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
        public void IterateThroughASinglyLinkedList()
        {
            Node head = new Node(1);
            head.AppendToTail(2);
            head.AppendToTail(3);
            head.AppendToTail(4);
            head.AppendToTail(5);

            IterativelyWalkThroughLinkedListFromHead(head);
            RecursivelyWalkThroughLinkedListFromHead(head);
        }

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

        public int LengthOfLongestSubstring(string s)
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
                    int count = ReverseInteger(int.Parse(input));
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

        public int ReverseInteger(int x)
        {

            var num = x.ToString().ToCharArray();
            bool isNeg = false;
            //first index is a -1
            if (x < 0)
            {
                isNeg = true;
            }

            var sb = new StringBuilder();

            for (int i= num.Length-1; i >= 0; i--)
            {
                if (char.IsNumber(num[i]))
                sb.Append(num[i]);
            }

            int total = 0;
            try
            {
                total = int.Parse(sb.ToString());
            }
            catch (OverflowException)
            {
                return 0;
            }

            if (isNeg)
            {
                return total * -1;
            }
            else
            {
                return total;
            }
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
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    return new int[] { dict[nums[i]], i };
                }
                else
                {
                    if (!dict.ContainsKey(target - nums[i]))
                    {
                        dict.Add((target - nums[i]), i);
                    }
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

        private Node ReverseList(Node head)
        {
            var stack = new Stack<int>();
            var curr = head;

            while (curr != null)
            {
                stack.Push(curr.data);
                curr = curr.next;
            }

            Node newNode;
            if (stack.Count > 0)
            {
                newNode = new Node(stack.Pop());
            }
            else
            {
                return null;
            }

            Node newHead = newNode;
            while (stack.Count > 0)
            {
                newNode.next = new Node(stack.Pop());
                newNode = newNode.next;
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


            var r = ReverseListRecursive(n);

            while (r!= null)
            {
                Console.Write(r + " ");
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

            BreadthFirstSearch(bt.root);

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

    }
}
