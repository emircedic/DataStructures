using System.Numerics;

namespace DataStructures
{
    public class BinarySearchTreeNode
    {
        public int Key { get; set; }
        public int Value { get; set; }

        public BinarySearchTreeNode Left { get; set; }
        public BinarySearchTreeNode Right { get; set; }

        public BinarySearchTreeNode(int key, int value)
        {
            Key = key;
            Value = value;
        }
    }
    public class BinarySearchTree
    {
        private BinarySearchTreeNode Root { get; set; }

        public BinarySearchTree() {}

        public void Insert(int key, int val)
        {
            Root = InsertInternal(Root, key, val);
        }

        private BinarySearchTreeNode InsertInternal(BinarySearchTreeNode node, int key, int value)
        {
            if (node == null || node.Key == key)
                return new BinarySearchTreeNode(key, value);

            if (key > node.Key)
                node.Right = InsertInternal(node.Right, key, value);
            else
                node.Left = InsertInternal(node.Left, key, value);

            return node;
        }

        public int Get(int key)
        {
            return GetInternal(Root, key);
        }

        private int GetInternal(BinarySearchTreeNode node, int key)
        {
            if (node == null)
                return -1;

            if (key > node.Key)
                return GetInternal(node.Right, key);
            else if (key < node.Key)
                return GetInternal(node.Left, key);
            else
                return node.Value;
        }

        public int GetMin()
        {
            BinarySearchTreeNode currentNode = Root;

            if (currentNode == null)
                return -1;

            while (currentNode.Left != null)
                currentNode = currentNode.Left;

            return currentNode.Value;
        }

        public int GetMax()
        {
            BinarySearchTreeNode currentNode = Root;

            if (currentNode == null)
                return -1;

            while (currentNode.Right != null)
                currentNode = currentNode.Right;

            return currentNode.Value;
        }

        public void Remove(int key)
        {
            Root = RemoveInternal(Root, key);
        }

        private BinarySearchTreeNode RemoveInternal(BinarySearchTreeNode node, int key)
        {
            if (node == null)
                return null;

            if (key > node.Key)
                node.Right = RemoveInternal(node.Right, key);
            else if (key < node.Key)
                node.Left = RemoveInternal(node.Left, key);
            else
            {
                if (node.Left == null)
                    return node.Right;
                else if (node.Right == null)
                    return node.Left;
                else
                {
                    var minNode = FindMin(node.Right);

                    node.Key = minNode.Key;
                    node.Value = minNode.Value;
                    node.Right = RemoveInternal(node.Right, node.Key);
                }
            }

            return node;
        }

        private BinarySearchTreeNode FindMin(BinarySearchTreeNode node)
        {
            while (node?.Left != null)
                node = node.Left;

            return node;
        }

        public List<int> GetInorderKeys()
        {
            var keys = new List<int>();
            GetInOrderKeyInternal(keys, Root);

            return keys;
        }

        private List<int> GetInOrderKeyInternal(List<int> keys, BinarySearchTreeNode node)
        {
            if (node == null)
                return keys;

            GetInOrderKeyInternal(keys, node.Left);
            keys.Add(node.Key);
            GetInOrderKeyInternal(keys, node.Right);

            return keys;
        }
    }

    public class SegmentNode
    {
        public int Value { get; set; }

        public int LeftIndex { get; set; }
        public int RightIndex { get; set; }

        public SegmentNode LeftNode { get; set; }
        public SegmentNode RightNode { get; set; }

        public SegmentNode(int value, int leftIndex, int rightIndex)
        {
            Value = value;
            LeftIndex = leftIndex;
            RightIndex = rightIndex;
        }
    }
    public class SegmentTree
    {

        private SegmentNode _segmentNodeRoot;

        public SegmentTree(int[] nums)
        {
            _segmentNodeRoot = GenerateSegmentTree(nums, 0, nums.Length - 1);
        }

        public void update(int index, int val)
        {
            UpdateInternal(index, val, _segmentNodeRoot);
        }

        private void UpdateInternal(int targetIndex, int newValue, SegmentNode currentNode)
        {
            if (currentNode.LeftIndex == currentNode.RightIndex)
            {
                currentNode.Value = newValue;
                return;
            }

            int midIndex = currentNode.LeftIndex + ((currentNode.RightIndex - currentNode.LeftIndex) / 2);

            if (targetIndex <= midIndex)
                UpdateInternal(targetIndex, newValue, currentNode.LeftNode);
            else
                UpdateInternal(targetIndex, newValue, currentNode.RightNode);

            currentNode.Value = currentNode.LeftNode?.Value + currentNode.RightNode?.Value ?? 0;
        }

        public int query(int L, int R)
        {
            Console.WriteLine("Start " + L + " " + R);
            return QueryInternal(L, R, _segmentNodeRoot);
        }

        private int QueryInternal(int leftIndex, int rightIndex, SegmentNode currentNode)
        {
            if (currentNode.LeftIndex == leftIndex && currentNode.RightIndex == rightIndex)
                return currentNode.Value;

            int midIndex = currentNode.LeftIndex + ((currentNode.RightIndex - currentNode.LeftIndex) / 2);

            if (rightIndex <= midIndex)
                return QueryInternal(leftIndex, rightIndex, currentNode.LeftNode);
            else if (leftIndex > midIndex)
                return QueryInternal(leftIndex, rightIndex, currentNode.RightNode);
            else
                return QueryInternal(leftIndex, midIndex, currentNode.LeftNode) +
                       QueryInternal(midIndex + 1, rightIndex, currentNode.RightNode);
        }

        private SegmentNode GenerateSegmentTree(int[] nums, int leftIndex, int rightIndex)
        {
            if (leftIndex == rightIndex)
                return new SegmentNode(nums[leftIndex], leftIndex, rightIndex);

            int midIndex = leftIndex + ((rightIndex - leftIndex) / 2);

            var segmentNode = new SegmentNode(0, leftIndex, rightIndex);

            segmentNode.LeftNode = GenerateSegmentTree(nums, leftIndex, midIndex);
            segmentNode.RightNode = GenerateSegmentTree(nums, midIndex + 1, rightIndex);

            segmentNode.Value = segmentNode.LeftNode?.Value + segmentNode.RightNode?.Value ?? 0;

            return segmentNode;
        }
    }

    public class AVLNode
    {
        public int BalanceFactor { get; set; }
        public string Value { get; set; }
        public int Height { get; set; }
        public AVLNode? Left;
        public AVLNode? Right;

        public AVLNode(string value)
        {
            Value = value;
        }
    }
    public class AVLTree
    {


        public AVLNode? Root { get; set; }
        private int nodeCount = 0;

        public int GetHeight()
        {
            if (Root == null)
                return 0;

            return Root.Height;
        }

        public int Size() => nodeCount;

        public bool IsEmpty() => Size() == 0;

        public bool Contains(string value) => InternalContains(Root, value);

        private bool InternalContains(AVLNode? node, string value)
        {
            if (node == null)
                return false;

            int comparisonResult = value.CompareTo(node.Value);

            if (comparisonResult < 0)
                return InternalContains(node.Left, value);

            if (comparisonResult > 0)
                return InternalContains(node.Right, value);

            return true;
        }

        public bool Insert(string? value)
        {
            if (value == null)
                return false;

            if (!InternalContains(Root, value))
            {
                Root = InternalInsert(Root, value);
                nodeCount++;
                return true;
            }

            return false;
        }

        private AVLNode InternalInsert(AVLNode? node, string value)
        {
            if (node == null)
                return new AVLNode(value);

            int comparisonResult = value.CompareTo(node.Value);

            if (comparisonResult < 0)
                node.Left = InternalInsert(node.Left, value);

            if (comparisonResult > 0)
                node.Right = InternalInsert(node.Right, value);

            Update(node);

            return Balance(node);
        }

        private void Update(AVLNode node)
        {
            int leftNodeHeight = (node.Left == null) ? -1 : node.Left.Height;
            int rightNodeHeight = (node.Right == null) ? -1 : node.Right.Height;

            node.Height = 1 + Math.Max(leftNodeHeight, rightNodeHeight);

            node.BalanceFactor = rightNodeHeight - leftNodeHeight;
        }

        private AVLNode Balance(AVLNode node)
        {
            if (node.BalanceFactor == -2)
            {
                if (node.Left.BalanceFactor <= 0)
                    return LeftLeftCase(node);
                else
                    return LeftRightCase(node);
            }
            else if (node.BalanceFactor == 2)
            {
                if (node.Right.BalanceFactor >= 0)
                    return RightRightCase(node);
                else
                    return RightLeftCase(node);
            }

            return node;
        }


        private AVLNode LeftLeftCase(AVLNode node) => RightRotation(node);

        private AVLNode LeftRightCase(AVLNode node)
        {
            node.Left = LeftRotation(node.Left);
            return LeftLeftCase(node);
        }

        private AVLNode RightRightCase(AVLNode node) => LeftRotation(node);

        private AVLNode RightLeftCase(AVLNode node)
        {
            node.Right = RightRotation(node.Right);
            return RightRightCase(node);
        }

        private AVLNode LeftRotation(AVLNode node)
        {
            AVLNode newParent = node.Right;
            node.Right = newParent.Left;
            newParent.Left = node;

            Update(node);
            Update(newParent);

            return newParent;
        }

        private AVLNode RightRotation(AVLNode node)
        {
            AVLNode newParent = node.Left;
            node.Left = newParent.Right;
            newParent.Right = node;

            Update(node);
            Update(newParent);

            return newParent;
        }

        public bool Remove(string value)
        {
            if (value == null)
                return false;

            if (InternalContains(Root, value))
            {
                Root = InternalRemove(Root, value);
                nodeCount--;
                return true;
            }

            return false;
        }

        private AVLNode? InternalRemove(AVLNode? node, string value)
        {
            if (node == null)
                return null;

            int comparisonResult = value.CompareTo(node.Value);

            if (comparisonResult < 0)
                node.Left = InternalRemove(node.Left, value);
            else if (comparisonResult > 0)
                node.Right = InternalRemove(node.Right, value);
            else
            {
                if (node.Left == null)
                    return node.Right;
                else if (node.Right == null)
                    return node.Left;
                else
                {
                    if (node.Left.Height > node.Right.Height)
                    {
                        string successorValue = FindMax(node.Left);
                        node.Value = successorValue;

                        node.Left = InternalRemove(node.Left, successorValue);
                    }
                    else
                    {
                        string successorValue = FindMin(node.Right);
                        node.Value = successorValue;

                        node.Right = InternalRemove(node.Right, successorValue);
                    }
                }
            }

            Update(node);

            return Balance(node);
        }

        private string FindMin(AVLNode node)
        {
            while (node.Left != null)
                node = node.Left;

            return node.Value;
        }

        private string FindMax(AVLNode node)
        {
            while (node.Right != null)
                node = node.Right;

            return node.Value;
        }
    }

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
}
