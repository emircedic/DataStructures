namespace DataStructures
{
    // n - Length of input word.
    // l - Total count of words in trie.
     
    // Time complexity:
    // Insert: O(n)
    // Search: O(n)
    // StartsWith: O(n)
     
    // Space complexity: O(n * l)
    public class TrieNode
    {
        public bool IsEndOfWord;   // isLeaf
        public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
    }

    public class Trie
    {
        TrieNode root;

        public Trie()
        {
            root = new TrieNode();
        }

        public void Insert(string word)
        {
            TrieNode curr = this.root;

            foreach (char c in word)
            {
                if (!curr.children.ContainsKey(c))
                {
                    curr.children[c] = new TrieNode();
                }
                curr = curr.children[c];
            }

            curr.IsEndOfWord = true;
        }

        public bool Search(string word)
        {
            TrieNode curr = this.root;

            foreach (char c in word)
            {
                if (!curr.children.ContainsKey(c))
                {
                    return false;
                }
                curr = curr.children[c];
            }

            return curr.IsEndOfWord;
        }

        public bool StartsWith(string prefix)
        {
            TrieNode curr = this.root;

            foreach (char c in prefix)
            {
                if (!curr.children.ContainsKey(c))
                {
                    return false;
                }
                curr = curr.children[c];
            }

            return true;
        }
    }
}
