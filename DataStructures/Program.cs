using System;
using System.Collections;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Single Linked List
            Console.WriteLine("---Singly Linked List---");
            SinglyLinkedList mySingly = new SinglyLinkedList();
            mySingly.printList();
            mySingly.addNode(5);
            mySingly.addNode(69);
            mySingly.addNode(420);
            mySingly.addNode(666);
            mySingly.printList();
            mySingly.deleteNode(666);
            mySingly.deleteNode(7);
            mySingly.deleteNode(420);
            mySingly.printList();

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
            Console.WriteLine();
            Console.WriteLine("The smallest value in the tree is {0}", myTree.findSmallest());
            myTree.removeNode(3);
            myTree.removeNode(69);
            myTree.removeNode(13);
            myTree.printInOrder();
            Console.WriteLine();

            //Stack

            Console.WriteLine("---Stack---");
            StackClass myStack = new StackClass();
            myStack.push("Bob", 5);
            myStack.push("Amy", 69);
            myStack.push("John wick", 100);
            myStack.push("Nice", 420);
            myStack.print();
            myStack.pop();
            myStack.pop();
            myStack.print();

            //Hash Table

            Console.WriteLine("---Hash Table---");
            HashTable myTable = new HashTable(10);
            myTable.addItem("Paul", "Locha");
            myTable.addItem("Kim", "Iced mocha");
            myTable.addItem("Emma", "Strawberry smoothie");
            myTable.addItem("Annie", "Hot Chocolate");
            myTable.addItem("Sarah", "Passion Tea");
            myTable.addItem("Pepper", "Caramel Mocha");
            myTable.addItem("Mike", "Chai Tea");
            myTable.addItem("Steve", "Apple Cider");
            myTable.addItem("Bill", "Root Beer");
            myTable.addItem("Marie", "Skinny Latte");
            myTable.addItem("Susan", "Water");
            myTable.addItem("Joe", "Green Tea");
            myTable.printTable();
            myTable.printItemsInIndex(4);
            myTable.removeItem("Marie");
            myTable.printItemsInIndex(4);
        }
    }
}
