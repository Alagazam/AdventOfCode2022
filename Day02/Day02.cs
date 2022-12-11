using Newtonsoft.Json.Linq;
using System.Diagnostics;
using static System.Formats.Asn1.AsnWriter;
using System.Text;

namespace AoC
{
    public static class Day02
    {
        const char opp_rock = 'A';
        const char opp_paper = 'B';
        const char opp_scissors = 'C';
        const char me_rock = 'X';
        const char me_paper = 'Y';
        const char me_scissors = 'Z';

        // The winner of the whole tournament is the player with the highest score.
        // Your total score is the sum of your scores for each round.
        // The score for a single round is the score for the shape you selected
        // (1 for Rock, 2 for Paper, and 3 for Scissors)
        // plus the score for the outcome of the round
        // (0 if you lost, 3 if the round was a draw, and 6 if you won).
        static Int64 score(char opp, char me)
        {
            switch (opp)
            {
                case opp_rock:
                    {
                        switch (me)
                        {
                            case me_rock: return 1 + 3;
                            case me_paper: return 2 + 6;
                            case me_scissors: return 3 + 0;
                        }
                        break;
                    }
                case opp_paper:
                    {
                        switch (me)
                        {
                            case me_rock: return 1 + 0;
                            case me_paper: return 2 + 3;
                            case me_scissors: return 3 + 6;
                        }
                        break;
                    }
                case opp_scissors:
                    {
                        switch (me)
                        {
                            case me_rock: return 1 + 6;
                            case me_paper: return 2 + 0;
                            case me_scissors: return 3 + 3;
                        }
                        break;
                    }
            }
            return 0;
        }

        public static Int64 Day02a(string[] input)
        {
            Int64 total = 0;
            foreach (var x in input)
            {
                var opp = x[0];
                var me = x[2];
                total += score(opp, me);
            }
            return total;
            ;
        }

        // Anyway, the second column says how the round needs to end:
        // X means you need to lose,
        // Y means you need to end the round in a draw,
        // and Z means you need to win. Good luck!"

        const char loose = 'X';
        const char draw = 'Y';
        const char win = 'Z';

        static char mymove(char opp, char need)
        {
            switch (opp)
            {
                case opp_rock:
                    {
                        switch (need)
                        {
                            case loose: return me_scissors;
                            case draw: return me_rock;
                            case win: return me_paper;
                        }
                        break;
                    }
                case opp_paper:
                    {
                        switch (need)
                        {
                            case loose: return me_rock;
                            case draw: return me_paper;
                            case win: return me_scissors;
                        }
                        break;
                    }
                case opp_scissors:
                    {
                        switch (need)
                        {
                            case loose: return me_paper;
                            case draw: return me_scissors;
                            case win: return me_rock;
                        }
                        break;
                    }
            }
            return ' ';
        }

        public static Int64 Day02b(string[] input)
        {
            Int64 total = 0;
            foreach (var x in input)
            {
                var opp = x[0];
                var outcome = x[2];
                var me = mymove(opp, outcome);
                total += score(opp, me);

            }
            return total;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day02.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day02a : {0}   Time: {1}", Day02a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day02b : {0}   Time: {1}", Day02b(lines), sw.ElapsedMilliseconds);
        }
    }
}
