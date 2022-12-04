using System.Diagnostics;

namespace AoC2020
{
    public static class Day03
    {
        public static Int64 Day03a(string[] input)
        {
            Int64 prio = 0;
            foreach (var x in input)
            {
                var comp1 = x.Substring(0, x.Length / 2);
                var comp2 = x.Substring(x.Length / 2);
                var common = comp1.Intersect(comp2);
                if (Char.IsLower(common.First())) prio += common.First() - 'a' + 1;
                else prio += common.First() - 'A' + 27;
            }
            return prio;
        }

        public static Int64 Day03b(string[] input)
        {
            Int64 prio = 0;
            for ( var x = 0; x < input.Length; x+=3 )
            {
                var sack1 = input[x];
                var sack2 = input[x+1];
                var sack3 = input[x+2];
                var common = sack1.Intersect(sack2).Intersect(sack3);
                if (Char.IsLower(common.First())) prio += common.First() - 'a' + 1;
                else prio += common.First() - 'A' + 27;
            }
            return prio;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day03.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day03a : {0}   Time: {1}", Day03a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day03b : {0}   Time: {1}", Day03b(lines), sw.ElapsedMilliseconds);
        }
    }
}
