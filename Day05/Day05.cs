using System.Diagnostics;
using System.Resources;

namespace AoC
{
    public static class Day05
    {
        public static String Day05a(string[] input)
        {
            var no = (input[0].Length+1) / 4;
            List<char>[] stacks = new List<char>[no];
            for (int i = 0; i < no; i++)
            {
                stacks[i] = new List<char>();
            }
            var row = 0;
            for (; row < input.Length; row++)
            {
                if (input[row].Length == 0) break;
                for (var i = 0; i < no; i++)
                {
                    var c = input[row][i*4+1];
                    if (Char.IsLetter(c))
                    {
                        stacks[i].Add(c);
                    }
                }
            }
            row++;
            for (; row < input.Length; row++)
            {
                var parts = input[row].Split(' ');
                if (parts.Length < 5) break;
                var num = Convert.ToInt32(parts[1]);
                var from = Convert.ToInt32(parts[3]) - 1;
                var to = Convert.ToInt32(parts[5]) - 1;
                for (var n=0; n < num; n++)
                {
                    stacks[to].Insert(0, stacks[from][0]);
                    stacks[from].RemoveAt(0);
                }
            }
            var res = "";
            for (int i = 0; i < no; i++)
            {
                res += stacks[i][0];
            }

            return res;
        }

        public static String Day05b(string[] input)
        {
            var no = (input[0].Length + 1) / 4;
            List<char>[] stacks = new List<char>[no];
            for (int i = 0; i < no; i++)
            {
                stacks[i] = new List<char>();
            }
            var row = 0;
            for (; row < input.Length; row++)
            {
                if (input[row].Length == 0) break;
                for (var i = 0; i < no; i++)
                {
                    var c = input[row][i * 4 + 1];
                    if (Char.IsLetter(c))
                    {
                        stacks[i].Add(c);
                    }
                }
            }
            row++;
            for (; row < input.Length; row++)
            {
                var parts = input[row].Split(' ');
                if (parts.Length < 5) break;
                var num = Convert.ToInt32(parts[1]);
                var from = Convert.ToInt32(parts[3]) - 1;
                var to = Convert.ToInt32(parts[5]) - 1;
                for (var n = 0; n < num; n++)
                {
                    stacks[to].Insert(n, stacks[from][0]);
                    stacks[from].RemoveAt(0);
                }
            }
            var res = "";
            for (int i = 0; i < no; i++)
            {
                res += stacks[i][0];
            }

            return res;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day05.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day05a : {0}   Time: {1}", Day05a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day05b : {0}   Time: {1}", Day05b(lines), sw.ElapsedMilliseconds);
        }
    }
}
