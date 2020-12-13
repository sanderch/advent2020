using System;
using System.IO;

namespace day4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // byr (Birth Year)
            // iyr (Issue Year)
            // eyr (Expiration Year)
            // hgt (Height)
            // hcl (Hair Color)
            // ecl (Eye Color)
            // pid (Passport ID)
            // cid (Country ID)

            var data = File.ReadAllText("data.txt");
            var passes = data.Split("\n\n");
            var correctPasses = 0;
            foreach (var pass in passes)
            {
                Console.WriteLine(pass);
                if (CheckHasField(pass, "byr")&&CheckHasField(pass, "iyr")&&CheckHasField(pass, "eyr")&&CheckHasField(pass, "hgt")&&CheckHasField(pass, "hcl")&&CheckHasField(pass, "ecl")&&CheckHasField(pass, "pid")){
                    correctPasses++;
                }
                Console.WriteLine("--------------------------");
            }
            Console.WriteLine($"TotalPasses: {passes.Length}");
            Console.WriteLine($"CorrectPasses: {correctPasses}");
        }
        
        static bool CheckHasField(string pass, string fieldName){
            pass = pass.Replace("\n", " ");
            var fields = pass.Split(" ");
            foreach (var field in fields)
            {
                var keyValue = field.Split(":");
                if (keyValue[0] == fieldName) return true;
            }
            return false;
        }
    }
}
