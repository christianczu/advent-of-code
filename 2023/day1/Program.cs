using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using System.Net;

namespace day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var numbers = new List<int>();
            //var lines = File.ReadLines("D:\\Desktop\\advent-of-code\\2023\\day1\\input_part1.txt");
            //foreach (var line in lines)
            //{
            //    string number, number1, number2;
            //    string result = Regex.Replace(line, @"[^\d+]", "");
            //    number1 = result.Substring(0, 1);
            //    number2 = Convert.ToString(result[result.Length - 1]);
            //    number = number1 + number2;
            //    numbers.Add(Convert.ToInt32(number));
            //}

            var numberDict = new Dictionary<string, string>()
            {
                { "nine", "9" },
                { "eight", "8" },
                { "seven", "7" },
                { "six", "6" },
                { "five", "5" },
                { "four", "4" },
                { "three", "3" },
                { "two", "2" },
                { "one", "1" },
            };

            
            var numbers = new List<int>();
            var lines = File.ReadLines("C:\\Users\\chris\\Desktop\\advent-of-code\\2023\\day1\\input_part2_example.txt");
            foreach (var line in lines)
            {
                string modifiedLine = line;

                foreach (var entry in numberDict.OrderByDescending(kv => kv.Key.Length))
                {
                    int index = modifiedLine.IndexOf(entry.Key, StringComparison.OrdinalIgnoreCase);
                    if (index != -1)
                    {
                        modifiedLine = modifiedLine.Substring(0, index) + entry.Value + modifiedLine.Substring(index + entry.Key.Length);
                        break; // Break after replacing the first occurrence
                    }
                }

                string result = Regex.Replace(modifiedLine, @"[^\d+]", "");
                Console.WriteLine(result);


                //string number, number1, number2;
                //string result = Regex.Replace(line, @"[^\d+]", "");
                //number1 = result.Substring(0, 1);
                //number2 = Convert.ToString(result[result.Length - 1]);
                //number = number1 + number2;
                //numbers.Add(Convert.ToInt32(number));
            }



            Console.WriteLine(numbers.Sum());

            Console.Read();
        }
    }
}