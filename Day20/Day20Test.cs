using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace AoC
{
    public class Day20Test
    {
        readonly string input =
@"1
2
-3
3
-2
0
4
";

        readonly string input2 =
@"1
2
-3
3
-2
0
8
";

        readonly Int64 resultA = 3;
        readonly Int64 resultA2 = 7;
        readonly Int64 resultB = 1623178306;


        [Fact]
        public void Day20a()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day20.Day20a(lines);
            Assert.Equal(resultA, result);

            Console.WriteLine("Day20a : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }
        [Fact]
        public void Day20a2()
        {
            var sw = Stopwatch.StartNew();
            var lines = input2.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day20.Day20a(lines);
            Assert.Equal(resultA2, result);

            Console.WriteLine("Day20a2 : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }


        [Fact]
        public void Day20b()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day20.Day20b(lines);
            Assert.Equal(resultB, result);

            Console.WriteLine("Day20b : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }

        public Day20Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
