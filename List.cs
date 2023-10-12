using System;
using ConsoleApp1;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    public interface List : Collection
    {
        void add(int index, object e);
        void remove(int index);
        object get(int index);
        void set(int index, object e);
        int indexOf(object e);

    }
}
