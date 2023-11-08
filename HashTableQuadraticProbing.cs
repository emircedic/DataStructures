namespace DataStructures
{
    public class HashTableQuadraticProbing : HashTableOpenAddressingBase<int, string>
    {
        public HashTableQuadraticProbing()
            : base()
        {
            base.Tombstone = 9999;
        }

        public HashTableQuadraticProbing(int capacity)
            : base(capacity)
        {
            base.Tombstone = 9999;
        }

        public HashTableQuadraticProbing(int capacity, int loadFactor)
            : base(capacity, loadFactor)
        {
            base.Tombstone = 9999;
        }

        protected override void SetupProbing(int key)
        {
        }

        protected override int Probe(int x)
        {
            return (x * x + x) >> 1;
        }

        protected override void AdjustCapacity()
        {
            int powerOfTwo = (int)Math.Pow(2, Convert.ToString(_capacity, 2).Length - 1);
            if (_capacity == powerOfTwo)
                return;

            IncreaseCapacity();
        }

        protected override void IncreaseCapacity()
        {
            _capacity = NextPowerOfTwo(_capacity);
        }

        private int NextPowerOfTwo(int n)
        {
            return (int)Math.Pow(2, Convert.ToString(n, 2).Length - 1) << 1;
        }
    }

    public abstract class HashTableOpenAddressingBase<K, V>
    {
        protected double _loadFactor;
        protected int _capacity, _threshold;

        protected int _usedBuckets, _keyCount;

        protected K[] _keys;
        protected V[] _values;

        protected K Tombstone = default;

        private const int DefaultCapacity = 7;
        private const double DefaultLoadFactor = 0.65;

        protected HashTableOpenAddressingBase()
            : this(DefaultCapacity, DefaultLoadFactor)
        {
        }

        protected HashTableOpenAddressingBase(int capacity)
            : this(capacity, DefaultLoadFactor)
        {

        }

        protected HashTableOpenAddressingBase(int capacity, double loadFactor)
        {
            if (capacity <= 0)
                throw new ArgumentOutOfRangeException("Illegal capacity: " + capacity);

            if (loadFactor <= 0)
                throw new ArgumentOutOfRangeException("Illegal loadFactor: " + loadFactor);

            _loadFactor = loadFactor;
            _capacity = Math.Max(DefaultCapacity, capacity);
            AdjustCapacity();

            _threshold = (int)(_capacity * loadFactor);

            _keys = new K[_capacity];
            _values = new V[_capacity];
        }

        protected abstract void SetupProbing(K key);

        protected abstract int Probe(int x);

        protected abstract void AdjustCapacity();

        protected abstract void IncreaseCapacity();

        public void Clear()
        {
            for (int i = 0; i < _capacity; i++)
            {
                _keys[i] = default;
                _values[i] = default;
            }

            _keyCount = _usedBuckets = 0;
        }

        public int Size() => _keyCount;

        public int GetCapacity() => _capacity;

        public bool IsEmpty() => _keyCount == 0;

        public V Put(K key, V value) => Insert(key, value);

        public V Add(K key, V value) => Insert(key, value);

        public bool ContainsKey(K key) => HasKey(key);

        public List<K> GetKeys()
        {
            List<K> hashTableKeys = new List<K>();

            for (int i = 0; i < _capacity; i++)
            {
                if (!_keys[i].Equals(0) && !_keys[i].Equals(Tombstone))
                    hashTableKeys.Add(_keys[i]);
            }

            return hashTableKeys;
        }

        public List<V> GetValues()
        {
            List<V> hashTableValues = new List<V>();

            for (int i = 0; i < _capacity; i++)
            {
                if (!_keys[i].Equals(0) && !_keys[i].Equals(Tombstone))
                    hashTableValues.Add(_values[i]);
            }

            return hashTableValues;
        }

        protected void ResizeTable()
        {
            IncreaseCapacity();
            AdjustCapacity();

            _threshold = (int)(_capacity * _loadFactor);

            // Save old values
            K[] oldKeyTable = _keys;
            V[] oldValueTable = _values;

            // Instantiate new arrays with expanded capacity
            _keys = new K[_capacity];
            _values = new V[_capacity];

            _keyCount = _usedBuckets = 0;

            for (int i = 0; i < oldKeyTable.Length; i++)
            {
                if (!oldKeyTable[i].Equals(0) && !oldKeyTable[i].Equals(Tombstone))
                    Insert(oldKeyTable[i], oldValueTable[i]);

                oldValueTable[i] = default;
                oldKeyTable[i] = default;
            }
        }

        protected int NormalizeIndex(int keyHasH) => (keyHasH & 0x7FFFFFFF) % _capacity;

        protected int GetGreatestCommmonDenominator(int a, int b)
        {
            if (b == 0) return a;

            return GetGreatestCommmonDenominator(b, a % b);
        }

        public V Insert(K key, V value)
        {
            if (key == null)
                throw new ArgumentNullException("Null key");

            if (_usedBuckets >= _threshold)
                ResizeTable();

            SetupProbing(key);

            int offset = NormalizeIndex(key.GetHashCode());

            for (int i = offset, j = -1, x = 1; ; i = NormalizeIndex(offset + Probe(x++)))
            {
                // Checks if current position is a Tombstone and saves a reference to it
                if (_keys[i].Equals(Tombstone))
                {
                    if (j == -1)
                        j = i;
                }
                // The current position contains a key
                else if (!_keys[i].Equals(0))
                {
                    // The key we are trying to insert already exist so we just update the value
                    if (_keys[i].Equals(key))
                    {
                        V oldValue = _values[i];

                        // No tombstone was found while iterating to find free space
                        if (j == -1)
                            _values[i] = value;
                        else
                        {
                            // Set current position with value to Tombstone
                            _keys[i] = Tombstone;
                            _values[i] = default;

                            // Move the value to location of where the Tombstone was found
                            _keys[j] = key;
                            _values[j] = value;
                        }

                        return oldValue;
                    }
                }
                else
                {
                    // No Tombstone was found while searching for a free slot
                    if (j == -1)
                    {
                        _usedBuckets++;
                        _keyCount++;

                        _keys[i] = key;
                        _values[i] = value;
                    }
                    // Tombstone was found while searching for a free slot
                    else
                    {
                        _keyCount++;
                        _keys[j] = key;
                        _values[j] = value;
                    }

                    return default;
                }
            }
        }

        public bool HasKey(K key)
        {
            if (key == null)
                throw new ArgumentOutOfRangeException("Null key");

            SetupProbing(key);

            int offset = NormalizeIndex(key.GetHashCode());

            for (int i = offset, j = -1, x = 1; ; i = NormalizeIndex(offset + Probe(x++)))
            {
                // Set first location of a Tombstone so that optimization can be preformed
                if (_keys[i].Equals(Tombstone))
                {
                    if (j == -1)
                        j = i;
                }
                // We found a non-null value which could possibly be the one we are looking for
                else if (!_keys[i].Equals(0))
                {
                    // We found the key we are looking for
                    if (_keys[i].Equals(key))
                    {
                        // Optimize hashtable by moving the found value to the first Tombstone location found while searching
                        if (j != -1)
                        {
                            _keys[j] = _keys[i];
                            _values[j] = _values[i];

                            _keys[i] = Tombstone;
                            _values[i] = default;
                        }

                        return true;
                    }
                }
                else
                    return false;
            }
        }

        public V Get(K key)
        {
            if (key == null)
                throw new ArgumentOutOfRangeException("Null key");

            int offset = NormalizeIndex(key.GetHashCode());

            for (int i = offset, j = -1, x = 1; ; i = NormalizeIndex(offset + Probe(x++)))
            {
                // Set first location of a Tombstone so that optimization can be preformed
                if (_keys[i].Equals(Tombstone))
                {
                    if (j == -1)
                        j = i;
                }
                // We found a non-null value which could possibly be the one we are looking for
                else if (!_keys[i].Equals(0))
                {
                    // We found the key we are looking for
                    if (_keys[i].Equals(key))
                    {
                        // Optimize hashtable by moving the found value to the first Tombstone location found while searching
                        if (j != -1)
                        {
                            _keys[j] = _keys[i];
                            _values[j] = _values[i];

                            _keys[i] = Tombstone;
                            _values[i] = default;

                            return _values[j];
                        }
                        else
                            return _values[i];
                    }
                }
                else
                    return default;
            }
        }

        public V Remove(K key)
        {
            if (key == null)
                throw new ArgumentOutOfRangeException("Null key");

            int offset = NormalizeIndex(key.GetHashCode());

            for (int i = offset, x = 1; ; i = NormalizeIndex(offset + Probe(x++)))
            {
                // Ignore Tombstones
                if (_keys[i].Equals(Tombstone))
                    continue;

                // Null value found which means provided key could not be found
                if (_keys[i].Equals(0))
                    return default;

                if (_keys[i].Equals(key))
                {
                    _keyCount--;
                    V oldValue = _values[i];

                    _keys[i] = Tombstone;
                    _values[i] = default;

                    return oldValue;
                }
            }



        }
    }
}
