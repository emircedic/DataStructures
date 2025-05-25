namespace DataStructures
{
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
}
