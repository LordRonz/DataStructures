using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    class StackClass
    {
        Stack_Node stackNode;
        public StackClass()
        {
            stackNode = null;
        }

        public void push(string name, int value)
        {
            Stack_Node n = new Stack_Node();
            n.Name = name;
            n.Value = value;
            if (stackNode != null)
            {
                n.Prev = stackNode;
                stackNode = n;
            }
            else
            {
                stackNode = n;
                stackNode.Prev = null;
            }
        }

        private void readNode(Stack_Node r)
        {
            Console.WriteLine("--------------");
            Console.WriteLine("Name : {0}", r.Name);
            Console.WriteLine("Value : {0}", r.Value);
            Console.WriteLine("--------------");
        }

        public void pop()
        {
            if (stackNode != null)
            {
                Stack_Node p = stackNode;
                readNode(p);
                stackNode = stackNode.Prev;
                p.Prev = null;
                p = null;
            }
            else
            {
                Console.WriteLine("There is nothing on the stack");
            }
        }

        public void print()
        {
            Stack_Node p = stackNode;
            while (p != null)
            {
                readNode(p);
                p = p.Prev;
            }
        }
    }
}
