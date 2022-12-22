using System.Diagnostics;

namespace AoC
{
    public static class Day21
    {
        public static Int64 Day21a(string[] input)
        {
            return 0;
        }

        public static Int64 Day21b(string[] input)
        {
            return 0;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day21.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day21a : {0}   Time: {1}", Day21a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day21b : {0}   Time: {1}", Day21b(lines), sw.ElapsedMilliseconds);
        }
    }
}
