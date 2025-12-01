namespace Tests;

using Advent2024;

public class Day3Tests : BaseTests<Day3>
{
    protected override string AcceptanceInput1 => "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
    protected override string AcceptanceInput2 => "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";
    protected override object AcceptencePart1 => 161d;
    protected override object ExpectedPart1 => 182619815d;
    protected override object AcceptencePart2 => 48d;
    protected override object ExpectedPart2 => 80747545d;
    protected override int Day => 3;
}
