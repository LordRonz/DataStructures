using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using System.Text;

namespace DataStructures
{
    class HashTable
    {
        private int tableSize = 0;
        private HT_Item[] hashTable;

        public HashTable(int size)
        {
            tableSize = size >= 0 ? size : size * -1;
            hashTable = new HT_Item[tableSize];
            for (int i = 0; i < tableSize; ++i)
            {
                hashTable[i] = new HT_Item();
                hashTable[i].name = "";
                hashTable[i].drink = "";
                hashTable[i].next = null;
            }
        }

        public int Hash(string key)
        {
            int hash = 0;
            int index;

            for (int i = 0; i < key.Length; ++i)
            {
                hash += (int)key[i];
                hash *= 8;
            }

            index = hash % tableSize;

            return index;
        }

        public void addItem(string name, string drink)
        {
            int index = Hash(name);

            if (hashTable[index].name.Length == 0)
            {
                hashTable[index].name = name;
                hashTable[index].drink = drink;
            }

            else
            {
                HT_Item p = hashTable[index];
                HT_Item n = new HT_Item();
                n.name = name;
                n.drink = drink;
                n.next = null;
                while (p.next != null)
                {
                    p = p.next;
                }
                p.next = n;
            }
        }

        public int numberOfItemsInIndex(int index)
        {
            int count = 0;
            if (hashTable[index].name.Length == 0 && hashTable[index].next == null)
            {
                return count;
            }

            else
            {
                ++count;
                HT_Item p = hashTable[index];
                while (p.next != null)
                {
                    p = p.next;
                    ++count;
                }
            }
            return count;
        }

        public void printTable()
        {
            for (int i = 0; i < tableSize; ++i)
            {
                Console.WriteLine("---------------");
                Console.WriteLine("Index = {0}", i);
                Console.WriteLine(hashTable[i].name);
                Console.WriteLine(hashTable[i].drink);
                Console.WriteLine("# of items = {0}", numberOfItemsInIndex(i));
                Console.WriteLine("---------------");
            }
        }

        public void printItemsInIndex(int index)
        {
            HT_Item p = hashTable[index];
            if (p.name.Length == 0 && p.next == null)
            {
                Console.WriteLine("Index {0} is empty", index);
            }

            else
            {
                Console.WriteLine("Index {0} contains the following items", index);
                while (p != null)
                {
                    Console.WriteLine("--------------");
                    Console.WriteLine(p.name);
                    Console.WriteLine(p.drink);
                    Console.WriteLine("--------------");
                    p = p.next;
                }
            }
        }

        public void findDrink(string name)
        {
            int index = Hash(name);
            bool foundName = false;
            string drink = "";

            HT_Item p = hashTable[index];
            while (p != null)
            {
                if (p.name == name)
                {
                    drink = p.drink;
                    foundName = true;
                    break;
                }
                p = p.next;
            }

            if (foundName)
            {
                Console.WriteLine("{0}'s favorite drink = {1}", name, drink);
            }
            else
            {
                Console.WriteLine("{0}'s info was not found in the Hash Table");
            }
        }

        public void removeItem(string name)
        {
            int index = Hash(name);
            HT_Item p1;
            HT_Item p2;
            HT_Item delItem;

            if (hashTable[index].name.Length == 0 && hashTable[index].drink.Length == 0)
            {
                Console.WriteLine("{0} was not found in the Hash Table", name);
            }

            else if (hashTable[index].name == name && hashTable[index].next == null)
            {
                hashTable[index].name = "";
                hashTable[index].drink = "";
                Console.WriteLine("{0} was removed from the Hash Table", name);
            }

            else if (hashTable[index].name == name)
            {
                delItem = hashTable[index];
                hashTable[index] = hashTable[index].next;
                delItem.next = null;
                Console.WriteLine("{0} was removed from the Hash Table", name);
            }

            else
            {
                p1 = hashTable[index].next;
                p2 = hashTable[index];
                while (p1 != null && p1.name != name)
                {
                    p2 = p1;
                    p1 = p1.next;
                }

                if (p1 == null)
                {
                    Console.WriteLine("{0} was not found in the Hash Table", name);
                }
                else
                {
                    delItem = p1;
                    p1 = p1.next;
                    p2.next = p1;
                    delItem.next = null;
                    Console.WriteLine("{0} was removed from the Hash Table", name);
                }
            }
        }
    }
}
