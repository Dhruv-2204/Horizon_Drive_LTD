using System;
using System.Collections.Generic;

namespace Horizon_Drive_LTD
{
    class DataStructure
    {
        public class HashTable<T>
        {
            private int _capacity; // Total number of slots in the table
            private int _size; // Number of elements currently stored
            private float _loadFactor; // Load factor threshold for resizing
            private LinkedList<T>[] _buckets; // Array of linked lists for separate chaining

            public HashTable(int capacity, float loadFactor = 0.75f)
            {
                if (capacity <= 0)
                    throw new ArgumentException("Capacity must be greater than 0.");
                if (loadFactor <= 0 || loadFactor >= 1)
                    throw new ArgumentException("Load factor must be between 0 and 1.");

                _capacity = GetNextPrime(capacity); // Ensure capacity is a prime number
                _loadFactor = loadFactor;
                _size = 0;
                _buckets = new LinkedList<T>[_capacity];
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

                // Initialize the linked list if the bucket is empty
                if (_buckets[index] == null)
                {
                    _buckets[index] = new LinkedList<T>();
                }

                // Add the key to the linked list
                _buckets[index].AddLast(key);
                _size++;
            }

            public bool Search(T key)
            {
                int index = GetHash(key);

                // Check if the bucket exists and contains the key
                if (_buckets[index] != null)
                {
                    return _buckets[index].Contains(key);
                }

                return false; // Key not found
            }

            public bool Remove(T key)
            {
                int index = GetHash(key);

                // Check if the bucket exists and contains the key
                if (_buckets[index] != null && _buckets[index].Remove(key))
                {
                    _size--;
                    return true;
                }

                return false; // Key not found
            }

            private void Resize()
            {
                int newCapacity = GetNextPrime(_capacity * 2); // Double the capacity
                var newBuckets = new LinkedList<T>[newCapacity];

                // Rehash all existing keys into the new table
                for (int i = 0; i < _capacity; i++)
                {
                    if (_buckets[i] != null)
                    {
                        foreach (var key in _buckets[i])
                        {
                            int newIndex = Math.Abs(key.GetHashCode() % newCapacity);

                            // Initialize the linked list if the bucket is empty
                            if (newBuckets[newIndex] == null)
                            {
                                newBuckets[newIndex] = new LinkedList<T>();
                            }

                            // Add the key to the linked list in the new bucket
                            newBuckets[newIndex].AddLast(key);
                        }
                    }
                }

                _buckets = newBuckets;
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