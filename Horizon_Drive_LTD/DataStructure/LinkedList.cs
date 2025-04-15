
using System.Collections;


namespace Horizon_Drive_LTD
{
    /// This class implements a simple linked list to store key-value pairs.
    public class LinkedListNode<TKey, TValue>
    {
        public KeyValuePair<TKey, TValue> Data { get; set; }
        public LinkedListNode<TKey, TValue> Next { get; set; }

        public LinkedListNode(TKey key, TValue value)
        {
            Data = new KeyValuePair<TKey, TValue>(key, value);
            Next = null;
        }
    }

    /// This class implements a simple linked list to store key-value pairs.
    public class LinkedList<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private LinkedListNode<TKey, TValue> head;

        public LinkedList()
        {
            head = null;
        }

        // Add a key-value pair to the end of the list
        public void AddLast(TKey key, TValue value)
        {
            if (head == null)
            {
                head = new LinkedListNode<TKey, TValue>(key, value);
                return;
            }

            LinkedListNode<TKey, TValue> current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = new LinkedListNode<TKey, TValue>(key, value);
        }

        // Remove a node with a matching key
        public bool Remove(TKey key)
        {
            if (head == null) return false;

            if (head.Data.Key.Equals(key))
            {
                head = head.Next;
                return true;
            }

            LinkedListNode<TKey, TValue> current = head;
            while (current.Next != null)
            {
                if (current.Next.Data.Key.Equals(key))
                {
                    current.Next = current.Next.Next;
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        // Find a node by key
        public KeyValuePair<TKey, TValue>? Find(TKey key)
        {
            LinkedListNode<TKey, TValue> current = head;
            while (current != null)
            {
                if (current.Data.Key.Equals(key))
                {
                    return current.Data;
                }
                current = current.Next;
            }
            return null;
        }

        // Get an enumerator to iterate through all key-value pairs
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            LinkedListNode<TKey, TValue> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        // Explicit interface implementation for non-generic IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
