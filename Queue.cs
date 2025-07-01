namespace DataStructures
{
    // Time complexity:
    // Enqueue: O(1)
    // Dequeue: O(1)
     
    public class QueueWithPointers
    {
        public QueueNode Left;  // front of Queue   front -> [1,2,3]
        public QueueNode Right; // back of Queue   [1,2,3] <- back

        public QueueWithPointers()
        {
            this.Left = null;
            this.Right = null;
        }

        public void EnQueue(int val)
        {
            QueueNode newNode = new QueueNode(val);

            if (this.Right != null)
            {
                // Queue is not empty 
                this.Right.Next = newNode;
                this.Right = this.Right.Next;
            }
            else
            {
                // Queue is empty             
                this.Left = newNode;
                this.Right = newNode;
            }
        }

        public int DeQueue()
        {
            if (this.Left == null)
            {
                // Queue is empty 
                return -1;
            }

            int val = this.Left.Value;
            this.Left = this.Left.Next;

            if (this.Left == null)
                this.Right = null;

            return val;
        }

        public void Print()
        {
            QueueNode cur = this.Left;

            while (cur != null)
            {
                Console.WriteLine(cur.Value + " -> ");
                cur = cur.Next;
            }

            Console.WriteLine("");
        }
    }

    public class QueueWithList<T>
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

    public class QueueNode
    {
        public int Value;
        public QueueNode Next;

        public QueueNode(int val)
        {
            this.Value = val;
            this.Next = null;
        }
    }

    // Queue with doubly-linked nodes (Previous and Next).
    public class Deque
    {
        private DequeNode _headNode;
        private DequeNode _tailNode;
    
        private int _nodeCount;
    
        public Deque() {}
    
        public bool IsEmpty() => _nodeCount == 0;
    
        public void Append(int value)
        {
            var newNode = new DequeNode(value);
    
            if (_headNode == null && _tailNode == null)
            {
                _headNode = newNode;
                _tailNode = newNode;
            }
            else
            {
                _tailNode.Next = newNode;
                newNode.Previous = _tailNode;
    
                _tailNode = newNode;
            }
    
            _nodeCount++;
        }
    
        public void Appendleft(int value)
        {
            var newNode = new DequeNode(value);
    
            if (_headNode == null && _tailNode == null)
            {
                _headNode = newNode;
                _tailNode = newNode;
            }
            else
            {
                newNode.Next = _headNode;
                _headNode.Previous = newNode;
    
                _headNode = newNode;
            }
    
            _nodeCount++;
        }
    
        public int Pop()
        {
            if (_nodeCount > 0)
            {
                _nodeCount--;
    
                var result = _tailNode.Value;
    
                if (_tailNode.Previous != null)
                {
                    _tailNode = _tailNode.Previous;
                    _tailNode.Next = null;
                }
                else
                {
                    _tailNode = null;
                    _headNode = null;
                }
    
                return result;
            }
    
            return -1;
        }
    
        public int Popleft()
        {
            if (_nodeCount > 0)
            {
                _nodeCount--;
    
                var result = _headNode.Value;
    
                if (_headNode.Next != null)
                {
                    _headNode = _headNode.Next;
                    _headNode.Previous = null;
                }
                else
                {
                    _headNode = null;
                    _tailNode = null;
                }
    
                return result;
            }
    
            return -1;
        }
    }
    
    public class DequeNode
    {
        public DequeNode Previous { get; set; }
        public DequeNode Next { get; set; }
    
        public int Value { get; set; }
    
        public DequeNode(int value)
        {
            Value = value;
        }
    }
}
