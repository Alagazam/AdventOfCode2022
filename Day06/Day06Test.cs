using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using Xunit;
using Xunit.Abstractions;

namespace AoC
{
    public class Day06Test
    {
        readonly string input = @"mjqjpqmgbljsphdztnvjfqwrcgsmlb";

        readonly string input2 = @"bvwbjplbgvbhsrlpgdmjqwftvncz"; //: first marker after character 5
        readonly string input3 = @"nppdvjthqldpwncqszvftbrmjlhg"; //: first marker after character 6
        readonly string input4 = @"nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg"; //: first marker after character 10
        readonly string input5 = @"zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw"; //: first marker after character 11

        readonly Int64 resultA = 7;
        readonly Int64 resultA2 = 5;
        readonly Int64 resultA3 = 6;
        readonly Int64 resultA4 = 10;
        readonly Int64 resultA5 = 11;

        readonly Int64 resultB = 19;
        readonly Int64 resultB2 = 23;
        readonly Int64 resultB3 = 23;
        readonly Int64 resultB4 = 29;
        readonly Int64 resultB5 = 26;

        [Fact]
        public void Day06a()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var lines2 = input2.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var lines3 = input3.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var lines4 = input4.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var lines5 = input5.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day06.Day06a(lines);
            Assert.Equal(resultA, result);

            var result2 = Day06.Day06a(lines2);
            Assert.Equal(resultA2, result2);
            var result3 = Day06.Day06a(lines3);
            Assert.Equal(resultA3, result3);
            var result4 = Day06.Day06a(lines4);
            Assert.Equal(resultA4, result4);
            var result5 = Day06.Day06a(lines5);
            Assert.Equal(resultA5, result5);

            Console.WriteLine("Day06a : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }


        [Fact]
        public void Day06b()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var lines2 = input2.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var lines3 = input3.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var lines4 = input4.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var lines5 = input5.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day06.Day06b(lines);
            Assert.Equal(resultB, result);

            var result2 = Day06.Day06b(lines2);
            Assert.Equal(resultB2, result2);
            var result3 = Day06.Day06b(lines3);
            Assert.Equal(resultB3, result3);
            var result4 = Day06.Day06b(lines4);
            Assert.Equal(resultB4, result4);
            var result5 = Day06.Day06b(lines5);
            Assert.Equal(resultB5, result5);

            Console.WriteLine("Day06b : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }

        public Day06Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
