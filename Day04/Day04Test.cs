using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace AoC
{
    public class Day04Test
    {
        readonly string input =
@"2-4,6-8
2-3,4-5
5-7,7-9
2-8,3-7
6-6,4-6
2-6,4-8
";

        readonly Int64 resultA = 2;
        readonly Int64 resultB = 4;

        [Fact]
        public void Day04a()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day04.Day04a(lines);
            Assert.Equal(resultA, result);

            Console.WriteLine("Day04a : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }


        [Fact]
        public void Day04b()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day04.Day04b(lines);
            Assert.Equal(resultB, result);

            Console.WriteLine("Day04b : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }

        public Day04Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
