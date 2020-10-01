using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace DataStructures
{
    class SinglyLinkedList
    {
        private SLL_Node head;
        private SLL_Node current;
        private SLL_Node temp;
        public int count;
        public SinglyLinkedList()
        {
            head = null;
            current = null;
            temp = null;
        }
        public void addNode(int addData) 
        {
            SLL_Node n = new SLL_Node();
            n.Next = null;
            n.Data = addData;
            if (head != null)
            {
                current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = n;
            }
            else {
                head = n;
            }
            count++;
        }

        public void deleteNode(int delData) {
            SLL_Node delNode = null;
            temp = head;
            current = head;
            while (current != null && current.Data != delData) {
                temp = current;
                current = current.Next;
            }
            if (current == null)
            {
                Console.WriteLine("{0} was not in the list", delData);
            }
            else {
                delNode = current;
                current = current.Next;
                temp.Next = current;
                if (head.Data == delData)
                {
                    head = head.Next;
                    temp = null;
                }
                delNode = null;
                Console.WriteLine("The data {0} was deleted", delData);
            }
        }

        public void printList()
        {
            current = head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }

        public int getNodeCount()
        {
            return count;
        }
    }
}
