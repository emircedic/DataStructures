namespace DataStructures
{
    public class CustomQueue<T>
    {
        private List<T> items = new();

        public int Count()
        {
            return items.Count;
        }

        public bool IsEmpty()
        {
            return Count() == 0;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            return items[0];
        }

        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            var value = items[0];
            items.RemoveAt(0);
            return value;
        }

        public void Enqueue(T item)
        {
            items.Add(item);
        }
    }
}
