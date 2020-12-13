using System;
using System.IO;

namespace day2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = "data.txt";
            var answer = 0;
            using (StreamReader sr = File.OpenText(fileName)){
                string s = string.Empty;
                while ((s = sr.ReadLine()) != null){
                    Console.WriteLine(s);                             
                    if (Analyze(s)){
                        answer++;
                    }
                }
            }
            Console.WriteLine($"Answer: {answer}");
        }

        private static bool Analyze(string s)
        {
            // string example 
            // 16-20 q: qsqqqqqqqjqqqvqqqqqh

            var testedString = s.Split(':')[1].Trim();
            var stringCharToFind = s.Split(':')[0].Split(' ')[1];
            char charToFind = stringCharToFind.ToCharArray()[0];
            var min = int.Parse(s.Split(':')[0].Split(' ')[0].Split('-')[0]);
            var max = int.Parse(s.Split(':')[0].Split(' ')[0].Split('-')[1]);

            Console.WriteLine($"testedString: {testedString} charToFind: {charToFind} min: {min} max:{max}");

            return testedString[min-1] == charToFind ^ testedString[max-1] == charToFind;
        }
    }
}
