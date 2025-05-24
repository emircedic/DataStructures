namespace DataStructures.AVL
{
    public class Node
    {
        public int BalanceFactor { get; set; }
        public string Value { get; set; }
        public int Height { get; set; }
        public Node? Left;
        public Node? Right;

        public Node(string value)
        {
            Value = value;
        }
    }

    public class AVLTree
    {
        public Node? Root { get; set; }
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

        private bool InternalContains(Node? node, string value)
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

        private Node InternalInsert(Node? node, string value)
        {
            if (node == null)
                return new Node(value);

            int comparisonResult = value.CompareTo(node.Value);

            if (comparisonResult < 0)
                node.Left = InternalInsert(node.Left, value);

            if (comparisonResult > 0)
                node.Right = InternalInsert(node.Right, value);

            Update(node);

            return Balance(node);
        }

        private void Update(Node node)
        {
            int leftNodeHeight = (node.Left == null) ? -1 : node.Left.Height;
            int rightNodeHeight = (node.Right == null) ? -1 : node.Right.Height;

            node.Height = 1 + Math.Max(leftNodeHeight, rightNodeHeight);

            node.BalanceFactor = rightNodeHeight - leftNodeHeight;
        }

        private Node Balance(Node node)
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


        private Node LeftLeftCase(Node node) => RightRotation(node);

        private Node LeftRightCase(Node node)
        {
            node.Left = LeftRotation(node.Left);
            return LeftLeftCase(node);
        }

        private Node RightRightCase(Node node) => LeftRotation(node);

        private Node RightLeftCase(Node node)
        {
            node.Right = RightRotation(node.Right);
            return RightRightCase(node);
        }

        private Node LeftRotation(Node node)
        {
            Node newParent = node.Right;
            node.Right = newParent.Left;
            newParent.Left = node;

            Update(node);
            Update(newParent);

            return newParent;
        }

        private Node RightRotation(Node node)
        {
            Node newParent = node.Left;
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

        private Node? InternalRemove(Node? node, string value)
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

        private string FindMin(Node node)
        {
            while (node.Left != null)
                node = node.Left;

            return node.Value;
        }

        private string FindMax(Node node)
        {
            while (node.Right != null)
                node = node.Right;

            return node.Value;
        }
    }


}
