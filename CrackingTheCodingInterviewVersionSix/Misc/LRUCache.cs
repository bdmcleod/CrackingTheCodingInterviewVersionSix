using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterviewVersionSix.Misc
{
    public class LRUCache
    {
        private int count;
        private Dictionary<int, int> dict;
        private List<Item> list;


        public LRUCache(int capacity)
        {
            dict = new Dictionary<int, int>(count);
            list = new List<Item>(count);
        }

        public int Get(int key)
        {
            if (dict.ContainsKey(key))
            {
                var temp = list.Where(o => o.key == key).First();
                list.Remove(temp);
                list.Add(temp);

                return dict[key];
            }
            else
            {
                return -1;
            }            
        }

        public void Put(int key, int value)
        {
            if (dict.Count == count)
            {
                var temp = list[0];
                dict.Remove(temp.key);
                list.Remove(temp);
            }

            dict.Add(key, value);
            list.Add(new Item(key, value));
        }
    }

    internal class Item
    {
        public int key { get; set; }
        public int value { get; set; }

        public Item(int k, int v)
        {
            this.key = k;
            this.value = v;
        }
    }
}
