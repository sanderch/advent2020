using System;
using System.IO;

namespace day2_1
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

            var count = 0;
            for (int i = 0; i < testedString.Length; i++)
            {
                if (testedString[i]==charToFind)
                count++;
            }

            Console.WriteLine(count);
            return count >= min && count <= max;
        }
    }
}
