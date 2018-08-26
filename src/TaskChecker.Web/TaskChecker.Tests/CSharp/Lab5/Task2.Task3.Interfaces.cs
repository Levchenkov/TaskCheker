namespace Lab5
{
    public interface IQueue<T>
    {
        int Count
        {
            get;
        }

        bool IsEmpty
        {
            get;
        }

        void Enqueue(T value);

        T Dequeue();

        T Peek();

        T[] ToArray();
    }
}
