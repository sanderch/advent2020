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
            foreach (var item in groupData)
            {
                var dict = new Dictionary<char, int>();
                foreach (var symbol in item)
                {
                    if (!char.IsLetter(symbol)) continue;

                    if (dict.ContainsKey(symbol))
                        dict[symbol]++;
                    else
                        dict.Add(symbol, 1);
                }
                result += dict.Count;
            }

            Console.WriteLine(result);
        }
    }
}
