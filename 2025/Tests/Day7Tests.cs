using Advent2025;

namespace Tests;
public class Day7Tests : BaseTests<Day7>
{
    protected override string AcceptanceInput1 => ".......S.......\r\n...............\r\n.......^.......\r\n...............\r\n......^.^......\r\n...............\r\n.....^.^.^.....\r\n...............\r\n....^.^...^....\r\n...............\r\n...^.^...^.^...\r\n...............\r\n..^...^.....^..\r\n...............\r\n.^.^.^.^.^...^.\r\n...............";
    protected override string AcceptanceInput2 => ".......S.......\r\n...............\r\n.......^.......\r\n...............\r\n......^.^......\r\n...............\r\n.....^.^.^.....\r\n...............\r\n....^.^...^....\r\n...............\r\n...^.^...^.^...\r\n...............\r\n..^...^.....^..\r\n...............\r\n.^.^.^.^.^...^.\r\n...............";
    protected override object AcceptencePart1 => 21;
    protected override object AcceptencePart2 => 40L;
    protected override object ExpectedPart1 => 1609;
    protected override object ExpectedPart2 => 12472142047197L;
    protected override int Day => 7;
}
