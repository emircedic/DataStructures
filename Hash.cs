namespace DataStructures
{
    // Look up other collision handling techniques: https://darsh-patel.hashnode.dev/collision-handling-techniques-in-hashing-you-need-to-know

    public class Node
    {
        public int Key { get; set; }
        public int Value { get; set; }

        public Node(int key, int value)
        {
            Key = key;
            Value = value;
        }
    }
    public class HashMap
    {
        private int _capacity { get; set; }
        private int _size { get; set; }
        private Node[] _hashMap { get; set; }

        private int Hash(int key)
        {
            return key.GetHashCode() % _capacity;
        }

        public HashMap(int capacity)
        {
            _capacity = capacity;
            _size = 0;
            _hashMap = new Node[_capacity];
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
                    var node = new Node(key, value);
                    _hashMap[hashValue] = node;

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
                    _hashMap[hashValue] = null;
                    _size--;
                    return true;
                }
            }
        }

        public int GetSize()
        {
            return _size;
        }

        public int GetCapacity()
        {
            return _capacity;
        }

        public void Resize()
        {
            // Update capacity.
            _capacity *= 2;

            // Create a copy of the old hash map and set its old instance to a new hash map with double the capacity.
            Node[] oldHashMap = _hashMap;
            _hashMap = new Node[_capacity];

            // Set the size to 0 and increment it while re-adding the existing hash map values.
            _size = 0;

            // Iterate through old hash map.
            foreach (Node node in oldHashMap)
            {
                if (node == null)
                    continue;

                var hashValue = Hash(node.Key);
                _hashMap[hashValue] = node;
                _size++;
            }
        }
    }

}
