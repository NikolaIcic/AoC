using System.Numerics;

namespace Advent2025
{
    public class Day2 : Solver
    {
        public override object Part1(string input) => Solve(input, allowMoreRepeats: false);
        public override object Part2(string input) => Solve(input, allowMoreRepeats: true);

        static long Solve(string input, bool allowMoreRepeats)
        {
            var ranges = input.Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(r =>
            {
                var parts = r.Split('-');
                return (Start: long.Parse(parts[0]), End: long.Parse(parts[1]));
            }).ToList();

            long sum = 0;

            foreach (var (start, end) in ranges)
                for (long id = start; id <= end; id++)
                    if (IsRepeatedNumber(id, allowMoreRepeats))
                        sum += id;

            return sum;
        }

        static bool IsRepeatedNumber(long n, bool allowMoreRepeats)
        {
            string s = n.ToString();
            int len = s.Length;

            for (int block = 1; block <= len / 2; block++)
            {
                if (len % block != 0)
                    continue;

                int repeats = len / block;
                if (!allowMoreRepeats && repeats != 2)
                    continue;

                string sub = s.Substring(0, block);

                bool ok = true;
                for (int i = 1; i < repeats; i++)
                    if (s.Substring(i * block, block) != sub)
                    {
                        ok = false;
                        break;
                    }

                if (ok)
                    return true;
            }

            return false;
        }
    }
}
