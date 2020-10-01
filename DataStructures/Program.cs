using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Single Linked List
            Console.WriteLine("---Single Linked List---");
            SingleLinkedList damn = new SingleLinkedList();
            damn.printList();
            damn.addNode(5);
            damn.addNode(69);
            damn.addNode(420);
            damn.addNode(666);
            damn.printList();
            damn.deleteNode(666);
            damn.deleteNode(7);
            damn.deleteNode(420);
            damn.printList();

            //Doubly Linked List

            Console.WriteLine("---Doubly Linked List---");
            DoublyLinkedList myDoubly = new DoublyLinkedList();
            myDoubly.addNode(9);
            myDoubly.addNode(10);
            myDoubly.addNode(69);
            myDoubly.addNode(420);
            myDoubly.addNode(666);
            myDoubly.printForward();
            myDoubly.printReverse();
            myDoubly.deleteNode(9);
            myDoubly.deleteNode(69);
            myDoubly.printForward();
            myDoubly.printReverse();

            //Binary Search Tree

            Console.WriteLine("---Binary Search Tree---");
            BinarySearchTree myTree = new BinarySearchTree();
            int[] treeKey = { 69, 420, 77, 80, 13, 1, 8, 666, 71, 100 };
            for (int i = 0; i < treeKey.Length; ++i)
            {
                myTree.addLeaf(treeKey[i]);
            }
            myTree.printInOrder();
            Console.WriteLine("The smallest value in the tree is {0}", myTree.findSmallest());
            myTree.removeNode(3);
            myTree.removeNode(69);
            myTree.removeNode(13);
            myTree.printInOrder();
        }
    }
}
