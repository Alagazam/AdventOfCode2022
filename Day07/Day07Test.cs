using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace AoC2020
{
    public class Day07Test
    {
        readonly string input =
@"$ cd /
$ ls
dir a
14848514 b.txt
8504156 c.dat
dir d
$ cd a
$ ls
dir e
29116 f
2557 g
62596 h.lst
$ cd e
$ ls
584 i
$ cd ..
$ cd ..
$ cd d
$ ls
4060174 j
8033020 d.log
5626152 d.ext
7214296 k
";

        readonly UInt64 resultA = 95437;
        readonly UInt64 resultB = 24933642;

        [Fact]
        public void Day07a()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day07.Day07a(lines);
            Assert.Equal(resultA, result);

            Console.WriteLine("Day07a : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }


        [Fact]
        public void Day07b()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day07.Day07b(lines);
            Assert.Equal(resultB, result);

            Console.WriteLine("Day07b : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }

        public Day07Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
