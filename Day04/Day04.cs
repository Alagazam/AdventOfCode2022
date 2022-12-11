using System.Diagnostics;

namespace AoC
{
    public static class Day04
    {
        public static Int64 Day04a(string[] input)
        {
            var num = 0;
            foreach (var item in input)
            {
                var groups = item.Split(',');
                var elf1 = groups[0].Split('-');
                var elf2 = groups[1].Split('-');
                var x1 = Convert.ToUInt64(elf1[0]);
                var x2 = Convert.ToUInt64(elf1[1]);
                var y1 = Convert.ToUInt64(elf2[0]);
                var y2 = Convert.ToUInt64(elf2[1]);
                if (x1 <= y1 && x2 >= y2 || y1 <= x1 && y2 >= x2) num++;
            }
            return num;
        }

        public static Int64 Day04b(string[] input)
        {
            var num = 0;
            foreach (var item in input)
            {
                var groups = item.Split(',');
                var elf1 = groups[0].Split('-');
                var elf2 = groups[1].Split('-');
                var x1 = Convert.ToUInt64(elf1[0]);
                var x2 = Convert.ToUInt64(elf1[1]);
                var y1 = Convert.ToUInt64(elf2[0]);
                var y2 = Convert.ToUInt64(elf2[1]);
                if (x2 >= y1 && x1 <= y2) num++;
            }
            return num;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day04.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day04a : {0}   Time: {1}", Day04a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day04b : {0}   Time: {1}", Day04b(lines), sw.ElapsedMilliseconds);
        }
    }
}
