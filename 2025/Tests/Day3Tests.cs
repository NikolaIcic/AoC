using Advent2025;

namespace Tests;
public class Day3Tests : BaseTests<Day3>
{
    protected override string AcceptanceInput1 => "987654321111111\r\n811111111111119\r\n234234234234278\r\n818181911112111";
    protected override string AcceptanceInput2 => "987654321111111\r\n811111111111119\r\n234234234234278\r\n818181911112111";
    protected override object AcceptencePart1 => 357d;
    protected override object AcceptencePart2 => 3121910778619d;
    protected override object ExpectedPart1 => 16927d;
    protected override object ExpectedPart2 => 167384358365132d;
    protected override int Day => 3;
}
