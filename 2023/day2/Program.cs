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
using System.Diagnostics.CodeAnalysis;

namespace day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] color = { 'r', 'g', 'b' };
            var numbers = new List<int>();
            var lines = File.ReadLines("D:\\Desktop\\advent-of-code\\2023\\day2\\input1_example.txt");
            foreach (var line in lines)
            {
                int gameId = Convert.ToInt32(line.Substring(line.IndexOf(' ') + 1, line.IndexOf(':') - line.IndexOf(' ') - 1));
                var r = new List<int>();
                var g = new List<int>();
                var b = new List<int>();
                foreach (char c in color)
                {
                    string pattern = $@"\b{Regex.Escape(c.ToString())}\w+";
                    foreach (Match match in Regex.Matches(line, pattern))
                    {
                         switch (c)
                        {
                            case 'r':
                                Console.Write(line.Substring(match.Index - 3, 3));
                                r.Add(Convert.ToInt32(line.Substring(match.Index - 3, 3)));
                                break;
                            case 'g':
                                g.Add(Convert.ToInt32(line.Substring(match.Index - 3, 3)));
                                break;
                            case 'b':
                                b.Add(Convert.ToInt32(line.Substring(match.Index - 3, 3)));
                                break;
                        }
                    }
                }
                if (r.Sum() <= 12 && g.Sum() <= 13 && b.Sum() <= 14)
                {
                    numbers.Add(gameId);
                }
                
            }

            //Console.WriteLine(numbers.Sum());
            Console.Read();
        }
    }
}