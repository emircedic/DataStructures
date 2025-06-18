namespace DataStructures
{
    public class SinglyLinkedListNode
    {
        public int Value { get; set; }
        public SinglyLinkedListNode Next { get; set; }

        public SinglyLinkedListNode(int value)
        {
            Value = value;
        }
    }

    public class SinglyLinkedList
    {
        SinglyLinkedListNode _headNode;
        SinglyLinkedListNode _tailNode;
        int _nodeCount;
    
        public SinglyLinkedList() {}
    
        public int Get(int index)
        {
            if (index >= _nodeCount)
                return -1;
    
            var currentNode = _headNode;
    
            for (int i = 0; i < index; i++)
                currentNode = currentNode.Next;
    
            return currentNode.Value;
        }
    
        public void InsertHead(int val)
        {
            var newNode = new SinglyLinkedListNode(val);
    
            if (_headNode == null)
            {
                _headNode = newNode;
                _tailNode = newNode;
            }
            else
            {
                newNode.Next = _headNode;
                _headNode = newNode;
            }
    
            _nodeCount++;
        }
    
        public void InsertTail(int val)
        {
            var newNode = new SinglyLinkedListNode(val);
    
            if (_tailNode == null)
            {
                _tailNode = newNode;
                _headNode = newNode;
            }
            else
            {
                _tailNode.Next = newNode;
                _tailNode = newNode;
            }
    
            _nodeCount++;
        }
    
        public bool Remove(int index)
        {
            if (index >= _nodeCount)
                return false;
    
            if (index == 0)
            {
                _headNode = _headNode.Next;
            }
            else
            {
                var currentNode = _headNode;
    
                for (int i = 0; i < index - 1; i++)
                    currentNode = currentNode.Next;
    
                if (index == _nodeCount - 1)
                {
                    currentNode.Next = null;
                    _tailNode = currentNode;
                }
                else
                {
                    currentNode.Next = currentNode.Next?.Next;
                }
            }
    
            _nodeCount--;
    
            if (_nodeCount == 0)
            {
                _headNode = null;
                _tailNode = null;
            }
    
            return true;
        }
    
        public List<int> GetValues()
        {
            List<int> values = new();
            var currentNode = _headNode;
    
            while (currentNode != null)
            {
                values.Add(currentNode.Value);
                currentNode = currentNode.Next;
            }
    
            return values;
        }
    }

    public class DoublyLinkedListNode
    {
        public int Value { get; set; }
        public DoublyLinkedListNode Prev { get; set; }
        public DoublyLinkedListNode Next { get; set; }

        public DoublyLinkedListNode(int value)
        {
            Value = value;
        }
    }

    public class DoublyLinkedList
    {
        DoublyLinkedListNode head;
        DoublyLinkedListNode tail;

        public DoublyLinkedList()
        {
            head = new DoublyLinkedListNode(-1);
            tail = new DoublyLinkedListNode(-1);
            head.Next = tail;
            tail.Prev = head;
        }

        public void InsertFront(int val)
        {
            DoublyLinkedListNode newNode = new DoublyLinkedListNode(val)
            {
                Prev = head,
                Next = head.Next
            };

            head.Next.Prev = newNode;
            head.Next = newNode;
        }

        public void InsertEnd(int val)
        {
            DoublyLinkedListNode newNode = new DoublyLinkedListNode(val)
            {
                Next = tail,
                Prev = tail.Prev
            };

            tail.Prev.Next = newNode;
            tail.Prev = newNode;
        }

        public void RemoveFront()
        {
            head.Next.Next.Prev = head;
            head.Next = head.Next.Next;
        }

        public void RemoveEnd()
        {
            tail.Prev.Prev.Next = tail;
            tail.Prev = tail.Prev.Prev;
        }

        public void Print()
        {
            DoublyLinkedListNode curr = head.Next;
            while (curr != tail)
            {
                Console.WriteLine(curr.Value + " -> ");
                curr = curr.Next;
            }
            Console.WriteLine("");
        }
    }
}
