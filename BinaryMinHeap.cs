﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class BinaryMinHeap : PriorityQueue
    {
        private object[] data;
        private int SIZE;
        private int cap;

        public BinaryMinHeap(int cap)
        {
            data = new object[cap];
            this.cap = cap;
        }
        public object dequeue()
        {
            object max = peek();
            data[0] = data[--SIZE];
            data[SIZE] = null;
            if (SIZE > 1) reorderDown(0);
            return max;
        }

        public void enqueue(object e)
        {
            ensureCapacity();
            data[SIZE] = e;
            reorderUp(SIZE++);
        }

        public bool isEmpty()
        {
            return SIZE == 0;
        }

        public object peek()
        {
            if (isEmpty())
                throw new System.MissingMemberException();
            return data[0];
        }

        public int size()
        {
            return SIZE;
        }
        private void reorderDown(int k)
        {
            int c;
            while ((c = 2 * k + 1) < SIZE)
            {
                if (c + 1 < SIZE && isLesterThan(c + 1, c))
                    c++;
                if (!isLesterThan(c, k)) break;
                swap(k, c);
                k = c;
            }

        }
        private void reorderUp(int k)
        {
            while (k > 0)
            {
                int p = (k - 1) / 2;
                if (!isLesterThan(k, p))
                    break;
                swap(k, p);
                k = p;
            }

        }
        private void swap(int i, int j)
        {
            object temp = data[i];
            data[i] = data[j];
            data[j] = temp;

        }
        private bool isLesterThan(int i, int j)
        {
            return ((IComparable)data[i]).CompareTo(data[j]) < 0;

        }
        private void ensureCapacity()
        {
            object[] tempdata;
            if (SIZE + 1 > data.Length)
                tempdata = new object[2 * data.Length + 1];
            else if (data.Length > cap && data.Length > 2 * SIZE)
                tempdata = new object[data.Length / 2 + 1];
            else return;
            for (int i = 0; i < SIZE; i++)
                tempdata[i] = data[i];
            data = tempdata;
        }
        public static void heapSort(object[] x)
        {
            BinaryMinHeap h = new BinaryMinHeap(0);
            h.data = x;
            h.SIZE = x.Length;
            for (int k = h.size() - 1; k >= 0; k--)
                h.reorderDown(k);
            for (int k = h.size() - 1; k > 0; k--)
                x[k] = h.dequeue();
        }
    }

}
