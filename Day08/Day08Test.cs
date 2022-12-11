using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace AoC
{
    public class Day08Test
    {
        readonly string input =
@"30373
25512
65332
33549
35390
";

        readonly Int64 resultA = 21;
        readonly Int64 resultB = 8;

        [Fact]
        public void Day08a()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day08.Day08a(lines);
            Assert.Equal(resultA, result);

            Console.WriteLine("Day08a : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }


        [Fact]
        public void Day08b()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day08.Day08b(lines);
            Assert.Equal(resultB, result);

            Console.WriteLine("Day08b : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }

        public Day08Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
