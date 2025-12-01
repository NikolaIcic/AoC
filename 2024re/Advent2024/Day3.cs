using System.Text.RegularExpressions;

namespace Advent2024;

public class Day3 : Solver
{
    public override object Part1(string input) => SumMulOperations(input);
    public override object Part2(string input) => SumOperations(input);

    static double SumMulOperations(string input)
    {
        var patern = @"mul\((\d{1,3}),(\d{1,3})\)";
        return Regex.Matches(input, patern)
        .Cast<Match>()
        .Select(m => (
            Num1: int.Parse(m.Groups[1].Value),
            Num2: int.Parse(m.Groups[2].Value)
        )).Sum(x => x.Num1 * x.Num2);
    }

    static double SumOperations(string input)
    {
        var patern = @"mul\((\d{1,3}),(\d{1,3})\)|do\(\)|don't\(\)";
        var matches = Regex.Matches(input, patern);
        return matches.Aggregate(
            seed: (Enabled: true, Sum: 0),
            func: (acc, m) =>
                (m.Value, acc.Sum, acc.Enabled) switch
                {
                    ("do()", _, _) => (true, acc.Sum),
                    ("don't()", _, _) => (false, acc.Sum),
                    (_, var sum, true) => (true, sum + int.Parse(m.Groups[1].Value) * int.Parse(m.Groups[2].Value)),
                    _ => (acc.Enabled, acc.Sum)
                },
            resultSelector: acc => acc.Sum
        );
    }
}