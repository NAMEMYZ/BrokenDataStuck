using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection
{
    public class LinkedStack : Stack
    {
        public class LinkedNode
        {
            public object e;
            public LinkedNode next;
            public LinkedNode(object e, LinkedNode next)
            {
                this.e = e;
                this.next = next;
            }
        }


        private LinkedNode first;
        private int SIZE;
        public bool isEmpty()
        {
            return SIZE == 0;

        }

        public object peek()
        {
            if (isEmpty())
                throw new System.MissingMemberException();
            return first.e;

        }

        public object pop()
        {
            object e = peek();
            first = first.next;
            SIZE--;
            return e;

        }

        public void push(object e)
        {
            first = new LinkedNode(e, first);
            SIZE++;

        }

        public int size()
        {
            return SIZE;

        }
    }
}