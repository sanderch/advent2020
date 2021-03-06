﻿using System;
using System.IO;

namespace day5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var seatInfos = File.ReadAllLines("data.txt");
            var maxValue = 0;
            foreach (var seatInfo in seatInfos)
            {
                var firstPart = seatInfo.Substring(0, 7).Replace("B", "1").Replace("F", "0");
                var secondPart = seatInfo.Substring(7, 3).Replace("R", "1").Replace("L", "0");
                Console.WriteLine($"seat info:{seatInfo} first:{firstPart} second:{secondPart}");

                int v = (Convert.ToInt32(firstPart, 2) * 8) + Convert.ToInt32(secondPart, 2);
                if (v > maxValue) maxValue = v; 

            }
            Console.WriteLine($"Result = {maxValue}");
        }
    }
}
