
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task18
{
    internal class MyHashMap<T>
    {
        MyLinkedList<Entry<T>>[] table;
        int size;
        float loadFactor;
        public void Put(int key, T value)
        {
            int hash = Math.Abs(value.GetHashCode());
            int numBucket = hash % table.Length;
            Entry<T> x = new Entry<T>(hash, value);
            bool flag = false;
            if (table[numBucket].Size() == 0)
            {
                table[numBucket] = new MyLinkedList<Entry<T>>(x);
                size++;
            }
            else
            {
                MyLinkedList<Entry<T>>.List<Entry<T>> p = table[numBucket].first;
                for (int i = 0; i < table[numBucket].Size(); i++)
                {
                    if (hash.Equals(p.info.key))
                    {
                        if (value.Equals(p.info.value))
                        {
                            p.info.value = value;
                            flag = true;
                            break;
                        }

                    }
                    p = p.next;
                }
                if (!flag)
                {
                    table[numBucket].Add(x);
                    size++;
                }
            }
        }
        public MyHashMap()
        {
            table = new MyLinkedList<Entry<T>>[16];
            loadFactor = 0.75f;
            size = 0;
        }
        public MyHashMap(int initialCapacity)
        {
            table = new MyLinkedList<Entry<T>>[initialCapacity];
            loadFactor = 0.75f;
            size = 0;
        }
        public MyHashMap(int initialCapacity, float loadFactor)
        {
            table = new MyLinkedList<Entry<T>>[initialCapacity];
            this.loadFactor = loadFactor;
            size = 0;
        }
        public void Clear()
        {
            for (int i = 0; i < size; i++)
            {
                table[i] = new MyLinkedList<Entry<T>>();
            }
            size = 0;
        }
        public bool ContainsKey(object key)
        {
            int hash;
            try
            {
                hash = (int)key;
            }
            catch
            {
                throw new Exception();
            }
            if (hash < 0)
            {
                throw new ArgumentException();
            }
            int numBucket = hash % table.Length;
            if (table[numBucket].Size() == 0)
            {
                return false;
            }
            else
            {
                MyLinkedList<Entry<T>>.List<Entry<T>> p = table[numBucket].first;
                for (int i = 0; i < table[numBucket].Size(); i++)
                {
                    if (hash.Equals(p.info.key))
                    {
                        return true;
                    }
                    p = p.next;
                }
            }
            return false;
        }
        public bool ContainsValue(object value)
        {
            int hash = Math.Abs(value.GetHashCode());
            int numBucket = hash % table.Length;
            if (table[numBucket].Size() == 0)
            {
                return false;
            }
            else
            {
                MyLinkedList<Entry<T>>.List<Entry<T>> p = table[numBucket].first;
                for (int i = 0; i < table[numBucket].Size(); i++)
                {
                    if (hash.Equals(p.info.key))
                    {
                        if (value.Equals(p.info.value))
                        {
                            return true;
                        }

                    }
                    p = p.next;
                }
            }
            return false;
        }
        public Entry<T>[] EntrySet()
        {
            Entry<T>[] result = new Entry<T>[size];
            int index = 0;
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i].Size() == 0)
                {

                }
                else
                {
                    MyLinkedList<Entry<T>>.List<Entry<T>> p = table[i].first;
                    for (int j = 0; i < table[i].Size(); j++)
                    {
                        result[index] = p.info;
                        index++;
                        p = p.next;
                    }
                }
            }
            return result;
        }
        public object Get(object key)
        {
            int hash;
            try
            {
                hash = (int)key;
            }
            catch
            {
                throw new Exception();
            }
            if (hash < 0)
            {
                throw new ArgumentException();
            }
            int numBucket = hash % table.Length;
            if (table[numBucket].Size() == 0)
            {
                return null;
            }
            else
            {
                MyLinkedList<Entry<T>>.List<Entry<T>> p = table[numBucket].first;
                for (int i = 0; i < table[numBucket].Size(); i++)
                {
                    if (hash.Equals(p.info.key))
                    {
                        return p.info.value;

                    }
                    p = p.next;
                }
            }
            return null;
        }
        public bool IsEmpty()
        {
            return size == 0 ? true : false;
        }
        public int[] KeySet()
        {
            int[] result = new int[size];
            int index = 0;
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i].Size() == 0)
                {

                }
                else
                {
                    MyLinkedList<Entry<T>>.List<Entry<T>> p = table[i].first;
                    for (int j = 0; i < table[i].Size(); j++)
                    {
                        result[index] = p.info.key;
                        index++;
                        p = p.next;
                    }
                }
            }
            return result;
        }
        public void Remove(object key)
        {
            int hash;
            try
            {
                hash = (int)key;
            }
            catch
            {
                throw new Exception();
            }
            if (hash < 0)
            {
                throw new ArgumentException();
            }
            int numBucket = hash % table.Length;
            if (table[numBucket].Size() != 0)
            {
                MyLinkedList<Entry<T>>.List<Entry<T>> p = table[numBucket].first;
                for (int i = 0; i < table[numBucket].Size(); i++)
                {
                    if (hash.Equals(p.info.key))
                    {
                        table[numBucket].Remove(p.info);
                        size--;
                        break;
                    }
                    p = p.next;
                }
            }
        }
        public int Size()
        {
            return size;
        }
    }
}
