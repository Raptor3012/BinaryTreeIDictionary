using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BinaryTreeIDictionary
{
    class BinaryTreeDictionary<Tkey, Tvalue> : IDictionary<Tkey, Tvalue>
        where Tkey : IComparable
    {
        private BinaryTree<Tkey, Tvalue> tree = new BinaryTree<Tkey, Tvalue>();

        
        public Tvalue this[Tkey key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ICollection<Tkey> Keys => throw new NotImplementedException();

        public ICollection<Tvalue> Values => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => false;

        public void Add(Tkey key, Tvalue value)
        {
            //throw new NotImplementedException();
            var KeyValuePair = new KeyValuePair<Tkey, Tvalue>(key, value);
            this.tree.Add(KeyValuePair);
        }

        public void Add(KeyValuePair<Tkey, Tvalue> item)
        {
            this.tree.Add(item);
        }

        public void Clear()
        {
            tree = new BinaryTree<Tkey, Tvalue>();
        }

        public bool Contains(KeyValuePair<Tkey, Tvalue> item)
        {
            var currentNode = tree.Find(item.Key);
            return currentNode != null && currentNode.KeyValuePair.Equals(item.Value);
        }

        public bool ContainsKey(Tkey key)
        {
            var currentNode = tree.Find(key);
            if (currentNode != null)
                return true;
            else return false;
        }

        public void CopyTo(KeyValuePair<Tkey, Tvalue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<Tkey, Tvalue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(Tkey key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<Tkey, Tvalue> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(Tkey key, [MaybeNullWhen(false)] out Tvalue value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
