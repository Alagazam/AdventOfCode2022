using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace AoC
{
    public class Day13Test
    {
        readonly string input =
@"[1,1,3,1,1]
[1,1,5,1,1]

[[1],[2,3,4]]
[[1],4]

[9]
[[8,7,6]]

[[4,4],4,4]
[[4,4],4,4,4]

[7,7,7,7]
[7,7,7]

[]
[3]

[[[]]]
[[]]

[1,[2,[3,[4,[5,6,7]]]],8,9]
[1,[2,[3,[4,[5,6,0]]]],8,9]
";

        readonly Int64 resultA = 13;
        readonly Int64 resultB = 0;

        [Fact]
        public void Day13a()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.None);

            var result = Day13.Day13a(lines);
            Assert.Equal(resultA, result);

            Console.WriteLine("Day13a : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }


        [Fact]
        public void Day13b()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.None);

            var result = Day13.Day13b(lines);
            Assert.Equal(resultB, result);

            Console.WriteLine("Day13b : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }

        public Day13Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }
    }

}
