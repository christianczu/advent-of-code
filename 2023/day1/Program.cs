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
                { "nine", "n9e" },
                { "eight", "e8t" },
                { "seven", "s7n" },
                { "six", "s6x" },
                { "five", "f5e" },
                { "four", "f4r" },
                { "three", "t3e" },
                { "two", "t2o" },
                { "one", "o1e" },
            };

            
            var numbers = new List<int>();
            var lines = File.ReadLines("D:\\Desktop\\advent-of-code\\2023\\day1\\input_part1.txt");
            foreach (var line in lines)
            {

                var output = new StringBuilder(line);

                foreach (var kvp in numberDict)
                    output.Replace(kvp.Key, kvp.Value);

                var numbered = output.ToString();

                string number, number1, number2;
                var result = Regex.Replace(numbered, @"[^\d+]", "");
                number1 = result.Substring(0, 1);
                number2 = Convert.ToString(result[result.Length - 1]);
                number = number1 + number2;
                numbers.Add(Convert.ToInt32(number));
            }



            Console.WriteLine(numbers.Sum());

            Console.Read();
        }
    }
}