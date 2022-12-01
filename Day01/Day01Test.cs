using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace AoC2020
{
    public class Day01Test
    {
        readonly string input =
@"1000
2000
3000

4000

5000
6000

7000
8000
9000

10000
";

        readonly Int64 resultA = 24000;
        readonly Int64 resultB = 45000;

        [Fact]
        public void Day01a()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.None);

            var result = Day01.Day01a(lines);
            Assert.Equal(resultA, result);

            Console.WriteLine("Day01a : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }


        [Fact]
        public void Day01b()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.None);

            var result = Day01.Day01b(lines);
            Assert.Equal(resultB, result);

            Console.WriteLine("Day01b : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }

        public Day01Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
