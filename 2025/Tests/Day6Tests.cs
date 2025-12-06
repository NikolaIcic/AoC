using Advent2025;

namespace Tests;
public class Day6Tests : BaseTests<Day6>
{
    protected override string AcceptanceInput1 => "123 328  51 64 \r\n 45 64  387 23 \r\n  6 98  215 314\r\n*   +   *   +  ";
    protected override string AcceptanceInput2 => "123 328  51 64 \r\n 45 64  387 23 \r\n  6 98  215 314\r\n*   +   *   +  ";
    protected override object AcceptencePart1 => 4277556L;
    protected override object AcceptencePart2 => 3263827L;
    protected override object ExpectedPart1 => 5667835681547L;
    protected override object ExpectedPart2 => 9434900032651L;
    protected override int Day => 6;
}
