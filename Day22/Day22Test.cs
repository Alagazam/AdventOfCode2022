using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace AoC
{
    public class Day22Test
    {
        readonly string input =
@"        ...#
        .#..
        #...
        ....
...#.......#
........#...
..#....#....
..........#.
        ...#....
        .....#..
        .#......
        ......#.

10R5L5R10L4R5L5";

        readonly Int64 resultA = 6032;
        readonly Int64 resultB = 0;

        [Fact]
        public void Day22a()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.None);

            var result = Day22.Day22a(lines);
            Assert.Equal(resultA, result);

            Console.WriteLine("Day22a : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }


        [Fact]
        public void Day22b()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.None);

            var result = Day22.Day22b(lines);
            Assert.Equal(resultB, result);

            Console.WriteLine("Day22b : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }

        public Day22Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
