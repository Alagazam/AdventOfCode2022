using System.Diagnostics;
using System.Text;

namespace AoC
{
    public static class Day10
    {
        public static Int64 Day10a(string[] input)
        {
            var checkpoints = new List<Int64>() { 20, 60, 100, 140, 180, 220 };
            Int64 result = 0;
            Int64 clock = 1;
            int cycles = 0;
            Int64 addvalue = 0;
            Int64 x = 1;
            foreach (var row in input)
            {
                var cmd = row.Split(' ');
                switch (cmd[0])
                {
                    case "noop":
                        cycles = 1;
                        addvalue = 0;
                        break;
                    case "addx":
                        cycles = 2;
                        addvalue = Convert.ToInt64(cmd[1]);
                        break;
                }
                while (cycles != 0)
                {
                    clock++;
                    cycles--;
                    if (cycles == 0) { x += addvalue; }
                    if (checkpoints.Contains(clock))
                    {
                        Console.WriteLine("{0} {1} {2}", clock, x, clock * x);
                        result += clock*x; 
                    }
                }
            }
            return result;
        }

        public static String Day10b(string[] input)
        {
            var checkpoints = new List<Int64>() { 20, 60, 100, 140, 180, 220 };
            StringBuilder result = new StringBuilder(300);
            Int64 clock = 1;
            Int64 pixel = 0;
            int cycles = 0;
            Int64 addvalue = 0;
            Int64 x = 1;
            foreach (var row in input)
            {
                var cmd = row.Split(' ');
                switch (cmd[0])
                {
                    case "noop":
                        cycles = 1;
                        addvalue = 0;
                        break;
                    case "addx":
                        cycles = 2;
                        addvalue = Convert.ToInt64(cmd[1]);
                        break;
                }
                while (cycles != 0)
                {
                    clock++;
                    cycles--;
                    if (pixel >= x-1 && pixel <= x+1)
                    {
                        result.Append('#');
                    }
                    else
                    {
                        result.Append('.');
                    }
                    if (pixel == 39)
                    {
                        result.Append("\r\n");
                    }
                    pixel = (pixel + 1) % 40;
                    if (cycles == 0) { x += addvalue; }
                }
            }
            return result.ToString();
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day10.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day10a : {0}   Time: {1}", Day10a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day10b : \r\n{0}   Time: {1}", Day10b(lines), sw.ElapsedMilliseconds);
        }
    }
}
