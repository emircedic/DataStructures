namespace DataStructures
{
    public class DoublyLinkedList<T> where T : struct
    {
        public int Count { get; set; }
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }

        public void Clear()
        {
            Node<T> currentNode = Head;
            while (currentNode != null)
            {
                Node<T> tempNode = currentNode.Next;
                currentNode = null;
                currentNode = tempNode;
            }

            Count = 0;
            Head = null;
            Tail = null;
        }

        public int Size() => Count;

        public bool IsEmpty()
        {
            return Size() == 0;
        }

        public void Add(T item)
        {
            AddLast(item);
        }

        public void AddLast(T item)
        {
            // Handle case if current item is the first one
            if (IsEmpty())
            {
                var node = new Node<T>(item, null, null);
                Head = Tail = node;
            }
            else
            {
                // Handle case if list already contains multiple items
                var node = new Node<T>(item, Tail, null);
                Tail.Next = node; // Update property Next of old Tail
                Tail = node;    // Set the latest node as Tail
            }

            Count++;
        }

        public void AddFirst(T item)
        {
            if (IsEmpty())
            {
                var node = new Node<T>(item, null, null);
                Head = Tail = node;
            }
            else
            {
                var node = new Node<T>(item, null, Head);
                Head.Previous = node;
                Head = node;
            }

            Count++;
        }

        public T PeekFirst()
        {
            if (IsEmpty())
                throw new InvalidOperationException();
            else
                return Head.Value;
        }

        public T PeekLast()
        {
            if (IsEmpty())
                throw new InvalidOperationException();
            else
                return Tail.Value;
        }

        public T RemoveFirst()
        {
            if (IsEmpty())
                throw new InvalidOperationException();
            else
            {
                var secondNode = Head.Next;
                var headValue = Head.Value;
                Head = secondNode;

                if (secondNode != null)
                {
                    secondNode.Previous = null;
                }
                else
                {
                    Tail = null;
                }

                Count--;
                return headValue;
            }
        }

        public T RemoveLast()
        {
            if (IsEmpty())
                throw new InvalidOperationException();
            else
            {
                var secondToLastItem = Tail.Previous;
                var tailValue = Tail.Value;
                Tail = secondToLastItem;

                // Handle case if only one item is left
                if (secondToLastItem != null)
                {
                    secondToLastItem.Next = null;
                }
                else
                {
                    // Handle case if more than one item is left
                    Head = null;
                }

                Count--;
                return tailValue;
            }
        }

        public T Remove(Node<T> node)
        {
            if (IsEmpty())
                throw new InvalidOperationException();
            else
            {
                var value = node.Value;

                if (node.Previous == null)
                    RemoveFirst();
                else if (node.Next == null)
                    RemoveLast();
                else
                {
                    node.Previous.Next = node.Next;
                    node.Next.Previous = node.Previous;
                    Count--;
                    node = null;
                }


                return value;
            }
        }

        public T RemoveAt(int index)
        {
            if (IsEmpty() || index <= 0)
                throw new InvalidOperationException();
            else
            {
                int currentIndex = 0;
                Node<T> currentNode = null;

                // In left half of list
                if (index <= Count / 2)
                {
                    currentNode = Head;
                    for (int i = 0; i <= Count / 2; i++)
                    {
                        currentNode = currentNode.Next;
                        if (i == currentIndex)
                        {
                            break;
                        }
                    }
                }
                else if (index > Count / 2)
                {
                    // In the right half of the list
                    currentNode = Tail;
                    for (int i = Count - 1; i > Count / 2; i--)
                    {
                        currentNode = currentNode.Previous;
                        if (i == currentIndex)
                        {
                            break;
                        }
                    }
                }
                Count--;
                return Remove(currentNode);
            }
        }

        public bool Remove(T value)
        {
            if (IsEmpty())
                throw new InvalidOperationException();
            else
            {
                var currentNode = Head;

                for (int i = 0; i < Count; i++)
                {
                    if (currentNode.Value.Equals(value))
                    {
                        Remove(currentNode);
                        return true;
                    }
                    else
                        currentNode = currentNode.Next;
                }
                return false;
            }
        }

        public int IndexOf(T value)
        {
            if (IsEmpty())
                throw new InvalidOperationException();
            else
            {
                var currentNode = Head;

                for (int i = 0; i < Count; i++)
                {
                    if (currentNode.Value.Equals(value))
                    {
                        return i;
                    }
                    else
                        currentNode = currentNode.Next;
                }
                return -1;
            }
        }

        public bool Contains(T value)
        {
            return IndexOf(value) != -1;
        }
    }

    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Previous { get; set; }
        public Node<T> Next { get; set; }

        public Node(T value, Node<T> previous, Node<T> next)
        {
            Value = value;
            Previous = previous;
            Next = next;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }

    // Todo: Add custom iterator
}
