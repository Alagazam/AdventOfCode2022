using System.Diagnostics;

namespace AoC
{
    public static class Day22
    {
        public static void Move(ref int x, ref int y, int dir, string[] input)
        {
            var newx = x;
            var newy = y;
            switch (dir)
            {
                case 0:
                    newx++;
                    while (true)
                    {
                        if (newx >= input[newy].Length) newx = 0;
                        else if (input[newy][newx] == ' ') newx++;
                        else if (input[newy][newx] == '.') break;
                        else if (input[newy][newx] == '#') break;
                    }
                    break;

                case 1: 
                    newy++;
                    while(true) {
                        if (newy >= input.Length - 2) newy = 0;
                        else if (newx >= input[newy].Length) newy++;
                        else if (input[newy][newx] == ' ') newy++;
                        else if (input[newy][newx] == '.') break;
                        else if (input[newy][newx] == '#') break;
                    }
                    break;

                case 2: 
                    newx--;
                    while (true)
                    {
                        if (newx < 0) newx = input[newy].Length-1;
                        else if (input[newy][newx] == ' ') newx--;
                        else if (input[newy][newx] == '.') break;
                        else if (input[newy][newx] == '#') break;
                    }
                    break;

                case 3:
                    newy--;
                    while (true)
                    {
                        if (newy < 0 ) newy = input.Length - 2;
                        else if (newx >= input[newy].Length) newy--;
                        else if (input[newy][newx] == ' ') newy--;
                        else if (input[newy][newx] == '.') break;
                        else if (input[newy][newx] == '#') break;
                    }
                    break;
            }
            if (input[newy][newx] == '.')
            {
                x = newx;
                y = newy;
            }
        }
        public static void Move(ref int x, ref int y, int dir, int dist, string[] input)
        {
            foreach (var n in Enumerable.Range(0, dist))
            {
                Move(ref x, ref y, dir, input);
            }
            Console.WriteLine("x= {0} y= {1}", x, y);
        }

        public static Int64 Day22a(string[] input)
        {
            var walk = input[input.Length-1];
            var y = 0;
            var x = input[0].IndexOf('.');
            var dir = 0;
            var dist = 0;
            foreach(var i in walk)
            {
                switch (i)
                {
                    case 'R':
                        Move(ref x, ref y, dir, dist, input);
                        dist = 0;
                        dir++; if (dir == 4) dir = 0; 
                        break;
                    case 'L':
                        Move(ref x, ref y, dir, dist, input);
                        dist = 0;
                        dir--; if (dir == -1) dir = 3; 
                        break;
                    default:
                        dist = dist * 10 + i-'0';
                        break;
                }
            }
            Move(ref x, ref y, dir, dist, input);

            return (y +1) *1000 + (x+1) * 4 + dir;
        }

        public static Int64 Day22b(string[] input)
        {
            return 0;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day22.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day22a : {0}   Time: {1}", Day22a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day22b : {0}   Time: {1}", Day22b(lines), sw.ElapsedMilliseconds);
        }
    }
}
