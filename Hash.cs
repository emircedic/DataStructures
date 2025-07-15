namespace DataStructures
{
    // Look up other collision handling techniques: https://darsh-patel.hashnode.dev/collision-handling-techniques-in-hashing-you-need-to-know

    #region HashSet

    // HashSet implementation using open-addressing.
    public class HashSetOpenAddressing
    {
        int _size;
        int _capacity;

        NodeSetOpenAddressing[] _hashSet;

        public HashSetOpenAddressing()
        {
            _size = 0;
            _capacity = 2;

            _hashSet = new NodeSetOpenAddressing[_capacity];
        }

        public void Add(int key)
        {
            var hashCode = Math.Abs(key.GetHashCode() % _capacity);

            var newNode = new NodeSetOpenAddressing(key);

            while (true)
            {
                if (_hashSet[hashCode] == null || _hashSet[hashCode]?.Key == key)
                {
                    _hashSet[hashCode] = newNode;
                    break;
                }
                else
                {
                    hashCode = Math.Abs((hashCode + 1) % _capacity);
                    continue;
                }
            }

            _size++;

            if (_size >= _capacity / 2)
            {
                _capacity = _capacity * 2;
                _size = 0;

                var oldHashSet = _hashSet;
                _hashSet = new NodeSetOpenAddressing[_capacity];

                for (int i = 0; i < oldHashSet.Length; i++)
                {
                    if (oldHashSet[i] != null)
                        Add(oldHashSet[i].Key);
                }

            }
        }

        public void Remove(int key)
        {
            var hashCode = Math.Abs(key.GetHashCode() % _capacity);

            while (true)
            {
                if (_hashSet[hashCode] == null)
                    return;
                else if (_hashSet[hashCode].Key != key)
                {
                    hashCode = Math.Abs((hashCode + 1) % _capacity);
                    continue;
                }
                else
                {
                    _hashSet[hashCode].Key = -1;
                    _size--;
                    return;
                }
            }
        }

        public bool Contains(int key)
        {
            var hashCode = Math.Abs(key.GetHashCode() % _capacity);

            while (true)
            {
                if (_hashSet[hashCode] == null)
                    return false;
                else if (_hashSet[hashCode].Key == key)
                    return true;
                else
                {
                    hashCode = Math.Abs((hashCode + 1) % _capacity);
                    continue;
                }
            }

            return false;
        }
    }
    public class NodeSetOpenAddressing
    {
        public int Key { get; set; }

        public NodeSetOpenAddressing(int key)
        {
            Key = key;
        }
    }


    // HashSet implementation using seperate-chaining.
    public class HashSetSeperateChaining
    {

        private int _capacity { get; set; }
        private int _size { get; set; }
        private NodeSetSeperateChaining[] _hashSet;

        public HashSetSeperateChaining()
        {
            _capacity = 2;
            _size = 0;
            _hashSet = new NodeSetSeperateChaining[_capacity];
        }

        private int GetHash(int key) => key.GetHashCode() % _capacity;

        private void Resize()
        {
            _capacity *= 2;

            var oldHashSet = _hashSet;

            _hashSet = new NodeSetSeperateChaining[_capacity];

            _size = 0;

            foreach (NodeSetSeperateChaining node in oldHashSet)
            {
                if (node == null)
                    continue;

                var tempNode = node;

                while (tempNode != null)
                {
                    Add(tempNode.Key);
                    tempNode = tempNode.Next;
                }
            }
        }

        public void Add(int key)
        {
            var hashValue = GetHash(key);

            // Create a new node entry for new key.
            var newNode = new NodeSetSeperateChaining(key);

            // #1 - The specified position already has a value.
            if (_hashSet[hashValue] != null)
            {
                // Get last Node instance in the chain.
                var nodeEntry = _hashSet[hashValue];

                while (nodeEntry.Next != null)
                {
                    // Check if specified entry already exists.
                    if (nodeEntry.Key == key)
                        return;

                    nodeEntry = nodeEntry.Next;
                }

                // Check if specified entry already exists for last entry since it couldnt be checked in while loop.
                if (nodeEntry.Key == key)
                    return;

                // Attach the new node to the chain.
                nodeEntry.Next = newNode;
                newNode.Previous = nodeEntry;
            }
            // #2 - The specified position is empty.
            else
            {
                _hashSet[hashValue] = newNode;
            }

            // Increment size.
            _size++;

            // Check if resize should be done.
            if (_size >= (_capacity / 2))
                Resize();
        }

        public void Remove(int key)
        {
            var hashValue = GetHash(key);

            // Get the first node entry.
            var nodeEntry = _hashSet[hashValue];

            // Keep iterating in the chain until we reach the correct entry.
            while (nodeEntry != null)
            {
                if (nodeEntry.Key == key)
                {
                    if (nodeEntry.Previous != null)
                        nodeEntry.Previous.Next = nodeEntry.Next;

                    if (nodeEntry.Next != null)
                        nodeEntry.Next.Previous = nodeEntry.Previous;

                    // Covers case where the specified entry is first in the chain.
                    if (_hashSet[hashValue].Key == nodeEntry.Key)
                        _hashSet[hashValue] = nodeEntry.Next;

                    _size--;
                    break;
                }

                // Increment to next entry in chain.
                nodeEntry = nodeEntry.Next;
            }
        }

        public bool Contains(int key)
        {

            var hashValue = GetHash(key);
            var nodeEntry = _hashSet[hashValue];

            while (nodeEntry != null)
            {
                if (nodeEntry.Key == key)
                    return true;

                nodeEntry = nodeEntry.Next;
            }

            return false;
        }
    }
    public class NodeSetSeperateChaining
    {
        public int Key { get; set; }
        public NodeSetSeperateChaining Previous { get; set; }
        public NodeSetSeperateChaining Next { get; set; }

        public NodeSetSeperateChaining(int key)
        {
            Key = key;
        }
    }

    #endregion

    #region HashMap

    // Hashmap implementation using open-addressing.
    public class HashMapOpenAddressing
    {
        private int _capacity { get; set; }
        private int _size { get; set; }
        private NodeMapSeperateChaining[] _hashMap { get; set; }

        private int Hash(int key)
        {
            return key.GetHashCode() % _capacity;
        }

        public HashMapOpenAddressing(int capacity)
        {
            _capacity = capacity;
            _size = 0;
            _hashMap = new NodeMapSeperateChaining[_capacity];
        }

        public void Insert(int key, int value)
        {
            var hashValue = Hash(key);

            // There are three options while trying to add a new value:
            while (true)
            {
                // 1. The specified hash value location is free.
                if (_hashMap[hashValue] == null)
                {
                    // Insert new value.
                    _hashMap[hashValue] = new NodeMapSeperateChaining(key, value);
                    _size++;

                    // Check if the hash map should be resized.
                    if (_size >= (_capacity / 2))
                        Resize();

                    return;
                }

                // 2. The specified hash value is occupied with the same key.
                else if (_hashMap[hashValue].Key == key)
                {
                    // Update the existing entry with new value.
                    _hashMap[hashValue].Value = value;
                    return;
                }

                // 3. The specified hash value is occupied with a different key.
                else if (_hashMap[hashValue].Key != key)
                {
                    // Try to insert at the next position but be careful of exceeding the max capacity.
                    hashValue = (hashValue + 1) % _capacity;
                    continue;
                }
            }
        }

        public int Get(int key)
        {
            var hashValue = Hash(key);

            // While retrieving a value from hash map, there are three possible options:
            while (true)
            {
                // 1. The location specified by hash has no value which means the specified entry does not exist.
                if (_hashMap[hashValue] == null)
                    break;

                // 2. The location specified by hash has a different value than the key.
                else if (_hashMap[hashValue].Key != key)
                {
                    hashValue = (hashValue + 1) % _capacity;
                    continue;
                }

                // 3. The location specified by hash has the same value as the key.
                else if (_hashMap[hashValue].Key == key)
                    return _hashMap[hashValue].Value;
            }

            return -1;
        }

        public bool Remove(int key)
        {

            var hashValue = Hash(key);

            while (true)
            {
                if (_hashMap[hashValue] == null)
                    return false;
                else if (_hashMap[hashValue].Key != key)
                {
                    hashValue = (hashValue + 1) % _capacity;
                    continue;
                }
                else if (_hashMap[hashValue].Key == key)
                {
                    // Set tombstone to not break open addressing.
                    _hashMap[hashValue] = new NodeMapSeperateChaining(-1, -1);
                    _size--;
                    return true;
                }
            }

            return false;
        }

        public int GetSize() => _size;

        public int GetCapacity() => _capacity;

        public void Resize()
        {
            // Double the capacity.
            _capacity *= 2;

            // Reset the size to 0.
            // Will increase while we re-add the items from the old hash map.
            _size = 0;

            // Create a new reference to the old hash map.
            NodeMapSeperateChaining[] oldHashMap = _hashMap;

            // Set the old reference to a new empty array. 
            _hashMap = new NodeMapSeperateChaining[_capacity];

            // Iterate through the old hash map.
            foreach (NodeMapSeperateChaining node in oldHashMap)
            {
                if (node == null)
                    continue;

                Insert(node.Key, node.Value);
            }
        }
    }
    public class NodeMapOpenAddressing
    {
        public int Key { get; set; }
        public int Value { get; set; }

        public NodeMapOpenAddressing(int key, int value)
        {
            Key = key;
            Value = value;
        }
    }


    // Hashmap implementation using seperate-chaining.
    public class HashMapSeperateChaining
    {
        int _capacity;
        int _count;

        NodeMapSeperateChaining[] _hashMap;


        public HashMapSeperateChaining()
        {
            _capacity = 1000000;
            _count = 0;

            _hashMap = new NodeMapSeperateChaining[_capacity];
        }

        public void Put(int key, int value)
        {
            var hashCode = Math.Abs(key.GetHashCode() % _capacity);

            var newNode = new NodeMapSeperateChaining(key, value);

            if (_hashMap[hashCode] == null)
            {
                _hashMap[hashCode] = newNode;
                _count++;
            }
            else
            {
                var currentNode = _hashMap[hashCode];

                while (true)
                {
                    if (currentNode.Key == key)
                    {
                        currentNode.Value = value;
                        return;
                    }
                    else if (currentNode.Next != null)
                    {
                        currentNode = currentNode.Next;
                        continue;
                    }
                    else
                        break;
                }

                currentNode.Next = newNode;
                newNode.Previous = currentNode;
                _count++;
            }

            if (_count >= _capacity / 2)
                Resize();
        }

        public int Get(int key)
        {
            var hashCode = Math.Abs(key.GetHashCode() % _capacity);

            if (_hashMap[hashCode] != null)
            {
                var currentNode = _hashMap[hashCode];

                while (currentNode != null)
                {
                    if (currentNode.Key == key)
                        return currentNode.Value;
                    else
                        currentNode = currentNode.Next;
                }
            }

            return -1;
        }

        public void Remove(int key)
        {
            var hashCode = Math.Abs(key.GetHashCode() % _capacity);

            if (_hashMap[hashCode] != null)
            {
                if (_hashMap[hashCode].Key == key)
                {
                    _hashMap[hashCode] = _hashMap[hashCode].Next;

                    if (_hashMap[hashCode] != null)
                        _hashMap[hashCode].Previous = null;

                    _count--;
                }
                else
                {
                    var currentNode = _hashMap[hashCode];

                    while (currentNode != null)
                    {
                        if (currentNode.Key == key)
                        {
                            currentNode.Previous.Next = currentNode.Next;

                            if (currentNode.Next != null)
                                currentNode.Next.Previous = currentNode.Previous;

                            _count--;
                        }
                        else
                            currentNode = currentNode.Next;
                    }
                }
            }
        }

        private void Resize()
        {
            _capacity = _capacity * 2;
            _count = 0;

            var oldHashMap = _hashMap;
            _hashMap = new NodeMapSeperateChaining[_capacity];

            for (int i = 0; i < oldHashMap.Length; i++)
            {
                if (oldHashMap[i] != null)
                {
                    var currentNode = oldHashMap[i];

                    while (currentNode != null)
                    {
                        Put(currentNode.Key, currentNode.Value);
                        currentNode = currentNode.Next;
                    }
                }
            }
        }
    }

    public class NodeMapSeperateChaining
    {
        public int Key;
        public int Value;

        public NodeMapSeperateChaining Previous;
        public NodeMapSeperateChaining Next;

        public NodeMapSeperateChaining(int key, int value)
        {
            Key = key;
            Value = value;
        }
    }

    #endregion
}
