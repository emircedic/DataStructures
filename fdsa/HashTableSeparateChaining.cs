namespace DataStructures;

public class Entry<K, V>
{
    public K Key { get; set; }
    public V Value { get; set; }
    public int Hash { get; set; }

    public Entry(K key, V value)
    {
        Key = key;
        Value = value;
        Hash = Key.GetHashCode();
    }

    public bool Equals(Entry<K, V> other)
    {
        return Hash == other.Hash && Key.Equals(other.Key);
    }

    public override String ToString()
    {
        return Key + " => " + Value;
    }
}

public class HashTableSeperateChaining<K, V>
{
    private static readonly int _defaultCapacity = 3;
    private static readonly double _defaultLoadFactor = 0.75;

    private double _maxLoadFactor;
    private int _capacity, _threshold, _size = 0;
    private List<Entry<K, V>>?[] _table;

    public HashTableSeperateChaining()
        : this(_defaultCapacity, _defaultLoadFactor)
    {
    }

    public HashTableSeperateChaining(int capacity)
        : this(capacity, _defaultLoadFactor)
    {
    }

    public HashTableSeperateChaining(int capacity, double maxLoadFactor)
    {
        if (capacity < 0)
            throw new ArgumentOutOfRangeException(nameof(capacity));

        if (maxLoadFactor <= 0)
            throw new ArgumentOutOfRangeException(nameof(maxLoadFactor));

        _maxLoadFactor = maxLoadFactor;
        _capacity = Math.Max(_defaultCapacity, capacity);
        _threshold = (int)(_capacity * _maxLoadFactor);
        _table = new List<Entry<K, V>>[_capacity];
    }

    public int Size() => _size;

    public bool IsEmpty() => _size == 0;

    private int NormalizeIndex(int keyHash) => (keyHash & 0x7FFFFFFF) & _capacity;

    public void Clear()
    {
        Array.Clear(_table);
        _size = 0;
    }

    public bool ContainsKey(K key) => HasKey(key);

    public bool HasKey(K key)
    {
        int bucketIndex = NormalizeIndex(key.GetHashCode());
        return BucketSeekEntry(bucketIndex, key) != null;
    }

    public V? Put(K key, V value) => Insert(key, value);

    public V? Add(K key, V value) => Insert(key, value);

    public V? Insert(K key, V value)
    {
        if (key == null)
            throw new ArgumentNullException(nameof(key));

        Entry<K, V> newEntry = new Entry<K, V>(key, value);
        int bucketIndex = NormalizeIndex(newEntry.Hash);
        return BucketInsertEntry(bucketIndex, newEntry);
    }

    public V? Get(K key)
    {
        if (key == null)
            return default;

        int bucketIndex = NormalizeIndex(key.GetHashCode());
        Entry<K, V>? entry = BucketSeekEntry(bucketIndex, key);

        return entry != null ? entry.Value : default;
    }

    public V? Remove(K key)
    {
        if (key == null)
            return default;

        int bucketIndex = NormalizeIndex(key.GetHashCode());
        return BucketRemoveEntry(bucketIndex, key);
    }

    private V? BucketRemoveEntry(int bucketIndex, K key)
    {
        Entry<K, V>? entry = BucketSeekEntry(bucketIndex, key);

        if (entry != null)
        {
            List<Entry<K, V>> links = _table[bucketIndex];
            links.Remove(entry);

            _size--;

            return entry.Value;
        }

        return default;
    }

    private V? BucketInsertEntry(int bucketIndex, Entry<K, V> entry)
    {
        List<Entry<K, V>> bucket = _table[bucketIndex];

        if (bucket == null)
            _table[bucketIndex] = bucket = new List<Entry<K, V>>();

        Entry<K, V> existentEntry = BucketSeekEntry(bucketIndex, entry.Key);

        if (existentEntry == null)
        {
            bucket.Add(entry);
            if (++_size > _threshold)
                ResizeTable();

            return default;
        }
        else
        {
            V oldValue = existentEntry.Value;
            existentEntry.Value = entry.Value;
            return oldValue;
        }
    }

    private void ResizeTable()
    {
        _capacity *= 2;
        _threshold = (int)(_capacity * _maxLoadFactor);

        List<Entry<K, V>>[] newTable = new List<Entry<K, V>>[_capacity];

        for (int i = 0; i < _table.Length; i++)
        {
            if (_table[i] != null)
            {
                foreach (var entry in _table[i])
                {
                    int bucketIndex = NormalizeIndex(entry.Hash);

                    List<Entry<K, V>> bucket = newTable[bucketIndex];

                    if (bucket == null)
                        newTable[bucketIndex] = bucket = new List<Entry<K, V>>();

                    bucket.Add(entry);
                }

                _table[i].Clear();
            }
        }

        _table = newTable;
    }

    private Entry<K, V>? BucketSeekEntry(int bucketIndex, K key)
    {
        if (key == null)
            return null;

        List<Entry<K, V>>? bucket = _table[bucketIndex];

        if (bucket == null)
            return null;

        foreach (var entry in bucket)
        {
            if (entry.Key.Equals(key))
                return entry;
        }

        return null;
    }
}
