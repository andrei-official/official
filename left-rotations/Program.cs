using System;
using System.Text;

namespace left_rotations {
    class Program {
        static void Main (string[] args) {
            var input = "12345";
            Console.WriteLine (LeftRotation (input, 4));
        }

        static string LeftRotation (string input, int rotations)
        {
            var firstItem = rotations % input.Length;
            var result = new StringBuilder (input.Length);
            result.Append (input[firstItem]);
            for (var i = firstItem + 1; i < firstItem + input.Length; i++) {
                result.Append (' ');
                result.Append (input[i % input.Length]);
            }

            return result.ToString ();
        }
    }
}