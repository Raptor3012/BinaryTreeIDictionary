using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace BinaryTreeIDictionary
{
    class BinaryTreeDictionary<Tkey, Tvalue> : IDictionary<Tkey, Tvalue>
        where Tkey : IComparable
    {
        private BinaryTree<Tkey, Tvalue> tree = new BinaryTree<Tkey, Tvalue>();


        public Tvalue this[Tkey key] { get => tree.Find(key).KeyValuePair.Value;
            set
            {
                var node = tree.Find(key);
                if (node == null)
                    Add(key, value);
                else
                    node.KeyValuePair = new KeyValuePair<Tkey, Tvalue>(key, value);
            } }

        public ICollection<Tkey> Keys => tree.Traverse().Select(node => node.KeyValuePair.Key).ToList();

        public ICollection<Tvalue> Values => tree.Traverse().Select(node => node.KeyValuePair.Value).ToList();

        //public int Count { get; private set; }
        public int Count => tree.Traverse().Count();

        public bool IsReadOnly => false;

        public void Add(Tkey key, Tvalue value)
        {
            var KeyValuePair = new KeyValuePair<Tkey, Tvalue>(key, value);
            tree.Add(KeyValuePair);
            //if (tree.Add(KeyValuePair))
            //Count++;
        }

        public void Add(KeyValuePair<Tkey, Tvalue> item)
        {
            tree.Add(item);
            //if (tree.Add(item))
            //Count++;
        }

        public void Clear()
        {
            tree = new BinaryTree<Tkey, Tvalue>();
            //Count = 0;
        }

        public bool Contains(KeyValuePair<Tkey, Tvalue> item)
        {
            var currentNode = tree.Find(item.Key);
            return currentNode != null && currentNode.KeyValuePair.Equals(item.Value);
        }

        public bool ContainsKey(Tkey key)
        {
            var currentNode = tree.Find(key);
            return currentNode != null;
        }

        public void CopyTo(KeyValuePair<Tkey, Tvalue>[] array, int arrayIndex)
        {
            if (array.Length < arrayIndex + Count)
            {
                throw new ArgumentException(
                    "The length of the current array is not enough to copy the elements of the collection!");
            }
            foreach (var node in tree.Traverse())
            {
                array[arrayIndex] = node.KeyValuePair;
                arrayIndex++;
            }
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

        public IEnumerator<KeyValuePair<Tkey, Tvalue>> GetEnumerator()
        {
            return tree.Traverse()
                .Select(node => node.KeyValuePair)
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
