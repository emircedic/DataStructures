namespace DataStructures
{
    public class BinarySearchTree
    {
        // Tracks the number of nodes in current BST.
        private int _nodeCount = 0;

        // BST is a rooted tree so we need to keep track of the root.
        private Node? root = null;

        private class Node
        {
            public int? Data { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(int data, Node leftNode, Node rightNode)
            {
                Data = data;
                Left = leftNode;
                Right = rightNode;
            }
        }

        public Boolean IsEmpty()
        {
            return GetSize() == 0;
        }

        public int GetSize()
        {
            return _nodeCount;
        }

        public bool Add(int data)
        {
            if (Contains(data))
                return false;
            else
            {
                root = Add(root, data);
                _nodeCount++;
                return true;
            }
        }

        private Node Add(Node node, int data)
        {
            if (node == null)
                node = new Node(data, null, null);
            else
            {
                if (data < node.Data)
                    node.Left = Add(node.Left, data);
                else
                    node.Right = Add(node.Right, data);
            }

            return node;
        }

        public bool Remove(int data)
        {
            if (Contains(data))
            {
                root = Remove(root, data);
                _nodeCount--;
                return true;
            }
            return false;
        }

        private Node Remove(Node node, int data)
        {
            if (node == null)
                return null;

            if (data < node.Data)
                node.Left = Remove(node.Left, data);
            else if (data > node.Data)
                node.Right = Remove(node.Right, data);
            else
            {
                if (node.Left == null)
                    return node.Right;
                else if (node.Right == null)
                    return node.Left;
                else
                {
                    Node temp = FindMin(node.Right);

                    node.Data = temp.Data;

                    node.Right = Remove(node.Right, (int)temp.Data);
                }
            }

            return node;
        }

        private Node FindMin(Node node)
        {
            while (node.Left != null)
                node = node.Left;
            return node;
        }

        private Node FindMax(Node node)
        {
            while (node.Right != null)
                node = node.Right;
            return node;
        }

        public bool Contains(int data)
        {
            return Contains(root, data);
        }

        private bool Contains(Node node, int data)
        {
            if (node == null)
                return false;

            if (data < node.Data)
                return Contains(node.Left, data);
            else if (data > node.Data)
                return Contains(node.Right, data);
            else
                return true;
        }

        public int GetHeight()
        {
            return GetHeight(root);
        }

        private int GetHeight(Node node)
        {
            if (node == null)
                return 0;

            return Math.Max(GetHeight(node.Left), GetHeight(node.Right)) + 1;
        }
    }
}
