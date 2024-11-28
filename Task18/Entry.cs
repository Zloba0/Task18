
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task18
{
    internal class Entry<T>
    {
        public int key;
        public T value;
        public Entry(int key1, T value1)
        {
            key = key1;
            value = value1;
        }
    }
}
