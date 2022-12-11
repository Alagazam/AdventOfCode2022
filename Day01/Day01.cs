using System.Diagnostics;

namespace AoC
{
    public static class Day01
    {
        public static Int64 Day01a(string[] input)
        {
            Int64 max = 0;
            Int64 current = 0;
            foreach(var x in input)
            {
                if (x == "")
                {
                    current = 0;
                    continue;
                }
                var cal =Convert.ToInt64(x);
                current += cal;
                if (current > max)
                {
                    max = current;
                }
            }
            return max;
        }

        public static Int64 Day01b(string[] input)
        {
            var cals= new List<Int64>();
            Int64 current = 0;
            foreach (var x in input)
            {
                if (x == "")
                {
                    cals.Add(current);
                    current = 0;
                    continue;
                }
                var cal = Convert.ToInt64(x);
                current += cal;
            }
            cals.Sort((a,b) => b.CompareTo(a));
            return cals[0] + cals[1] + cals[2];
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day01.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day01a : {0}   Time: {1}", Day01a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day01b : {0}   Time: {1}", Day01b(lines), sw.ElapsedMilliseconds);
        }
    }
}
