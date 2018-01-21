using System;
using System.Collections.Generic;

namespace Tries
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = new TrieNode();
            var line = Console.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                var input = line.Split(' ');
                switch(input[0])
                {
                    case "a":
                        root.Add(input[1]);
                        break;
                    case "f":
                        Console.WriteLine(root.CountOccurences(input[1]));
                        break;
                }

                line = Console.ReadLine();
            }
        }
    }

    public class TrieNode
    {
        public TrieNode()
        {
            Children = new Dictionary<char, TrieNode>();
        }

        public Dictionary<char, TrieNode> Children { get; }

        private bool IsWordEnding { get; set; }

        public void Add(string value)
        {
            var node = this;
            var i = 0;

            // look up
            while (i < value.Length)
            {
                if (node.Children.ContainsKey(value[i]))
                {
                    node = node.Children[value[i]];
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
                node.Children.Add(value[i], new TrieNode());
                node = node.Children[value[i]];
                i++;
            }

            node.IsWordEnding = true;
        }

        public int CountOccurences(string value)
        {
            var node = this;
            var i = 0;
            // look up
            while (i < value.Length)
            {
                if (node.Children.ContainsKey(value[i]))
                {
                    node = node.Children[value[i]];
                    i++;
                }
                else
                {
                    return 0;
                }
            }

            // count
            var toProcess = new Stack<TrieNode>();
            var result = 0;
            toProcess.Push(node);
            while (toProcess.Count > 0)
            {
                var current = toProcess.Pop();
                if (current.IsWordEnding)
                {
                    result++;
                }
                foreach (var child in current.Children)
                {
                    toProcess.Push(child.Value);
                }
            }

            return result;
        }
    }
}
