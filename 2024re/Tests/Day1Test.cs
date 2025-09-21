namespace Tests;

using Advent2024;

public class Day1Test : BaseTests<Day1>
{
    protected override string AcceptanceInput => "3   4\r\n4   3\r\n2   5\r\n1   3\r\n3   9\r\n3   3";
    protected override object AcceptencePart1 => 11;
    protected override object AcceptencePart2 => 31;
    protected override object ExpectedPart1 => 1197984;
    protected override object ExpectedPart2 => 23387399;
    protected override int Day => 1;
}
