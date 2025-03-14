using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizon_Drive_LTD
{
    
    public class LinkedListNode<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public LinkedListNode<TKey, TValue> Next { get; set; }

        public LinkedListNode(TKey key, TValue value)
        {
            Key = key;
            Value = value;
            Next = null;
        }
    }

    public class LinkedList<TKey, TValue>
    {
        private LinkedListNode<TKey, TValue> _head;

        public void Add(TKey key, TValue value)
        {
            var newNode = new LinkedListNode<TKey, TValue>(key, value);
            if (_head == null)
            {
                _head = newNode;
            }
            else
            {
                var current = _head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            var current = _head;
            while (current != null)
            {
                if (current.Key.Equals(key))
                {
                    value = current.Value;
                    return true;
                }
                current = current.Next;
            }

            value = default;
            return false;
        }

        public bool Remove(TKey key)
        {
            if (_head == null)
            {
                return false;
            }

            if (_head.Key.Equals(key))
            {
                _head = _head.Next;
                return true;
            }

            var current = _head;
            while (current.Next != null)
            {
                if (current.Next.Key.Equals(key))
                {
                    current.Next = current.Next.Next;
                    return true;
                }
                current = current.Next;
            }

            return false;
        }
    }
}
