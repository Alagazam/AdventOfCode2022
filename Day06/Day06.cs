using System.Diagnostics;

namespace AoC2020
{
    public static class Day06
    {
        public static Int64 Day06a(string[] input)
        {
            foreach (var index in Enumerable.Range(0, input[0].Length -4))
            {
                var set = new SortedSet<char>(input[0].Substring(index, 4));
                if (set.Count == 4) return index + 4;
            }

            return 0;
        }

        public static Int64 Day06b(string[] input)
        {
            foreach (var index in Enumerable.Range(0, input[0].Length - 14))
            {
                var set = new SortedSet<char>(input[0].Substring(index,14));
                if (set.Count == 14) return index + 14;
            }

            return 0;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day06.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day06a : {0}   Time: {1}", Day06a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day06b : {0}   Time: {1}", Day06b(lines), sw.ElapsedMilliseconds);
        }
    }
}
