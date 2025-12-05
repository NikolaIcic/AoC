using System;

namespace Advent2025
{
    public class Day5 : Solver
    {
        public override object Part1(string input) => CountFresh(input);
        public override object Part2(string input) => CountTotalFreshIngredients(input);

        private static int CountFresh(string input)
        {
            var parts = input.Split("\r\n\r\n");
            var ranges = parts[0].Split("\r\n", StringSplitOptions.RemoveEmptyEntries)
            .Select(line =>
            {
                var nums = line.Split('-');
                return (start: long.Parse(nums[0]), end: long.Parse(nums[1]));
            }).ToList();

            var indexes = parts[1]
                .Split("\r\n", StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse).ToList();

            int count = 0;
            foreach (var index in indexes)
                foreach (var (start, end) in ranges)
                    if (index >= start && index <= end)
                    {
                        count++;
                        break;
                    }
                
            return count;
        }

        private static long CountTotalFreshIngredients(string input)
        {
            var parts = input.Split("\r\n\r\n");
            var ranges = parts[0].Split("\r\n", StringSplitOptions.RemoveEmptyEntries)
            .Select(line =>
            {
                var nums = line.Split('-');
                return (start: long.Parse(nums[0]), end: long.Parse(nums[1]));
            }).OrderBy(r => r.start).ToList();


            List<(long start, long end)> merged = [];
            foreach (var r in ranges)
            {
                if (merged.Count == 0 || r.start > merged[^1].end + 1)
                    merged.Add(r);
                else
                {
                    var (start, end) = merged[^1];
                    merged[^1] = (start, Math.Max(end, r.end));
                }
            }

            long total = 0;
            foreach (var (start, end) in merged)
                total += (end - start + 1);

            return total;
        }
    }
}
