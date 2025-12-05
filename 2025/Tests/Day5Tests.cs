using Advent2025;

namespace Tests;
public class Day5Tests : BaseTests<Day5>
{
    protected override string AcceptanceInput1 => "3-5\r\n10-14\r\n16-20\r\n12-18\r\n\r\n1\r\n5\r\n8\r\n11\r\n17\r\n32";
    protected override string AcceptanceInput2 => "3-5\r\n10-14\r\n16-20\r\n12-18\r\n\r\n1\r\n5\r\n8\r\n11\r\n17\r\n32";
    protected override object AcceptencePart1 => 3;
    protected override object AcceptencePart2 => 14L;
    protected override object ExpectedPart1 => 617;
    protected override object ExpectedPart2 => 338258295736104L;
    protected override int Day => 5;
}
