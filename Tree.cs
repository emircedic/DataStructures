using System.Numerics;

namespace DataStructures
{
    public class BinarySearchTree {}

    public class SegmentTree {}

    public class AVLTree {}

    public class FenwickTree
    {
        private readonly int N;

        private long[] _tree;

        public FenwickTree(int size)
        {
            N = size + 1;
            _tree = new long[N];
        }

        public FenwickTree(long[] values)
        {
            if (values == null)
                throw new ArgumentNullException("Values array cannot be null!");

            N = values.Length;
            values[0] = 0L;

            _tree = new long[values.Length];
            Array.Copy(values, _tree, values.Length);

            for (int i = 1; i < N; i++)
            {
                int parent = i + LeastSignificantBit(i);
                if (parent < N)
                    _tree[parent] += _tree[i];
            }
        }

        /// <summary>
        /// Returns the least significant bit.
        /// Example: 96 => 0b1100000 => 32 
        /// </summary>
        private int LeastSignificantBit(int i) => (int)Math.Pow(2, BitOperations.TrailingZeroCount(i));

        /// <summary>
        /// Returns the sum between first and specified position in array.
        /// </summary>
        private long PrefixSum(int i)
        {
            long sum = 0L;

            while (i != 0)
            {
                sum += _tree[i];
                i -= LeastSignificantBit(i);
            }

            return sum;
        }

        /// <summary>
        /// Returns the sum between specified start and end positions.
        /// </summary>
        public long Sum(int startPosition, int endPosition)
        {
            if (endPosition < startPosition)
                throw new ArgumentException("Make sure end position is larger then start position!");

            return PrefixSum(endPosition) - PrefixSum(startPosition - 1);
        }

        public long Get(int i) => Sum(i, i);

        public void Add(int i, long value)
        {
            while (i < N)
            {
                _tree[i] += value;
                i += LeastSignificantBit(i);
            }
        }

        public void Set(int i, long value) => Add(i, value - Sum(i, i));
    }

    public class BinarySearchTreeSet {}

    public class BinarySearachTreeMap {}
}
