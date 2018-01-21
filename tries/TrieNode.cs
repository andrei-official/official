namespace Tries
{   
    public class TrieNode
    {
        public TrieNode()
        {
            Children = new TrieNode[26];
        }

        public TrieNode[] Children { get; }

        private int ChildWordCount { get; set; }

        public void Add(string value)
        {
            var node = this;
            var i = 0;

            // look up
            while (i < value.Length)
            {
                node.ChildWordCount++;
                if (node.Children[value[i] - 'a'] != null)
                {
                    node = node.Children[value[i] - 'a'];
                    i++;
                }
                else
                {
                    break;
                }
            }

            // insert
            while (i < value.Length)
            {
                node.Children[value[i] - 'a'] = new TrieNode();
                node = node.Children[value[i] - 'a'];
                node.ChildWordCount++;
                i++;
            }
        }

        public int Find(string value)
        {
            var node = this;
            var i = 0;
            // look up
            while (i < value.Length)
            {
                if (node.Children[value[i] - 'a'] != null)
                {
                    node = node.Children[value[i] - 'a'];
                    i++;
                }
                else
                {
                    return 0;
                }
            }

            // count
            return node.ChildWordCount;
        }
    }
}