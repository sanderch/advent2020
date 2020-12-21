using System;
using System.Collections.Generic;
using System.IO;

namespace day6_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataTxt = File.ReadAllText("data.txt");
            var groupData = dataTxt.Split("\n\n");
            var result = 0;
            foreach (var group in groupData)
            {
                Console.WriteLine(group);
                var peopleCount = 1;
                var dict = new Dictionary<char, int>();
                foreach (var symbol in group)
                {
                    if (symbol == '\n') {
                        peopleCount++;
                        continue;
                    }
                    // if (!char.IsLetter(symbol)) continue;

                    if (dict.ContainsKey(symbol))
                        dict[symbol]++;
                    else
                        dict.Add(symbol, 1);
                }
                Console.WriteLine($"People: {peopleCount}");
                foreach (var pair in dict)
                {
                    Console.WriteLine($"key: {pair.Key} Value: {pair.Value}");
                    if (pair.Value == peopleCount){
                        result++;
                    } 
                }
                Console.WriteLine($"group result: {result}\n\n");
            }
            Console.WriteLine(result);
        }
    }
}
