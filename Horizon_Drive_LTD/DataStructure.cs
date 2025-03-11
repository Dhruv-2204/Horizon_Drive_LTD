using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizon_Drive_LTD
{
    class DataStructure
    {
        

        public class HashTable<T>
        {
            private int _capacity; // Total number of slots in the table
            private int _size; // Number of elements currently stored
            private float _loadFactor; // Load factor threshold for resizing
            private T[] _buckets; // Array to store the keys
            private bool[] _deleted; // Track deleted slots for open addressing

            public HashTable(int capacity, float loadFactor = 0.75f)
            {
                if (capacity <= 0)
                    throw new ArgumentException("Capacity must be greater than 0.");
                if (loadFactor <= 0 || loadFactor >= 1)
                    throw new ArgumentException("Load factor must be between 0 and 1.");

                _capacity = GetNextPrime(capacity); // Ensure capacity is a prime number
                _loadFactor = loadFactor;
                _size = 0;
                _buckets = new T[_capacity];
                _deleted = new bool[_capacity];
            }

            private int GetHash(T key)
            {
                int hash = key.GetHashCode();
                return Math.Abs(hash % _capacity); // Ensure hash is within bounds
            }

            public void Insert(T key)
            {
                if (ShouldResize())
                    Resize();

                int index = GetHash(key);
                int originalIndex = index;
                int i = 1;

                // Linear probing to handle collisions
                while (_buckets[index] != null && !_buckets[index].Equals(default(T))
                       && !_deleted[index])
                {
                    index = (originalIndex + i) % _capacity; // Wrap around if necessary
                    i++;
                }

                _buckets[index] = key;
                _deleted[index] = false; // Mark as not deleted
                _size++;
            }

            public bool Search(T key)
            {
                int index = GetHash(key);
                int originalIndex = index;
                int i = 1;

                // Linear probing to find the key
                while (_buckets[index] != null || _deleted[index])
                {
                    if (_buckets[index] != null && _buckets[index].Equals(key))
                        return true;

                    index = (originalIndex + i) % _capacity; // Wrap around if necessary
                    i++;
                }

                return false; // Key not found
            }

            public bool Remove(T key)
            {
                int index = GetHash(key);
                int originalIndex = index;
                int i = 1;

                // Linear probing to find the key
                while (_buckets[index] != null || _deleted[index])
                {
                    if (_buckets[index] != null && _buckets[index].Equals(key))
                    {
                        _buckets[index] = default(T); // Mark as deleted
                        _deleted[index] = true;
                        _size--;
                        return true;
                    }

                    index = (originalIndex + i) % _capacity; // Wrap around if necessary
                    i++;
                }

                return false; // Key not found
            }

            private void Resize()
            {
                int newCapacity = GetNextPrime(_capacity * 2); // Double the capacity
                var newBuckets = new T[newCapacity];
                var newDeleted = new bool[newCapacity];

                // Rehash all existing keys into the new table
                for (int i = 0; i < _capacity; i++)
                {
                    if (_buckets[i] != null && !_buckets[i].Equals(default(T)) && !_deleted[i])
                    {
                        int newIndex = Math.Abs(_buckets[i].GetHashCode() % newCapacity);
                        int j = 1;

                        // Handle collisions in the new table
                        while (newBuckets[newIndex] != null)
                        {
                            newIndex = (newIndex + j) % newCapacity;
                            j++;
                        }

                        newBuckets[newIndex] = _buckets[i];
                    }
                }

                _buckets = newBuckets;
                _deleted = newDeleted;
                _capacity = newCapacity;
            }

            public int Count()
            {
                return _size;
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
        }
    }
}
