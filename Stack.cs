using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface Stack
    {
        bool isEmpty();
        int size();
        void push(object e);
        object pop();
        object peek();
    }
}