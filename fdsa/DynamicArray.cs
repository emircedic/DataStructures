using System.Collections;

namespace DataStructures
{
    public class DynamicArray<T> : IEnumerable<T>
    {
        public int Count { get; set; }
        public int Capacity { get; set; }
        public T[] Values { get; set; }

        public DynamicArray(int capacity = 16)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            Count = 0;
            Capacity = capacity;
            Values = new T[capacity];
        }

        public void Clear()
        {
            for (int i = 0; i < Count; i++)
            {
                Values[i] = default(T);
            }

            Count = 0;
        }

        public void Add(T item)
        {
            if (Count + 1 >= Capacity)
            {
                // Extend array

                // Double the capacity
                Capacity *= 2;
                var extendedArray = new T[Capacity];
                for (int i = 0; i < Count; i++)
                {
                    extendedArray[i] = Values[i];
                }

                Values = extendedArray;
            }

            // Add item
            Values[Count++] = item;
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                Values[i] = Values[i + 1];
            }

            Count--;
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Values[i].Equals(item))
                {
                    RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Values[i].Equals(item))
                {
                    return i;
                }
            }


            return -1;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) == -1 ? false : true;
        }

        public override string ToString()
        {
            var result = "";

            for (int i = 0; i < Count; i++)
            {
                result += Values[i];
            }

            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new DynamicArrayEnumerator<T>(Values, Count);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

public class DynamicArrayEnumerator<T> : IEnumerator<T>
{
    private T[] _values;
    private int _count;
    private int _currentIndex;

    public DynamicArrayEnumerator(T[] values, int count)
    {
        _values = values;
        _count = count;
        _currentIndex = -1;
    }

    public T Current => _values[_currentIndex];

    object IEnumerator.Current => Current;

    public void Dispose()
    {
    }

    public bool MoveNext()
    {
        _currentIndex++;
        return _currentIndex < _count;
    }

    public void Reset()
    {
        _currentIndex = -1;
    }
}
