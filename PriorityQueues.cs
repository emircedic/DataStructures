namespace DataStructures
{
    public class PriorityQueue<T>
    {
        // List to track the elemnents
        private List<T> _heap = new List<T>();

        /// <summary>
        /// Adds elements and enforces the heap invariant.
        /// </summary>
        public PriorityQueue(List<T> elements)
        {
            _heap.AddRange(elements);

            for (int i = Math.Max(0, (elements.Count / 2) - 1); i >= 0; i--)
                Sink(i);
        }

        /// <summary>
        /// Returns boolean representation if there are any elements.
        /// </summary>
        public bool IsEmpty()
        {
            return _heap.Count == 0;
        }

        /// <summary>
        /// Removes all elements.
        /// </summary>
        public void Clear()
        {
            _heap.Clear();
        }

        /// <summary>
        /// Returns current count of elements.
        /// </summary>
        public int Size()
        {
            return _heap.Count;
        }

        /// <summary>
        /// Returns the element with the lowest priority.
        /// </summary>
        public T Peek()
        {
            if (IsEmpty())
                return default;

            return _heap.First();
        }

        /// <summary>
        /// Removes and returns the element with the lowest priority.
        /// </summary>
        public T Poll()
        {
            var lowestPriorityElement = _heap.First();
            RemoveAt(0);
            return lowestPriorityElement;
        }

        /// <summary>
        /// Returns boolean representation if the provided element is contained within the list.
        /// </summary>
        public bool Contains(T element)
        {
            return _heap.Contains(element);
        }

        /// <summary>
        /// Adds provided element and enforces heap variant.
        /// </summary>
        public void Add(T element)
        {
            if (element == null)
                throw new Exception();

            _heap.Add(element);

            int indexOfLastElement = Size() - 1;
            Swim(indexOfLastElement);
        }

        /// <summary>
        /// Removes specified element.
        /// Returns true if element was found and removed.
        /// Returns false if element is not found.
        /// </summary>
        public bool Remove(T element)
        {
            if (element == null)
                throw new Exception();

            if (!_heap.Contains(element))
                return false;

            RemoveAt(_heap.IndexOf(element));
            return true;
        }

        /// <summary>
        /// Checks if the heap variant is enforced.
        /// </summary>
        public bool CheckMinHeapVariant(int k)
        {
            int heapSize = Size();

            // If we are outside the bounds of the heap return true (Min Heap Variant is satisfied).
            if (k >= heapSize)
                return true;

            int leftNode = 2 * k + 1;
            int rightNode = 2 * k + 2;

            // Check if current node is smaller than left child node. Return false if it is not.
            if (leftNode < heapSize && Convert.ToInt32(_heap[k]) > Convert.ToInt32(_heap[leftNode]))
                return false;

            // Check if current node is smaller than right child node. Return false if it is not.
            if (rightNode < heapSize && Convert.ToInt32(_heap[k]) > Convert.ToInt32(_heap[rightNode]))
                return false;

            // Recurse on both child nodes to make sure that heap variant is satisfied for them as well.
            return CheckMinHeapVariant(leftNode) && CheckMinHeapVariant(rightNode);
        }

        /// <summary>
        /// Moves the current element up the tree until the heap variant is satisfied.
        /// </summary>
        private void Swim(int k)
        {
            // Get index of the parent node
            int parent = (k - 1) / 2;

            // Keep swimming until we either reach the root or the heap variant is satisfied
            while (k > 0 && Convert.ToInt32(_heap[k]) < Convert.ToInt32(_heap[parent]))
            {
                Swap(parent, k);
                k = parent;

                parent = (k - 1) / 2;
            }
        }

        /// <summary>
        /// Moves the current element down the tree until the heap variant is satisfied.
        /// </summary>
        private void Sink(int k)
        {
            int heapCount = Size();

            while (true)
            {
                // Left child node
                int leftNode = 2 * k + 1;

                // Right child node
                int rightNode = 2 * k + 2;

                // Define which child node is smaller
                int smallerNode = rightNode < heapCount && Convert.ToInt32(_heap[rightNode]) < Convert.ToInt32(_heap[leftNode]) ? rightNode : leftNode;

                // Stop execution if we are outisde bounds of the tree or if we cannot sink "k" anymore
                if (leftNode >= heapCount || Convert.ToInt32(_heap[k]) < Convert.ToInt32(_heap[smallerNode]))
                    break;

                Swap(smallerNode, k);
                k = smallerNode;
            }
        }

        /// <summary>
        /// Swaps positions of two elements using provided index values.
        /// </summary>
        private void Swap(int i, int j)
        {
            T elementI = _heap[i];
            T elementJ = _heap[j];

            _heap[i] = elementJ;
            _heap[j] = elementI;
        }

        /// <summary>
        /// Removes element at specified index and enforces the heap variant.
        /// </summary>
        private T RemoveAt(int i)
        {
            if (IsEmpty())
                return default;

            int indexOfLastElement = Size() - 1;
            T removedData = _heap[i];

            Swap(i, indexOfLastElement);

            _heap.RemoveAt(indexOfLastElement);

            // Check if the provided index of element to be removed is the last element
            // In this case the heap variant is already enforced
            if (i == indexOfLastElement)
                return removedData;

            T element = _heap[i];

            // Try sinking the element
            Sink(i);

            // Check if sinking was successfull and try swimming if it was not.
            if (_heap[i].Equals(element))
                Swim(i);

            return removedData;
        }
    }
}
