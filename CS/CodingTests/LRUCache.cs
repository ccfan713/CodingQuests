using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTests
{
    public class LRUCache
    {
        Dictionary<int, int> cache;
        List<int> keyRank;
        int capacity;

        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            keyRank = new List<int>(capacity);
            cache = new Dictionary<int, int>(capacity);
        }
        public int Get(int key)
        {
            int value = -1;
            if (cache.TryGetValue(key, out value))
            {
                // key exists, update cache
                keyRank.Remove(key);

                if (keyRank.Count == 0)
                {
                    keyRank.Add(key);
                }
                else
                {
                    keyRank.Insert(0, key);
                }
            }
            else
            {
                value = -1;
            }

            return value;
        }
        public void Put(int key, int value)
        {
            if (cache.Count == capacity)
            {
                // remove LRU
                var lruKey = keyRank.Last();
            }
        }
    }
}
