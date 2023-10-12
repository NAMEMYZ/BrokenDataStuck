using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface Queue
    {
        bool isEmpty();
        int size();
        void enqueue(object e);
        object dequeue();
        object peek();
    }
}
