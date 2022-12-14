using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace AoC
{
    public class Day14Test
    {
        readonly string input =
@"498,4 -> 498,6 -> 496,6
503,4 -> 502,4 -> 502,9 -> 494,9
";

        readonly Int64 resultA = 24;
        readonly Int64 resultB = 93;

        [Fact]
        public void Day14a()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day14.Day14a(lines);
            Assert.Equal(resultA, result);

            Console.WriteLine("Day14a : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }


        [Fact]
        public void Day14b()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day14.Day14b(lines);
            Assert.Equal(resultB, result);

            Console.WriteLine("Day14b : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }

        public Day14Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
