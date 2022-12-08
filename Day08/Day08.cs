using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace AoC2020
{
    public static class Day08
    {
        public static bool visible(string[] input, Int32 row, Int32 col)
        {
            var height = input[row][col];
            if (row == 0 || row == input.Length - 1 || col == 0 || col == input[0].Length - 1) return true;
            // Check up
            bool visup = true;
            foreach (var r in Enumerable.Range(0, row))
            {
                var h = input[r][col];
                if (h >= height)
                {
                    visup = false;
                    break;
                }
            }
            if (visup) return true;

            // Check down
            bool visdown = true;
            foreach (var r in Enumerable.Range(row + 1, input.Length - row - 1))
            {
                var h = input[r][col];
                if (h >= height)
                {
                    visdown = false;
                    break;
                }
            }
            if (visdown) return true;

            // Check left
            bool visleft = true;
            foreach (var c in Enumerable.Range(0, col))
            {
                var h = input[row][c];
                if (h >= height)
                {
                    visleft = false;
                    break;
                }
            }
            if (visleft) return true;

            // Check right
            bool visright = true;
            foreach (var c in Enumerable.Range(col + 1, input[0].Length - col - 1))
            {
                var h = input[row][c];
                if (h >= height)
                {
                    visright = false;
                    break;
                }
            }
            if (visright) return true;
            return false;
        }
        public static Int64 Day08a(string[] input)
        {
            Int64 count = 0;
            foreach (var row in Enumerable.Range(0,input.Length))
            {
                foreach (var col in Enumerable.Range(0, input[0].Length))
                {
                    if (visible(input, row, col)) count++; 
                }
                Console.WriteLine();
            }
            return count;
        }

        public static Int64 visscore(string[] input, Int32 row, Int32 col)
        {
            if (row == 0 || row == input.Length - 1 || col == 0 || col == input[0].Length - 1) return 0;
            var height = input[row][col];
            // Check up
            Int64 visup = 0;
            foreach (var r in Enumerable.Range(0, row))
            {
                var h = input[row-r-1][col];
                visup++;
                if (h >= height)
                {
                    break;
                }
            }

            // Check down
            Int64 visdown = 0;
            foreach (var r in Enumerable.Range(row + 1, input.Length - row - 1))
            {
                var h = input[r][col];
                visdown++;
                if (h >= height)
                {
                    break;
                }
            }

            // Check left
            Int64 visleft = 0;
            foreach (var c in Enumerable.Range(0, col))
            {
                var h = input[row][col-c-1];
                visleft++;
                if (h >= height)
                {
                    break;
                }
            }

            // Check right
            Int64 visright = 0;
            foreach (var c in Enumerable.Range(col + 1, input[0].Length - col - 1))
            {
                var h = input[row][c];
                visright++;
                if (h >= height)
                {
                    break;
                }
            }
            return visup*visdown*visleft*visright;
        }

        public static Int64 Day08b(string[] input)
        {
            Int64 max = 0;
            foreach (var row in Enumerable.Range(0, input.Length))
            {
                foreach (var col in Enumerable.Range(0, input[0].Length))
                {
                    var score = visscore(input, row, col);
                    if (score > max)
                    {
                        max = score;
                    }
                }
            }
            return max;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day08.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day08a : {0}   Time: {1}", Day08a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day08b : {0}   Time: {1}", Day08b(lines), sw.ElapsedMilliseconds);
        }
    }
}
