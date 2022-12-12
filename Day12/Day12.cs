using System;
using System.Diagnostics;

namespace AoC
{
    public struct Coord
    {
        public int row;
        public int col; 
        public Coord(int r, int c) { row = r;  col = c; }
        public static Coord operator +(Coord a, Coord b)
            => new(a.row + b.row, a.col + b.col);
    };

    public static class Day12
    {
        public static Coord FindStart(string[] input)
        {
            var r = 0;
            foreach(var row in input)
            {
                var c=row.IndexOf('S');
                if (c >= 0) { return new Coord(r, c); }
                r++;
            }
            return new Coord(-1, -1);
        }

        public static Int64 Day12a(string[] input)
        {
            var pos = FindStart(input);
            var steps = new int[input.Length, input[0].Length];
            var dirs = new Coord[] { new Coord(0, -1), new Coord(0, 1), new Coord(-1, 0), new Coord(1, 0) };

            var queue = new Queue<Coord>();

            queue.Enqueue(pos);
            steps[pos.row, pos.col] = 1;
            while (queue.Count > 0)
            {
                pos = queue.Dequeue();
                var elev = input[pos.row][pos.col];
                if (elev == 'S') elev = 'a';
                var nextStep = steps[pos.row, pos.col] + 1;
                if (input[pos.row][pos.col] == 'E') return steps[pos.row, pos.col] - 1;

                foreach (var dir in dirs)
                {
                    var newPos = pos + dir;
                    if (newPos.row >= 0 && newPos.col >= 0 && newPos.row < input.Length && newPos.col < input[0].Length)
                    {
                        var newElev = input[newPos.row][newPos.col];
                        if (newElev == 'E') newElev = 'z';
                        if (steps[newPos.row, newPos.col] != 0) continue;
                        if (newElev <= elev + 1)
                        {
                            steps[newPos.row, newPos.col] = nextStep;
                            queue.Enqueue(new Coord(newPos.row, newPos.col));
                        }
                    }
                }
            }

            return 0;
        }

        public static Int64 Day12b(string[] input)
        {
            return 0;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day12.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day12a : {0}   Time: {1}", Day12a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day12b : {0}   Time: {1}", Day12b(lines), sw.ElapsedMilliseconds);
        }
    }
}
