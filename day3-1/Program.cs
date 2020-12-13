using System;
using System.IO;

namespace day3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Clear();
            var lines = File.ReadAllLines("data.txt");
            //foreach (var line in lines)
            // {
            //    Console.WriteLine(line);    
            //}
            //Console.WriteLine("------------------------------");

            Console.WriteLine(GetTreeCount(lines, 1, 1));
            Console.WriteLine(GetTreeCount(lines, 1, 3));
            Console.WriteLine(GetTreeCount(lines, 1, 5));
            Console.WriteLine(GetTreeCount(lines, 1, 7));
            Console.WriteLine(GetTreeCount(lines, 2, 1));
            Console.WriteLine(GetTreeCount(lines, 1, 1)*GetTreeCount(lines, 1, 3)*GetTreeCount(lines, 1, 5)*GetTreeCount(lines, 1, 7)*GetTreeCount(lines, 2, 1));
            // Console.WriteLine($"Answer: {trc}");
        }

        private static int GetTreeCount(string[] lines, int down, int right)
        {
            var currentLine = 0;
            var currentPosition = 0;
            var treeCount = 0;
            while (currentLine < lines.Length - 1)
            {
                currentLine = currentLine + down;
                currentPosition = currentPosition + right;
                if (currentPosition >= lines[currentLine].Length)
                {
                    currentPosition = currentPosition - (lines[currentLine].Length);
                }
                if (lines[currentLine][currentPosition] == '#') treeCount++;

                //Console.Write(lines[currentLine]);
                //Console.WriteLine($"Line:{currentLine} Position:{currentPosition} Symbol:{lines[currentLine][currentPosition]}");
            }

            return treeCount;
        }
    }
}
