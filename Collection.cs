namespace ConsoleApp1
{
    public interface Collection
    {
        void add(object e);
        void remove(object e);
        bool contains(object e);
        int size();
        bool isEmpty();
    }
}
