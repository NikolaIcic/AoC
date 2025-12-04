using Advent2025;

namespace Tests;
public class Day4Tests : BaseTests<Day4>
{
    protected override string AcceptanceInput1 => "..@@.@@@@.\r\n@@@.@.@.@@\r\n@@@@@.@.@@\r\n@.@@@@..@.\r\n@@.@@@@.@@\r\n.@@@@@@@.@\r\n.@.@.@.@@@\r\n@.@@@.@@@@\r\n.@@@@@@@@.\r\n@.@.@@@.@.";
    protected override string AcceptanceInput2 => "..@@.@@@@.\r\n@@@.@.@.@@\r\n@@@@@.@.@@\r\n@.@@@@..@.\r\n@@.@@@@.@@\r\n.@@@@@@@.@\r\n.@.@.@.@@@\r\n@.@@@.@@@@\r\n.@@@@@@@@.\r\n@.@.@@@.@.";
    protected override object AcceptencePart1 => 13;
    protected override object AcceptencePart2 => 43;
    protected override object ExpectedPart1 => 1367;
    protected override object ExpectedPart2 => 9144;
    protected override int Day => 4;
}
