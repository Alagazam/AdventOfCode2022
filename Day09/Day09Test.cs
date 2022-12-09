using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace AoC2020
{
    public class Day09Test
    {
        readonly string input =
@"R 4
U 4
L 3
D 1
R 4
D 1
L 5
R 2
";

        readonly Int64 resultA = 13;
        readonly Int64 resultB = 1;


        readonly string input2 =
@"R 5
U 8
L 8
D 3
R 17
D 10
L 25
U 20
";
        readonly Int64 resultB2 = 36;

        [Fact]
        public void Day09a()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day09.Day09a(lines);
            Assert.Equal(resultA, result);

            Console.WriteLine("Day09a : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }


        [Fact]
        public void Day09b()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day09.Day09b(lines);
            Assert.Equal(resultB, result);

            Console.WriteLine("Day09b : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }

        [Fact]
        public void Day09b2()
        {
            var sw = Stopwatch.StartNew();
            var lines = input2.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day09.Day09b(lines);
            Assert.Equal(resultB2, result);

            Console.WriteLine("Day09b : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }

        public Day09Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
