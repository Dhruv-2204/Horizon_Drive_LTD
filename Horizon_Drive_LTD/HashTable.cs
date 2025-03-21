using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizon_Drive_LTD
{
    public class HashTable<TKey, TValue>
    {
        private const int DefaultCapacity = 16;
        private LinkedList<TKey, TValue>[] _buckets;

        public HashTable()
        {
            _buckets = new LinkedList<TKey, TValue>[DefaultCapacity];
        }

        // Fibonacci-based hash function
        private int FibonacciHash(TKey key)
        {
            const double goldenRatio = 1.618033988749895; // (sqrt(5) + 1) / 2
            int hashCode = key.GetHashCode();
            double product = hashCode * goldenRatio;
            double fractionalPart = product - Math.Floor(product);
            return (int)(_buckets.Length * fractionalPart);
        }

        private int GetBucketIndex(TKey key)
        {
            return FibonacciHash(key) % _buckets.Length;
        }

        public void Add(TKey key, TValue value)
        {
            int bucketIndex = GetBucketIndex(key);

            if (_buckets[bucketIndex] == null)
            {
                _buckets[bucketIndex] = new LinkedList<TKey, TValue>();
            }

            _buckets[bucketIndex].Add(key, value);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            int bucketIndex = GetBucketIndex(key);

            if (_buckets[bucketIndex] != null)
            {
                return _buckets[bucketIndex].TryGetValue(key, out value);
            }

            value = default;
            return false;
        }

        public bool Remove(TKey key)
        {
            int bucketIndex = GetBucketIndex(key);

            if (_buckets[bucketIndex] != null)
            {
                return _buckets[bucketIndex].Remove(key);
            }

            return false;
        }
    }
}
