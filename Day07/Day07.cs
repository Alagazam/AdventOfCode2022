using System.Diagnostics;

namespace AoC2020
{
    public static class Day07
    {
        public static Dictionary<string, UInt64> BuildDirList(string[] input)
        {
            var dirlist = new Dictionary<string, UInt64>();
            string currentPath = "";

            foreach (var row in input)
            {
                if (row.StartsWith("$ cd "))
                {
                    var newdir = row.Substring(5);
                    if (newdir == "/")
                    {
                        currentPath = "";
                    }
                    else if (newdir == "..")
                    {
                        currentPath = currentPath.Substring(0, currentPath.LastIndexOf('/'));
                    }
                    else
                    {
                        currentPath += "/" + newdir;
                    }
                    if (!dirlist.ContainsKey(currentPath))
                        dirlist.Add(currentPath, 0);
                }
                else if (row.StartsWith("$ ls"))
                {
                    ;
                }
                else if (row.StartsWith("dir"))
                {
                    ;
                }
                else
                {
                    var part = row.Split(' ');
                    var size = Convert.ToUInt64(part[0]);
                    var tempPath = currentPath;
                    while (tempPath.Length != 0)
                    {
                        dirlist[tempPath] += size;
                        var lastslash = tempPath.LastIndexOf('/');
                        tempPath = tempPath.Substring(0, lastslash);
                    }
                    dirlist[""] += size;
                }
            }
            return dirlist;
        }

        public static UInt64 Day07a(string[] input)
        {
            var dirlist = BuildDirList(input);
            UInt64 totSize = 0;
            foreach(var dir in dirlist)
            {
                Console.WriteLine("{0}  {1}", dir.Key, dir.Value);
                if (dir.Value < 100000)
                    totSize += dir.Value;
            }
            return totSize;
        }

        public static UInt64 Day07b(string[] input)
        {
            var dirlist = BuildDirList(input);
            UInt64 totSize = 70000000;
            UInt64 required = 30000000;
            UInt64 minErase = totSize;
            UInt64 used = dirlist[""];
            foreach (var dir in dirlist)
            {
                var free = totSize - used + dir.Value;
                if (free > required && dir.Value < minErase)
                    minErase = dir.Value;
            }
            return minErase;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day07.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day07a : {0}   Time: {1}", Day07a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day07b : {0}   Time: {1}", Day07b(lines), sw.ElapsedMilliseconds);
        }
    }
}
