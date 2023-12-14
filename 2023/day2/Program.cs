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
            var r = new List<int>();
            var g = new List<int>();
            var b = new List<int>(); 
            var knownNumber = new List<int>();
            char[] color = { 'r', 'g', 'b' };
            var numbers = new List<int>();
            var lines = File.ReadLines("C:\\Users\\chris\\Desktop\\advent-of-code\\2023\\day2\\input1_example.txt");
            foreach (var line in lines)
            {
                string lineNoHeader = line.Split(":")[1];
                string header = line.Split(":")[0];

                int gameId = Convert.ToInt32(header.Split(" ")[1]);
                foreach (var lineSplit in lineNoHeader.Split(";"))
                {
                    foreach (char c in color)
                    {
                        string pattern = $@"\b{Regex.Escape(c.ToString())}\w+";
                        foreach (Match match in Regex.Matches(lineSplit, pattern))
                        {
                            switch (c)
                            {
                                case 'r':
                                    r.Add(Convert.ToInt32(lineSplit.Substring(match.Index - 3, 3)));
                                    break;
                                case 'g':
                                    g.Add(Convert.ToInt32(lineSplit.Substring(match.Index - 3, 3)));
                                    break;
                                case 'b':
                                    b.Add(Convert.ToInt32(lineSplit.Substring(match.Index - 3, 3)));
                                    break;
                            }
                        }
                    }
                }

                Console.WriteLine(r.Where(x => x < 12));
                Console.WriteLine(r.Any(x => x < 12));
                
                if (r.Any(x => x < 12) && g.Any(y => y < 13) && b.Any(z => z < 14))
                {
                    if (!numbers.Contains(gameId)) {
                            Console.WriteLine(gameId);
                            numbers.Add(gameId);
                    }
                }
                r.Clear();
                g.Clear();
                b.Clear();
            }

            Console.WriteLine(numbers.Sum());
            Console.Read();
        }
    }
}