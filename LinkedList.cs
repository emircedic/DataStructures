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

        public void AddAtIndex(int index, int val)
        {
            if (index > _nodeCount)
                return;
            else if (index == 0)
                AddAtHead(val);
            else if (index == _nodeCount)
                AddAtTail(val);
            else
            {
                var previousNode = _headNode;
    
                for (int i = 0; i < index - 1; i++)
                    previousNode = previousNode.Next;
    
                var nextNode = previousNode.Next;
    
                var newNode = new Node(val);
                
                previousNode.Next = newNode;
                newNode.Next = nextNode;
    
                _nodeCount++;
            }
        }
        
        public bool RemoveAtIndex(int index)
        {
            if (index >= _nodeCount)
                return false;
    
            if (index == 0)
            {
                _headNode = _headNode.Next;
    
                if (_headNode == null)
                    _tailNode = null;
            }   
            else if (index == _nodeCount - 1)
            {
                var previousNode = _headNode;
                for (int i = 0; i < _nodeCount - 2; i++)
                    previousNode = previousNode.Next;
    
                _tailNode = previousNode;
                _tailNode.Next = null;
            }
            else
            {
                var previousNode = _headNode;
                for (int i = 0; i < index - 1; i++)
                    previousNode = previousNode.Next;
    
                previousNode.Next = previousNode.Next?.Next;
            }
    
            _nodeCount--;
            
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
        public DoublyLinkedListNode Previous { get; set; }
        public DoublyLinkedListNode Next { get; set; }
    
        public DoublyLinkedListNode(int value)
        {
            Value = value;
        }
    }

    public class DoublyLinkedList
    {
        DoublyLinkedListNode _headNode;
        DoublyLinkedListNode _tailNode;
    
        int _nodeCount;
    
        public DoublyLinkedList() {}
    
        public int Get(int index)
        {
            if (index >= _nodeCount)
                return -1;
    
            var currentNode = _headNode;
            for (int i = 0; i < index; i++)
                currentNode = currentNode.Next;
    
            return currentNode.Value;    
        }
        
        public void AddAtHead(int val)
        {
            var newNode = new DoublyLinkedListNode(val);
    
            if (_headNode == null)
            {
                _headNode = newNode;
                _tailNode = newNode;
            }
            {
                newNode.Next = _headNode;
                _headNode.Previous = newNode;
    
                _headNode = newNode;
            }
    
            _nodeCount += 1;    
        }
        
        public void AddAtTail(int val)
        {
            var newNode = new DoublyLinkedListNode(val);
    
            if (_tailNode == null)
            {
                _tailNode = newNode;
                _headNode = newNode;
            }
            else
            {
                newNode.Previous = _tailNode;
                _tailNode.Next = newNode;
    
                _tailNode = newNode;
            }
    
            _nodeCount += 1;
        }
        
        public void AddAtIndex(int index, int val)
        {
            if (index > _nodeCount)
                return;
    
            if (index == 0)
                AddAtHead(val);
            else if (index == _nodeCount)
                AddAtTail(val);
            else
            {
                var currentNode = _headNode;
                for (int i = 0; i < index; i++)
                    currentNode = currentNode.Next;
    
                var newNode = new DoublyLinkedListNode(val);
                newNode.Next = currentNode;
                newNode.Previous = currentNode.Previous;
    
                currentNode.Previous.Next = newNode;
                currentNode.Previous = newNode;
    
                _nodeCount += 1;    
            }
        }
        
        public void DeleteAtIndex(int index)
        {
            if (index >= _nodeCount)
                return;
    
            if (_nodeCount == 1)
            {
                _headNode = null;
                _tailNode = null;
            }
            else if (index == 0)
            {
                _headNode.Next.Previous = null;
                _headNode = _headNode.Next;
            }
            else if (index == _nodeCount - 1)
            {
                _tailNode.Previous.Next = null;
                _tailNode = _tailNode.Previous;
            }
            else
            {
                var currentNode = _headNode;
                for (int i = 0; i < index; i++)
                    currentNode = currentNode.Next;
    
                currentNode.Previous.Next = currentNode.Next;
                currentNode.Next.Previous = currentNode.Previous;
            }
    
            _nodeCount -= 1;    
        }
    }
}
