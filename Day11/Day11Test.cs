using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace AoC2020
{
    public class Day11Test
    {
        readonly string input =
@"Monkey 0:
  Starting items: 79, 98
  Operation: new = old * 19
  Test: divisible by 23
    If true: throw to monkey 2
    If false: throw to monkey 3
    
Monkey 1:
  Starting items: 54, 65, 75, 74
  Operation: new = old + 6
  Test: divisible by 19
    If true: throw to monkey 2
    If false: throw to monkey 0
    
Monkey 2:
  Starting items: 79, 60, 97
  Operation: new = old * old
  Test: divisible by 13
    If true: throw to monkey 1
    If false: throw to monkey 3
    
Monkey 3:
  Starting items: 74
  Operation: new = old + 3
  Test: divisible by 17
    If true: throw to monkey 0
    If false: throw to monkey 1
";

        readonly Int64 resultA = 10605;
        readonly Int64 resultB = 2713310158;

        [Fact]
        public void TestMonkey()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var monkey = new Monkey(lines, 0);
            Assert.Equal(2, monkey.items.Count);
            Assert.Equal("old * 19", monkey.op);
            Assert.Equal(23, monkey.divider);
            Assert.Equal(2, monkey.throwTrue);
            Assert.Equal(3, monkey.throwFalse);
        }

        [Fact]
        public void TestRound()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var monkeys = AoC2020.Day11.GetMonkeys(lines);
            Assert.Equal(4, monkeys.Count);
            AoC2020.Day11.Round(monkeys);

            Assert.Equal(4, monkeys[0].items.Count);
            Assert.Equal(6, monkeys[1].items.Count);
            Assert.Equal(0, monkeys[2].items.Count);
            Assert.Equal(0, monkeys[3].items.Count);
            Assert.Equal(2080, monkeys[1].items[0]);
            Assert.Equal(5, monkeys[3].inspects);
        }

        [Fact]
        public void TestRoundB()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var monkeys = AoC2020.Day11.GetMonkeys(lines);
            Assert.Equal(4, monkeys.Count);
            AoC2020.Day11.Round(monkeys, false);

            Assert.Equal(2, monkeys[0].inspects);
            Assert.Equal(4, monkeys[1].inspects);
            Assert.Equal(3, monkeys[2].inspects);
            Assert.Equal(6, monkeys[3].inspects);
        }

        [Fact]
        public void TestRoundB20()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var monkeys = AoC2020.Day11.GetMonkeys(lines);
            Assert.Equal(4, monkeys.Count);
            foreach (var n in Enumerable.Range(0, 20))
            {
                AoC2020.Day11.Round(monkeys, false);
            }

            Assert.Equal(99, monkeys[0].inspects);
            Assert.Equal(97, monkeys[1].inspects);
            Assert.Equal(8, monkeys[2].inspects);
            Assert.Equal(103, monkeys[3].inspects);
        }

        [Fact]
        public void TestRoundB1k()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var monkeys = AoC2020.Day11.GetMonkeys(lines);
            Assert.Equal(4, monkeys.Count);
            foreach (var n in Enumerable.Range(0, 1000))
            {
                AoC2020.Day11.Round(monkeys, false);
            }

            Assert.Equal(5204, monkeys[0].inspects);
            Assert.Equal(4792, monkeys[1].inspects);
            Assert.Equal(199, monkeys[2].inspects);
            Assert.Equal(5192, monkeys[3].inspects);
        }

        [Fact]
        public void Day11a()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day11.Day11a(lines);
            Assert.Equal(resultA, result);

            Console.WriteLine("Day11a : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }


        [Fact]
        public void Day11b()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day11.Day11b(lines);
            Assert.Equal(resultB, result);

            Console.WriteLine("Day11b : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }

        public Day11Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
