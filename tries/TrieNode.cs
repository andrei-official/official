using System;

namespace Official
{   
    public class TrieNode
    {
        public TrieNode()
        {
            Children = new TrieNode[26];
        }

        public static void Run()
        {
            var root = new TrieNode();
            var line = Console.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                var input = line.Split(' ');
                switch(input[0])
                {
                    case "add":
                        root.Add(input[1]);
                        break;
                    case "find":
                        Console.WriteLine(root.Find(input[1]));
                        break;
                }

                line = Console.ReadLine();
            }
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