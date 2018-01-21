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
    }
}
