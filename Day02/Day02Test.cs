using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace AoC
{
    public class Day02Test
    {
        readonly string input =
@"A Y
B X
C Z
";

        readonly Int64 resultA = 15;
        readonly Int64 resultB = 12;

        [Fact]
        public void Day02a()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day02.Day02a(lines);
            Assert.Equal(resultA, result);

            Console.WriteLine("Day02a : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }


        [Fact]
        public void Day02b()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day02.Day02b(lines);
            Assert.Equal(resultB, result);

            Console.WriteLine("Day02b : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }

        public Day02Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
