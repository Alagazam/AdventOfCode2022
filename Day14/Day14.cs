using System.Diagnostics;
using System.Text;

namespace AoC
{
    public static class Day14
    {
        private static void PrintCave(char[,] cave)
        {
            for (int y = 0; y < cave.GetLength(1); y++)
            {
                var s = new StringBuilder();
                for (int x = 0; x < cave.GetLength(0); x++)
                {
                    if (cave[x, y] == 0)
                        s.Append('.');
                    else
                        s.Append(cave[x, y]);
                }
                Console.WriteLine(s);
            }
            Console.WriteLine("");
        }

        private static void GetMinMax(string[] input, out int xMax, out int xMin, out int yMax)
        {
            xMax = 0;
            xMin = int.MaxValue;
            yMax = 0;
            foreach (var i in input)
            {
                var s = i.Split(' ');
                foreach (var coord in s)
                {
                    if (coord != "->")
                    {
                        var xy = coord.Split(',');
                        var x = Convert.ToInt32(xy[0]);
                        var y = Convert.ToInt32(xy[1]);
                        if (x > xMax) xMax = x;
                        if (x < xMin) xMin = x;
                        if (y > yMax) yMax = y;
                    }
                }
            }
            xMin--;
        }

        private static void BuildCave(string[] input, int xMin, char[,] cave)
        {
            foreach (var i in input)
            {
                var s = i.Split(' ');
                int x0 = 0;
                int y0 = 0;
                foreach (var coord in s)
                {
                    if (coord != "->")
                    {
                        var xy = coord.Split(',');
                        var x = Convert.ToInt32(xy[0]);
                        var y = Convert.ToInt32(xy[1]);
                        cave[x - xMin, y] = '*';
                        if (x0 != 0 || y0 != 0)
                        {
                            while (x != x0 || y != y0)
                            {
                                cave[x0 - xMin, y0] = '*';
                                x0 += Math.Sign(x - x0);
                                y0 += Math.Sign(y - y0);
                            }
                        }
                        x0 = x;
                        y0 = y;
                    }
                }
            }
        }

        public static Int64 Day14a(string[] input)
        {
            int xMax, xMin, yMax;
            GetMinMax(input, out xMax, out xMin, out yMax);

            char[,] cave = new char[xMax - xMin + 1, yMax + 1];

            BuildCave(input, xMin, cave);

            int grains = 0;
            while (true)
            {
                int x = 500 - xMin;
                int y = 0;

                while (true)
                {
                    if (y >= yMax) break;
                    if (cave[x, y + 1] == '\0') y++;
                    else if (cave[x - 1, y + 1] == '\0') { x--; y++; }
                    else if (cave[x + 1, y + 1] == '\0') { x++; y++; }
                    else { cave[x, y] = 'o'; break; }
                }

                if (y >= yMax) break;
                grains++;
            }
            PrintCave(cave);

            return grains;
        }


        public static Int64 Day14b(string[] input)
        {
            int xMax, xMin, yMax;
            GetMinMax(input, out xMax, out xMin, out yMax);
            yMax += 2;
            xMin = 500 - yMax;
            xMax = 500 + yMax;

            char[,] cave = new char[xMax - xMin + 1, yMax + 1];

            BuildCave(input, xMin, cave);
            for (int x = 0; x < cave.GetLength(0); x++) cave[x, yMax] = '*';


            int grains = 0;
            while (true)
            {
                int x = 500 - xMin;
                int y = 0;

                while (true)
                {
                    if (y >= yMax) break;
                    if (cave[x, y + 1] == '\0') y++;
                    else if (cave[x - 1, y + 1] == '\0') { x--; y++; }
                    else if (cave[x + 1, y + 1] == '\0') { x++; y++; }
                    else { cave[x, y] = 'o'; break; }
                }
                if (cave[500-xMin,0] == 'o') break;
                if (y >= yMax) break;
                grains++;
            }
            PrintCave(cave);

            return grains+1;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day14.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day14a : {0}   Time: {1}", Day14a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day14b : {0}   Time: {1}", Day14b(lines), sw.ElapsedMilliseconds);
        }
    }
}
