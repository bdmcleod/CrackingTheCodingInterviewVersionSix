using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterviewVersionSix.Misc
{
    public class LRUCache
    {
        private List<KeyValuePair<int, int>> orderedList;
        private Dictionary<int, int> dict;
        int count;


        public LRUCache(int capacity)
        {
            orderedList = new List<KeyValuePair<int, int>>(capacity);
            dict = new Dictionary<int, int>();
            count = capacity;
        }

        public int Get(int key)
        {
            if (dict.ContainsKey(key))
            {
                var temp = orderedList.First(o => o.Key == key);
                orderedList.Remove(temp);
                orderedList.Insert(0, temp);
                return dict[key];
            }

            return -1;
        }

        public void Put(int key, int value)
        {
            if (dict.ContainsKey(key))
            {
                dict[key] = value;
                var temp = orderedList.First(o => o.Key == key);
                orderedList.Remove(temp);
                orderedList.Insert(0, new KeyValuePair<int, int>(key, value));
            }
            else
            {
                dict.Add(key, value);
                if (orderedList.Count == count)
                {
                    var element = orderedList.ElementAt(orderedList.Count - 1);
                    orderedList.RemoveAt(orderedList.Count - 1);
                    dict.Remove(element.Key);
                }

                orderedList.Insert(0, new KeyValuePair<int, int>(key, value));
            }

            return;
        }
    }
}
