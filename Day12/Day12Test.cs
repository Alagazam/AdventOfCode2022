using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace AoC
{
    public class Day12Test
    {
        readonly string input =
@"
Sabqponm
abcryxxl
accszExk
acctuvwj
abdefghi
";

        readonly Int64 resultA = 31;
        readonly Int64 resultB = 29;

        [Fact]
        public void FindStart()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day12.FindStart(lines);
            Assert.Equal(0, result.row);
            Assert.Equal(0, result.col);
        }

        [Fact]
        public void Day12a()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day12.Day12a(lines);
            Assert.Equal(resultA, result);

            Console.WriteLine("Day12a : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }


        [Fact]
        public void Day12b()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day12.Day12b(lines);
            Assert.Equal(resultB, result);

            Console.WriteLine("Day12b : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }

        public Day12Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
