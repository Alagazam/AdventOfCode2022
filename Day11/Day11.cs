using System.ComponentModel;
using System.Diagnostics;

namespace AoC2020
{
    public class Monkey
    {
        public List<Int64> items;
        public string op;
        public Int64 divider;
        public int throwTrue;
        public int throwFalse;
        public Int64 inspects;

        public Monkey(string[] input, int index)
        {
            items = new List<Int64>();
            var it = input[index+1].Split(' ');
            for ( var i=4; i!=it.Length; i++)
            {
                var s = it[i].TrimEnd(',');
                items.Add(Convert.ToInt64(s));
            }
            op = input[index+2].Substring(input[index+2].IndexOf('=')+2);
            divider = Convert.ToInt64(input[index + 3].Substring(input[index + 3].LastIndexOf(' ')));
            throwTrue = Convert.ToInt32(input[index + 4].Substring(input[index + 4].LastIndexOf(' ')));
            throwFalse = Convert.ToInt32(input[index + 5].Substring(input[index + 5].LastIndexOf(' ')));
        }
    }

    public static class Day11
    {
        public static List<Monkey> GetMonkeys(string[] input)
        {
            var monkeys = new List<Monkey>();
            var index = 0;
            while (index < input.Length)
            {
                var m = new Monkey(input, index);
                index += 7;
                monkeys.Add(m);
            }

            return monkeys;
        }

        public static void Round(List<Monkey> monkeys, bool worryDivide = true)
        {
            foreach(var m in monkeys)
            {
                foreach(var i in m.items)
                {
                    var op = m.op.Split(' ');
                    var a = op[0] == "old" ? i : Convert.ToInt64(op[0]);
                    var b = op[2] == "old" ? i : Convert.ToInt64(op[2]);
                    var newItem = i;
                    switch (op[1])
                    {
                    case "*":
                        newItem = a * b; break;
                    case "+":
                        newItem = a + b; break;
                    }

                    if (worryDivide) newItem /= 3;

                    if (newItem % m.divider== 0)
                    {
                        monkeys[m.throwTrue].items.Add(newItem);
                    }
                    else
                    {
                        monkeys[m.throwFalse].items.Add(newItem);
                    }
                    m.inspects++;
                }
                m.items.Clear();
            }
        }

        public static Int64 Day11a(string[] input)
        {
            List<Monkey> monkeys = GetMonkeys(input);
            foreach (var n in Enumerable.Range(0, 20))
            {
                Round(monkeys);
            }
            monkeys.Sort((m1, m2) => m2.inspects.CompareTo(m1.inspects));

            return monkeys[0].inspects * monkeys[1].inspects;
        }

        public static Int64 Day11b(string[] input)
        {
            List<Monkey> monkeys = GetMonkeys(input);
            foreach (var n in Enumerable.Range(0, 10000))
            {
                Round(monkeys, false);
            }
            monkeys.Sort((m1, m2) => m2.inspects.CompareTo(m1.inspects));

            return monkeys[0].inspects * monkeys[1].inspects;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day11.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day11a : {0}   Time: {1}", Day11a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day11b : {0}   Time: {1}", Day11b(lines), sw.ElapsedMilliseconds);
        }
    }
}
