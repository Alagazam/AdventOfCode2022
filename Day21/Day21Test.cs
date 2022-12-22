using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace AoC
{
    public class Day21Test
    {
        readonly string input =
@"";

        readonly Int64 resultA = 0;
        readonly Int64 resultB = 0;

        [Fact]
        public void Day21a()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day21.Day21a(lines);
            Assert.Equal(resultA, result);

            Console.WriteLine("Day21a : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }


        [Fact]
        public void Day21b()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day21.Day21b(lines);
            Assert.Equal(resultB, result);

            Console.WriteLine("Day21b : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }

        public Day21Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
