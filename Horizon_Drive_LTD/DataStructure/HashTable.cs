using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizon_Drive_LTD.DataStructure
{
    // This is an implementation of a hash table using separate chaining with linked lists.
    public class HashTable<TKey, TValue>
    {
        private int _capacity;
        private int _size;
        private float _loadFactor;
        private LinkedList<KeyValuePair<TKey, TValue>>[] _buckets;

        // Constructor to initialize the hash table with a specified capacity and load factor
        public HashTable(int capacity, float loadFactor = 0.75f)
        {
            if (capacity <= 0)
                throw new ArgumentException("Capacity must be greater than 0.");
            if (loadFactor <= 0 || loadFactor >= 1)
                throw new ArgumentException("Load factor must be between 0 and 1.");

            _capacity = GetNextPrime(capacity);
            _loadFactor = loadFactor;
            _size = 0;
            _buckets = new LinkedList<KeyValuePair<TKey, TValue>>[_capacity];
        }

        private int GetHash(TKey key)
        {
            int hash = key.GetHashCode();
            double product = hash * 0.618033988749895; // Fibonacci hashing
            double fractionalPart = product - Math.Floor(product);
            return (int)(_capacity * fractionalPart);
        }
        // This method is used to insert a key-value pair into the hash table.
        public void Insert(TKey key, TValue value)
        {
            if (ShouldResize())
                Resize();

            int index = GetHash(key);

            if (_buckets[index] == null)
            {
                _buckets[index] = new LinkedList<KeyValuePair<TKey, TValue>>();
            }

            var bucket = _buckets[index];
            var existingNode = bucket.FirstOrDefault(node => node.Key.Equals(key));
            if (!EqualityComparer<TKey>.Default.Equals(existingNode.Key, default) && existingNode.Key.Equals(key))
            {
                // Remove the existing key-value pair
                bucket.Remove(existingNode);

                // Add a new key-value pair with the updated value
                bucket.AddLast(new KeyValuePair<TKey, TValue>(key, value));  
            }
            else
            {
                // Add a new key-value pair
                bucket.AddLast(new KeyValuePair<TKey, TValue>(key, value));
                _size++;
            }

        }
        // This method is used to search for a value by its key in the hash table.
        public TValue Search(TKey key)
        {
            int index = GetHash(key);

            if (_buckets[index] != null)
            {
                foreach (var kvp in _buckets[index])
                {
                    if (kvp.Key.Equals(key))
                    {
                        return kvp.Value; // Return the value if the key is found
                    }
                }
            }

            return default; // Key not found
        }

        public bool Remove(TKey key)
        {
            int index = GetHash(key);

            if (_buckets[index] != null)
            {
                var node = _buckets[index].FirstOrDefault(n => n.Key.Equals(key));
                if (node.Key != null && node.Key.Equals(key))
                {
                    _buckets[index].Remove(node);
                    _size--;
                    return true;
                }
            }

            return false; // Key not found
        }
        // This method checks if the hash table contains a specific key.
        public bool ContainsKey(TKey key)
        {
            int index = GetHash(key);

            if (_buckets[index] != null)
            {
                foreach (var kvp in _buckets[index])
                {
                    if (kvp.Key.Equals(key))
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        // This method retrieves all key-value pairs in the hash table.
        public IEnumerable<KeyValuePair<TKey, TValue>> GetAllItems()
        {
            for (int i = 0; i < _capacity; i++)
            {
                if (_buckets[i] != null)
                {
                    foreach (var kvp in _buckets[i])
                    {
                        yield return kvp;
                    }
                }
            }
        }
        // This method retrieves all values in the hash table.
        public IEnumerable<TValue> Values()
        {
            for (int i = 0; i < _capacity; i++)
            {
                if (_buckets[i] != null)
                {
                    foreach (var kvp in _buckets[i])
                    {
                        yield return kvp.Value;
                    }
                }
            }
        }
        // This method retrieves all keys in the hash table.
        public IEnumerable<TKey> Keys()
        {
            for (int i = 0; i < _capacity; i++)
            {
                if (_buckets[i] != null)
                {
                    foreach (var kvp in _buckets[i])
                    {
                        yield return kvp.Key;
                    }
                }
            }


        }
        // This method resizes the hash table when the load factor exceeds the threshold.
        private void Resize()
        {
            int newCapacity = GetNextPrime(_capacity * 2);
            var newBuckets = new LinkedList<KeyValuePair<TKey, TValue>>[newCapacity];

            for (int i = 0; i < _capacity; i++)
            {
                if (_buckets[i] != null)
                {
                    foreach (var kvp in _buckets[i])
                    {
                        int newIndex = GetHash(kvp.Key);
                        if (newBuckets[newIndex] == null)
                        {
                            newBuckets[newIndex] = new LinkedList<KeyValuePair<TKey, TValue>>();
                        }
                        newBuckets[newIndex].AddLast(kvp);
                    }
                }
            }

            _buckets = newBuckets;
            _capacity = newCapacity;
        }

        private bool ShouldResize()
        {
            return (float)_size / _capacity >= _loadFactor;
        }

        private int GetNextPrime(int number)
        {
            while (true)
            {
                if (IsPrime(number))
                    return number;
                number++;
            }
        }

        private bool IsPrime(int number)
        {
            if (number < 2)
                return false;
            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }

        public int Count
        {
            get
            {
                return _size;
            }
        }
    }
}
