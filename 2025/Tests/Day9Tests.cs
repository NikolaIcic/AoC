using Advent2025;

namespace Tests;
public class Day9Tests : BaseTests<Day9>
{
    protected override string AcceptanceInput1 => "7,1\r\n11,1\r\n11,7\r\n9,7\r\n9,5\r\n2,5\r\n2,3\r\n7,3";
    protected override string AcceptanceInput2 => "7,1\r\n11,1\r\n11,7\r\n9,7\r\n9,5\r\n2,5\r\n2,3\r\n7,3";
    protected override object AcceptencePart1 => 50L;
    protected override object AcceptencePart2 => 24L;
    protected override object ExpectedPart1 => 4781377701L;
    protected override object ExpectedPart2 => 1470616992L;
    protected override int Day => 9;
}
