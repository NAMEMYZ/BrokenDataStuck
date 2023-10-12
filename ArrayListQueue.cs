using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    public class ArrayListQueue : Queue
    {
        private List list;
        public ArrayListQueue(int cap)
        {
            list = new ArrayList(cap);
        }
        public object dequeue()
        {
            object e = peek();
            list.remove(e);
            return e;
        }

        public void enqueue(object e)
        {
            list.add(e);
        }

        public bool isEmpty()
        {
            return list.isEmpty();
        }

        public object peek()
        {
            if (isEmpty())
                throw new System.MissingMemberException();
            return list.get(0);
        }

        public int size()
        {
            return list.size();
        }
    }
}
