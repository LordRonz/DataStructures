using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    class DoublyLinkedList
    {
        private DLL_Node head;
        private DLL_Node tail;
        private DLL_Node current;
        private DLL_Node temp;

        public DoublyLinkedList()
        {
            head = null;
            tail = null;
            current = null;
            temp = null;
        }

        public void addNode(int addData)
        {
            DLL_Node n = new DLL_Node();
            n.Next = null;
            n.Prev = null;
            n.Data = addData;
            if (head != null)
            {
                current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = n;
                n.Prev = current;
                tail = n;
            }
            else
            {
                head = n;
                tail = n;
            }
        }

        public void deleteNode(int delData)
        {
            DLL_Node delNode = new DLL_Node();
            temp = head;
            current = head;
            while (current != null && current.Data != delData)
            {
                temp = current;
                current = current.Next;
            }
            if (current == null)
            {
                Console.WriteLine("{0} was not in the list", delData);
            }
            else
            {
                delNode = current;
                current = current.Next;
                current.Prev = temp;
                temp.Next = current;
                if (head.Data == delData)
                {
                    head = head.Next;
                    temp = null;
                }
                Console.WriteLine("The data {0} was deleted", delData);
            }
        }

        public void printForward()
        {
            current = head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }

        public void printReverse()
        {
            current = tail;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Prev;
            }
        }
    }
}
