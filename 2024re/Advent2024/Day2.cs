namespace Advent2024;

public class Day2
{
    public object Part1(string input) => ParseReports(input).Count(IsSafe);
    public object Part2(string input) => ParseReports(input)
    .Count(rep => RemoveSingleLevelPossibilities(rep).Any(IsSafe));

    private IEnumerable<int[]> ParseReports(string input) =>
        input.Split("\r\n")
        .Select(row => row.Split(' ')
        .Select(int.Parse).ToArray()
        );

    private bool IsSafe(int[] report)
    {
        var pairs = Enumerable.Zip(report, report.Skip(1));
        bool increasing = pairs.All(p => p.Second - p.First >= 1 && p.Second - p.First <= 3);
        bool decreasing = pairs.All(p => p.First - p.Second >= 1 && p.First - p.Second <= 3);
        return increasing || decreasing;
    }

    private IEnumerable<int[]> RemoveSingleLevelPossibilities(int[] report) =>
        Enumerable.Range(0, report.Length + 1)
        .Select(i => Enumerable.Concat(report.Take(i - 1), report.Skip(i))
        .ToArray());
}