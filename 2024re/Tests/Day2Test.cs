namespace Tests;

using Advent2024;

public class Day2Tests : BaseTests<Day2>
{
    protected override string AcceptanceInput => "7 6 4 2 1\r\n1 2 7 8 9\r\n9 7 6 2 1\r\n1 3 2 4 5\r\n8 6 4 4 1\r\n1 3 6 7 9";
    protected override object AcceptencePart1 => 2;
    protected override object AcceptencePart2 => 4;
    protected override object ExpectedPart1 => 371;
    protected override object ExpectedPart2 => 426;
    protected override int Day => 2;
}
