using System.Diagnostics;

namespace AoC
{
    public class Element
    {
        public int i = int.MaxValue;
        public List<Element>? list;
    }



    public static class Day13
    {
        static public Element parse(string s, int index = 0)
        {
            var e = new Element();
            int i = index;
            while (i < s.Length)
            {
                if (s[i] == '[')
                {
                    index++;
                    e.list = new List<Element>();
                    e.list.Add(parse(s, index));
                }
                else if (s[i] == ']')
                {
                    return e;
                }
                else 
                {
                }
            }
            return e;
        }

        public static Int64 Day13a(string[] input)
        {

            return 0;
        }

        public static Int64 Day13b(string[] input)
        {
            return 0;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day13.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day13a : {0}   Time: {1}", Day13a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day13b : {0}   Time: {1}", Day13b(lines), sw.ElapsedMilliseconds);
        }
    }
}
