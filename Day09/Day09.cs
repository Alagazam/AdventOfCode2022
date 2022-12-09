using System.Diagnostics;

namespace AoC2020
{
    struct Coord { public int X; public int Y; };

    public static class Day09
    {
        public static Int64 Day09a(string[] input)
        {
            var head = new Coord() { X = 0, Y = 0 };
            var tail = new Coord() { X = 0, Y = 0 };
            var positions = new HashSet<Coord>();
            foreach (string s in input)
            {
                var row = s.Split(' ');
                var dir = row[0];
                var length = Convert.ToInt32(row[1]);
                foreach (var i in Enumerable.Range(0, length))
                {
                    switch (dir[0])
                    {
                        case 'R':
                            head.X++; break;
                        case 'L':
                            head.X--; break;
                        case 'U':
                            head.Y++; break;
                        case 'D':
                            head.Y--; break;
                    }

                    if (Math.Abs(head.X - tail.X) > 1 || Math.Abs(head.Y - tail.Y) > 1)
                    {
                        var moveX = Math.Sign(head.X - tail.X);
                        var moveY = Math.Sign(head.Y - tail.Y);
                        tail.X += moveX;
                        tail.Y += moveY;
                    }
                    positions.Add(tail);
                }
            }
            return positions.Count;
        }

        public static Int64 Day09b(string[] input)
        {
            var rope = new Coord[10];
            var positions = new HashSet<Coord>();
            foreach (string s in input)
            {
                var row = s.Split(' ');
                var dir = row[0];
                var length = Convert.ToInt32(row[1]);
                foreach (var i in Enumerable.Range(0, length))
                {
                    switch (dir[0])
                    {
                        case 'R':
                            rope[0].X++; break;
                        case 'L':
                            rope[0].X--; break;
                        case 'U':
                            rope[0].Y++; break;
                        case 'D':
                            rope[0].Y--; break;
                    }

                    foreach (var n in Enumerable.Range(0, rope.Length - 1))
                    {
                        if (Math.Abs(rope[n].X - rope[n+1].X) > 1 || Math.Abs(rope[n].Y - rope[n + 1].Y) > 1)
                        {
                            var moveX = Math.Sign(rope[n].X - rope[n + 1].X);
                            var moveY = Math.Sign(rope[n].Y - rope[n + 1].Y);
                            rope[n + 1].X += moveX;
                            rope[n + 1].Y += moveY;
                        }

                    }
                    positions.Add(rope[9]);
                }
            }
            return positions.Count;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day09.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day09a : {0}   Time: {1}", Day09a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day09b : {0}   Time: {1}", Day09b(lines), sw.ElapsedMilliseconds);
        }
    }
}
