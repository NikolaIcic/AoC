using Advent2025;

namespace Tests;
public class Day1Tests : BaseTests<Day1>
{
    protected override string AcceptanceInput1 => "L68\r\nL30\r\nR48\r\nL5\r\nR60\r\nL55\r\nL1\r\nL99\r\nR14\r\nL82";
    protected override string AcceptanceInput2 => "L68\r\nL30\r\nR48\r\nL5\r\nR60\r\nL55\r\nL1\r\nL99\r\nR14\r\nL82";
    protected override object AcceptencePart1 => 3;
    protected override object AcceptencePart2 => 6;
    protected override object ExpectedPart1 => 1026;
    protected override object ExpectedPart2 => 5923;
    protected override int Day => 1;
}
