namespace DataStructures
{
    public class UnionFind
    {

        // Represents the parent of each node.
        Dictionary<int, int> parents = new Dictionary<int, int>();

        // Represents the rank (height) of each node.
        Dictionary<int, int> ranks = new Dictionary<int, int>();

        public UnionFind(int n)
        {

            for (int i = 0; i < n; i++)
            {
                // Set each node as its own parent.
                parents[i] = i;

                ranks[i] = 0;
            }
        }

        public int Find(int x)
        {
            int parentNode = parents[x];

            // Iterate until the node is its own parent.
            while (parents[parentNode] != parentNode)
            {
                // Set parent node for current node using its parent parent's node.
                // We basically skip the current parent node and go one rank heigher.
                // This works because of rule to set the node itself as parent once we reach the peak.
                parents[parentNode] = parents[parents[parentNode]];

                // Get parent of current node.
                parentNode = parents[parentNode];
            }

            return parentNode;
        }

        public bool IsSameComponent(int x, int y)
        {
            var parentNodeX = Find(x);
            var parentNodeY = Find(y);

            return parentNodeX == parentNodeY;
        }

        public bool Union(int x, int y)
        {
            var parentNodeX = Find(x);
            var parentNodeY = Find(y);

            if (parentNodeX == parentNodeY)
                return false;

            // X head node has higher rank.
            if (ranks[parentNodeX] > ranks[parentNodeY])
            {
                parents[parentNodeY] = parentNodeX;
            }
            // Y head node has higher rank.
            if (ranks[parentNodeY] > ranks[parentNodeX])
            {
                parents[parentNodeX] = parentNodeY;
            }
            // X and Y head nodes have equal ranks.
            else
            {
                parents[parentNodeY] = parentNodeX;
                ranks[parentNodeX] = ranks[parentNodeX] + 1;
            }

            return true;
        }

        public int GetNumComponents()
        {

            int result = 0;

            foreach (int key in parents.Keys)
            {
                if (key == parents[key])
                    result++;
            }

            return result;
        }
    }
}
