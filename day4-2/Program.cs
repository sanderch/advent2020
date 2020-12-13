using System;
using System.IO;
using System.Text.RegularExpressions;

namespace day4_2
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
                if (CheckHasField(pass, "byr") && CheckHasField(pass, "iyr") && CheckHasField(pass, "eyr") && CheckHasField(pass, "hgt") && CheckHasField(pass, "hcl") && CheckHasField(pass, "ecl") && CheckHasField(pass, "pid"))
                {
                    correctPasses++;
                }
                Console.WriteLine("--------------------------");
            }
            Console.WriteLine($"TotalPasses: {passes.Length}");
            Console.WriteLine($"CorrectPasses: {correctPasses}");
        }

        static bool CheckHasField(string pass, string fieldName)
        {
            pass = pass.Replace("\n", " ");
            var fields = pass.Split(" ");
            foreach (var field in fields)
            {
                var keyValue = field.Split(":");
                if (keyValue[0] == fieldName)
                {
                    switch (keyValue[0])
                    {
                        case "byr":
                            var byr = int.Parse(keyValue[1]);
                            return byr >= 1920 && byr <= 2002;
                        case "iyr":
                            var iyr = int.Parse(keyValue[1]);
                            return iyr >= 2010 && iyr <= 2020;
                        case "eyr":
                            var eyr = int.Parse(keyValue[1]);
                            return eyr >= 2020 && eyr <= 2030;
                        case "hgt":
                            var hgtRegex = new Regex(@"^\d+cm$");
                            if (hgtRegex.Matches(keyValue[1]).Count > 0){
                                var hgtNumber = int.Parse(keyValue[1].Replace("cm", string.Empty));
                                return hgtNumber >= 150 && hgtNumber <=193;
                            } else {
                                var hgtNumber = int.Parse(keyValue[1].Replace("in", string.Empty));
                                return hgtNumber >= 59 && hgtNumber <= 76;
                            }
                        case "hcl":
                            var hclRegex = new Regex(@"^#[a-f0-9]{6}$");
                            return hclRegex.Matches(keyValue[1]).Count > 0;
                        case "ecl":
                            var eclRegex = new Regex(@"^amb|blu|brn|gry|grn|hzl|oth$");
                            return eclRegex.Matches(keyValue[1]).Count > 0;
                        case "pid":
                            var pidRegex = new Regex(@"^[0-9]{9}$");
                            return pidRegex.Matches(keyValue[1]).Count > 0;

                        default:
                            return false;
                    }
                }
            }
            return false;
        }
    }
}
