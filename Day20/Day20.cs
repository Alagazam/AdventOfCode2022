using System.Diagnostics;

namespace AoC
{
    public static class Day20
    {
        public static Int64 Day20a(string[] input)
        {
            var list = new List<Tuple<Int64, int>>();
            foreach (var n in Enumerable.Range(0, input.Length))
            {
                list.Add(Tuple.Create(Convert.ToInt64(input[n]), n));
            }
            var mod = input.Length - 1;

            foreach (var n in Enumerable.Range(0, input.Length))
            {
                var index = list.FindIndex(x => x.Item2 == n);
                var tup = list[index];
                list.RemoveAt(index);
                index += (int)(tup.Item1 % (long)mod);
                while (index > mod) index -= mod;
                while (index <= 0) index += mod;
                list.Insert(index, tup);
            }

            var zero = list.FindIndex(x => x.Item1 == 0);
            var res = list[(zero + 1000) % input.Length].Item1 + list[(zero + 2000) % input.Length].Item1 + list[(zero + 3000) % input.Length].Item1;
            return res;
        }

        public static Int64 Day20b(string[] input)
        {
            Int64 key = 811589153;
            var list = new List<Tuple<Int64,int>>();
            foreach (var n in Enumerable.Range(0, input.Length))
            {
                list.Add(Tuple.Create(Convert.ToInt64(input[n]) * key, n));
            }
            var mod = input.Length - 1;

            foreach(var x in Enumerable.Range(0, 10))
            {
                foreach (var n in Enumerable.Range(0, input.Length))
                {
                    var index = list.FindIndex(x => x.Item2 == n);
                    var tup = list[index];
                    list.RemoveAt(index);
                    index += (int)(tup.Item1 % (long)mod);
                    while (index > mod) index -= mod;
                    while (index <= 0) index += mod;
                    list.Insert(index,tup);
                }
            }

            var zero = list.FindIndex(x => x.Item1 == 0);
            var res = list[(zero + 1000) % input.Length].Item1 + list[(zero + 2000) % input.Length].Item1 + list[(zero + 3000) % input.Length].Item1;
            return res;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day20.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day20a : {0}   Time: {1}", Day20a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day20b : {0}   Time: {1}", Day20b(lines), sw.ElapsedMilliseconds);
        }
    }
}
