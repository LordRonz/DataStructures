using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    class BinarySearchTree
    {
        private BST_Node root;

        public BinarySearchTree()
        {
            root = null;
        }
        private BST_Node createLeaf(int key)
        {
            BST_Node n = new BST_Node();
            n.Key = key;
            n.Left = null;
            n.Right = null;
            return n;
        }

        public void addLeaf(int key)
        {
            addLeafPrivate(key, root);
        }

        private void addLeafPrivate(int key, BST_Node p)
        {
            if (root == null)
            {
                root = createLeaf(key);
            }

            else if (key < p.Key)
            {
                if (p.Left != null)
                {
                    addLeafPrivate(key, p.Left);
                }
                else
                {
                    p.Left = createLeaf(key);
                }
            }

            else if (key > p.Key)
            {
                if (p.Right != null)
                {
                    addLeafPrivate(key, p.Right);
                }
                else
                {
                    p.Right = createLeaf(key);
                }
            }

            else
            {
                Console.WriteLine("The key {0} has already been added to the tree!");
            }
        }

        public void printInOrder()
        {
            printInOrderPrivate(root);
        }

        private void printInOrderPrivate(BST_Node p)
        {
            if (root != null)
            {
                if (p.Left != null)
                {
                    printInOrderPrivate(p.Left);
                }
                Console.Write("{0} ", p.Key);
                if (p.Right != null)
                {
                    printInOrderPrivate(p.Right);
                }
            }
            else
            {
                Console.WriteLine("The tree is empty");
            }
        }

        private BST_Node returnNode(int key)
        {
            return returnNodePrivate(key, root);
        }

        private BST_Node returnNodePrivate(int key, BST_Node p)
        {
            if (p != null)
            {
                if (key == p.Key)
                {
                    return p;
                }
                else
                {
                    if (key < p.Key)
                    {
                        return returnNodePrivate(key, p.Left);
                    }
                    else
                    {
                        return returnNodePrivate(key, p.Right);
                    }
                }
            }
            else
            {
                return p;
            }
        }

        public int returnRootKey()
        {
            if (root != null)
            {
                return root.Key;
            }
            else
            {
                return -1;
            }
        }

        public void printChildren(int key)
        {
            BST_Node p = returnNode(key);
            if (p != null)
            {
                Console.WriteLine("Parent node = {0}", p.Key);
                if (p.Left == null)
                {
                    Console.WriteLine("Left child = null");
                }
                else
                {
                    Console.WriteLine("Left child = {0}", p.Left.Key);
                }
                if (p.Right == null)
                {
                    Console.WriteLine("Right child = null");
                }
                else
                {
                    Console.WriteLine("Right child = {0}", p.Right.Key);
                }
            }
            else
            {
                Console.WriteLine("Key {0} is not in the tree", key);
            }
        }

        public int findSmallest()
        {
            return findSmallestPrivate(root);
        }

        private int findSmallestPrivate(BST_Node p)
        {
            if (root == null)
            {
                Console.WriteLine("The tree is empty");
                return -1;
            }
            else
            {
                if (p.Left != null)
                {
                    return findSmallestPrivate(p.Left);
                }
                else
                {
                    return p.Key;
                }
            }
        }

        public void removeNode(int key)
        {
            removeNodePrivate(key, root);
        }

        private void removeNodePrivate(int key, BST_Node p)
        {
            if (root != null)
            {
                if (root.Key == key)
                {
                    removeRootMatch();
                }
                else
                {
                    if (key < p.Key && p.Left != null)
                    {
                        if (p.Left.Key == key)
                        {
                            removeMatch(p, p.Left, true);
                        }
                        else
                        {
                            removeNodePrivate(key, p.Left);
                        }
                    }
                    else if (key > p.Key && p.Right != null)
                    {
                        if (p.Right.Key == key)
                        {
                            removeMatch(p, p.Right, true);
                        }
                        else
                        {
                            removeNodePrivate(key, p.Right);
                        }
                    }
                    else
                    {
                        Console.WriteLine("The key {0} was not found in the tree", key);
                    }
                }
            }
            else
            {
                Console.WriteLine("The tree is empty");
            }
        }

        private void removeRootMatch()
        {
            if (root != null)
            {
                BST_Node delNode = root;
                int rootKey = root.Key;
                int smallestInRightSubtree;
                if (root.Left == null && root.Right == null)
                {
                    root = null;
                    Console.WriteLine("The root node with key {0} was deleted. Now the tree is empty", rootKey);
                }
                else if (root.Left == null && root.Right != null)
                {
                    root = root.Right;
                    delNode.Right = null;
                    delNode = null;
                    Console.WriteLine("The root node with key {0} was deleted. The new root contains key {1}", rootKey, root.Key);
                }
                else if (root.Left != null && root.Right == null)
                {
                    root = root.Left;
                    delNode.Left = null;
                    delNode = null;
                    Console.WriteLine("The root node with key {0} was deleted. The new root contains key {1}", rootKey, root.Key);
                }
                else
                {
                    smallestInRightSubtree = findSmallestPrivate(root.Right);
                    removeNodePrivate(smallestInRightSubtree, root);
                    root.Key = smallestInRightSubtree;
                    Console.WriteLine("The root node containing key {0} was overwritten with key {1}", rootKey, root.Key);
                }
            }
            else
            {
                Console.WriteLine("Cannot remove key, the tree is empty");
            }
        }

        private void removeMatch(BST_Node parent, BST_Node match, bool left)
        {
            if (root != null)
            {
                int matchKey = match.Key;
                int smallestInRightSubtree;
                if (match.Left == null && match.Right == null)
                {
                    if (left)
                    {
                        parent.Left = null;
                    }
                    else
                    {
                        parent.Right = null;
                    }
                    match = null;
                    Console.WriteLine("The node containing key {0} was removed", matchKey);
                }
                else if (match.Left == null && match.Right != null)
                {
                    if (left)
                    {
                        parent.Left = match.Right;
                    }
                    else
                    {
                        parent.Right = match.Right;
                    }
                    match.Right = null;
                    match = null;
                    Console.WriteLine("The node containing key {0} was removed", matchKey);
                }
                else if (match.Left != null && match.Right == null)
                {
                    if (left)
                    {
                        parent.Left = match.Left;
                    }
                    else
                    {
                        parent.Right = match.Left;
                    }
                    match.Left = null;
                    match = null;
                    Console.WriteLine("The node containing key {0} was removed", matchKey);
                }
                else
                {
                    smallestInRightSubtree = findSmallestPrivate(match.Right);
                    removeNodePrivate(smallestInRightSubtree, match);
                    match.Key = smallestInRightSubtree;
                }
            }
            else
            {
                Console.WriteLine("Cannot remove match, the tree is empty");
            }
        }

        private void removeSubtree(BST_Node p)
        {
            if (p != null)
            {
                if (p.Left != null)
                {
                    removeSubtree(p.Left);
                }
                if (p.Right != null)
                {
                    removeSubtree(p.Right);
                }
                Console.WriteLine("Deleting the node containing key {0}", p.Key);
                p = null;
            }
        }
    }
}
