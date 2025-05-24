namespace DataStructures;

public class UnionFind
{
    /// <summary>
    /// Defines the number of elements in current union find.
    /// </summary>
    private int _elementCount;

    /// <summary>
    /// Defines the number of elements in each component (grouping).
    /// </summary>
    private int[] _elementCountPerComponent;

    /// <summary>
    /// Defines the number of components (groups) in the union find.
    /// </summary>
    private int _componentCount;

    /// <summary>
    /// Represents the union find where the array index is used to represent the mapped value of a thing and the actual array value the grouping.
    /// If the array index and array value is the same, it means the parent of a grouping is reached (that specific object in the array is used to define the grouping).
    /// Lets say we have the following values "A", "B", "C". We would map the values in following way: "A" = 0, "B" = 1, "C" = 2 and therefore the value "A" would always be the first element in the array.
    /// The only thing that would change would the underlaying value of that first position to represent the grouping it belongs to. The array indexes are used for that.
    /// Example if value "A" belongs to a group where "C" is the parent represeting the group -> Array[0] = 2.
    /// </summary>
    private int[] _id;

    public UnionFind(int size)
    {
        if (size <= 0)
            throw new Exception("Size must be greater than 0.");

        _elementCount = size;

        // Number of components (groupings) is always reducing since we start out where each element has its own gropuing.
        _componentCount = size;

        _id = new int[size];
        _elementCountPerComponent = new int[size];

        // Set so that each element has its own unique component (grouping).
        for (int i = 0; i < size; i++)
        {
            _id[i] = i;
            _elementCountPerComponent[i] = 1;
        }
    }

    /// <summary>
    /// Returns the grouping of provided value (index).
    /// The group is represented as the array index of the parent. The parent per group is the element which has the same value and index.
    /// </summary>
    public int Find(int p)
    {
        // Find the root of provided value.
        int root = p;
        while (root != _id[root])
            root = _id[root];

        // Path compression => all elements of a group should point directly to the root.
        while (p != root)
        {
            int next = _id[p];
            _id[p] = root;

            p = next;
        }

        return root;
    }

    /// <summary>
    /// Checks if the provided values are connected/belong to the same group.
    /// </summary>
    public bool AreConnected(int p, int q)
    {
        return Find(p) == Find(q);
    }

    /// <summary>
    /// Returns the size of component (group) to which the provided element belongs to.
    /// </summary>
    public int GetComponentSize(int p)
    {
        var component = Find(p);
        return _elementCountPerComponent[component];
    }

    /// <summary>
    /// Returns the total number of elements.
    /// </summary>
    public int GetElementCount()
    {
        return _elementCount;
    }

    /// <summary>
    /// Returns the total number of components (grouping).
    /// </summary>
    public int GetComponentCount()
    {
        return _componentCount;
    }

    /// <summary>
    /// Unifies two the components to which the provided values belong to.
    /// The smaller one is merged into the bigger one.
    /// </summary>
    public void Unify(int p, int q)
    {
        if (AreConnected(p, q))
            return;

        int rootOne = Find(p);
        int rootTwo = Find(q);

        if (_elementCountPerComponent[rootOne] < _elementCountPerComponent[rootTwo])
        {
            _id[rootOne] = rootTwo;
            _elementCountPerComponent[rootTwo] += _elementCountPerComponent[rootOne];
            _elementCountPerComponent[rootOne] = 0;
        }
        else
        {
            _id[rootTwo] = rootOne;
            _elementCountPerComponent[rootOne] += _elementCountPerComponent[rootTwo];
            _elementCountPerComponent[rootTwo] = 0;
        }

        _componentCount--;
    }
}
