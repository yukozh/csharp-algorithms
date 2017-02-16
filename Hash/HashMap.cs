using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash
{
    public class KeyValuePair
    {
        public int Key { get; set; }

        public string Value { get; set; }
    }

    public class HashMap
    {
        public string this[int key]
        {
            get
            {
                return Find(key).Value;
            }
            set
            {
                var node = Find(key);
                if (node != null)
                {
                    node.Value = value;
                }
                else
                {
                    Insert(key, value);
                }
            }
        }

        private KeyValuePair[] _store = new KeyValuePair[100];

        private KeyValuePair Find(int key)
        {
            var pos = GetHash(key);
            if (_store[pos] == null)
                return null;
            while (_store[pos] != null && _store[pos].Key != key)
            {
                ++pos;
                if (pos >= _store.Length)
                    pos = 0;
            }
            return _store[pos];
        }

        private void Insert(int key, string value)
        {
            var pos = GetHash(key);
            while (_store[pos] != null)
            {
                ++pos;
                if (pos >= _store.Length)
                    pos = 0;
            }
            _store[pos] = new KeyValuePair { Key = key, Value = value };
        }

        private int GetHash(int key) => key % 97;
    }
}
