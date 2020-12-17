using System;
using System.Collections.Generic;

namespace BinaryTreeIDictionary
{
    class BinaryTree<Tkey, Tvalue>
        where Tkey : IComparable
    {
        private Node<Tkey, Tvalue> root;

        public bool Add(KeyValuePair<Tkey, Tvalue> item)
        {
            var currentNode = root;
            while (currentNode != null)
            {
                var compareResult = item.Key.CompareTo(currentNode.KeyValuePair.Key);
                if (compareResult < 0)
                {
                    if (currentNode.Left == null)
                    {
                        currentNode.Left = new Node<Tkey, Tvalue>
                        {
                            KeyValuePair = item,
                            Parent = currentNode
                        };
                        return true;
                    }

                    currentNode = currentNode.Left;
                }
                else if (compareResult > 0)
                {
                    if (currentNode.Right == null)
                    {
                        currentNode.Right = new Node<Tkey, Tvalue>
                        {
                            KeyValuePair = item,
                            Parent = currentNode
                        };
                        return true;
                    }

                    currentNode = currentNode.Right;
                }
                else
                {
                    return false;
                }
            }

            root = new Node<Tkey, Tvalue>
            {
                KeyValuePair = item
            };
            return true;
        }

        public Node<Tkey,Tvalue> Find(Tkey key)
        {
            var currentNode = root;
            while (currentNode != null)
            {
                var compareResult = key.CompareTo(currentNode.KeyValuePair.Key);
                if (compareResult < 0)
                {
                    currentNode = currentNode.Left;
                }
                else if (compareResult > 0)
                {
                    currentNode = currentNode.Right;
                }
                else
                {
                    return currentNode;
                }
            }

            return null;
        }
    }
}
