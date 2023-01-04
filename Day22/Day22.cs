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


        public static void Move2(ref int x, ref int y, ref int dir, string[] input)
        {
            var newx = x;
            var newy = y;
            var newdir = dir;
            switch (dir)
            {
                case 0:
                    newx++; break;
                case 1:
                    newy++; break;
                case 2:
                    newx--; break;
                case 3:
                    newy--; break;
            }
            if (newx == 49 && newy >= 0 && newy < 50) { newdir = 0; newy = 149 - newy; newx = 0; }
            else if (newx == 150 && newy >= 0 && newy < 50) { newdir = 2; newy = 149 - newy; newx = 99; }
            else if (newx == 49 && newy >= 50 && newy < 100 && dir == 2) { newdir = 1; newx = newy - 50; newy = 100; }
            else if (newx == 100 && newy >= 50 && newy < 100 && dir == 0) { newdir = 3; newx = newy + 50; newy = 49; }
            else if (newx == -1 && newy >= 100 && newy < 150) { newdir = 0; newy = 149 - newy; newx = 50; }
            else if (newx == 100 && newy >= 100 && newy < 150) { newdir = 2; newy = 149 - newy; newx = 149; }
            else if (newx == -1 && newy >= 150 && newy < 200) { newdir = 1; newx = newy - 100; newy = 0; }
            else if (newx == 50 && newy >= 150 && newy < 200 && dir == 0) { newdir = 3; newx = newy - 100; newy = 149; }

            else if (newy == 99 && newx >= 0 && newx < 50 && dir == 3) { newdir = 0; newy = newx + 50; newx = 50; }
            else if (newy == 200 && newx >= 0 && newx < 50) { newdir = 1; newx = newx + 100; newy = 0; }
            else if (newy == -1 && newx >= 50 && newx < 100) { newdir = 0; newy = newx + 100; newx = 0; }
            else if (newy == 150 && newx >= 50 && newx < 100 && dir == 1) { newdir = 2; newy = newx + 100; newx = 49; }
            else if (newy == -1 && newx >= 100 && newx < 150) { newdir = 3; newx = newx - 100; newy = 199; }
            else if (newy == 50 && newx >= 100 && newx < 150 && dir == 1) { newdir = 2; newy = newx - 50; newx = 99; }

            if (input[newy][newx] == '.')
            {
                x = newx;
                y = newy;
                dir = newdir;
            }
        }

        public static void Move2(ref int x, ref int y, ref int dir, int dist, string[] input)
        {
            foreach (var n in Enumerable.Range(0, dist))
            {
                Move2(ref x, ref y, ref dir, input);
                Console.SetCursorPosition(x, y);
                Console.Write( dir == 0 ? '>' : ( dir == 1 ? 'v' : (dir == 2 ? '<' : '^')));
            }
        }

        public static Int64 Day22b(string[] input)
        {
#pragma warning disable CA1416
            Console.SetCursorPosition(0, 0);
//            Console.SetBufferSize(input[0].Length + 10, input.Length + 10);
            //Console.SetWindowSize(input[0].Length + 10, input.Length);
#pragma warning restore CA1416

            foreach (var i in input) { Console.WriteLine(i); if (i.Length == 0) break; }

            var walk = input[input.Length - 1];
            var y = 0;
            var x = input[0].IndexOf('.');
            var dir = 0;
            var dist = 0;
            foreach (var i in walk)
            {
                switch (i)
                {
                    case 'R':
                        Move2(ref x, ref y, ref dir, dist, input);
                        dist = 0;
                        dir++; if (dir == 4) dir = 0;
                        break;
                    case 'L':
                        Move2(ref x, ref y, ref dir, dist, input);
                        dist = 0;
                        dir--; if (dir == -1) dir = 3;
                        break;
                    default:
                        dist = dist * 10 + i - '0';
                        break;
                }
            }
            Move2(ref x, ref y, ref dir, dist, input);

            return (y + 1) * 1000 + (x + 1) * 4 + dir;
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
