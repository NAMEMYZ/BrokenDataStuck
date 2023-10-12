using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ArrayStack : Stack
    {
        private object[] data;
        private int cap;
        private int SIZE;
        public ArrayStack(int cap)
        {
            this.cap = cap;
            data = new object[cap];
        }

        public object peek()
        {
            if (isEmpty())
                throw new System.MissingMemberException();
            return data[SIZE - 1];
        }

        public object pop()
        {
            object e = peek();
            data[--SIZE] = null;
            return e;
        }
        public bool isEmpty()
        {
            return SIZE == 0;
        }
        private void ensureCapacity()
        {
            if (SIZE + 1 > data.Length)
            {
                object[] temp = new object[cap * 2];
                for (int i = 0; i < SIZE; i++)
                {
                    temp[i] = data[i];
                }
                data = temp;
            }
        }

        public void push(object e)
        {
            ensureCapacity();
            data[SIZE++] = e;
        }

        public int size()
        {
            return SIZE;
        }
    }
}
