using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace AoC2020
{
    public class Day05Test
    {
        readonly string input =
@"    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2
";

        readonly String resultA = "CMZ";
        readonly String resultB = "MCD";

        [Fact]
        public void Day05a()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.None);

            var result = Day05.Day05a(lines);
            Assert.Equal(resultA, result);

            Console.WriteLine("Day05a : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }


        [Fact]
        public void Day05b()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.None);

            var result = Day05.Day05b(lines);
            Assert.Equal(resultB, result);

            Console.WriteLine("Day05b : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }

        public Day05Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
