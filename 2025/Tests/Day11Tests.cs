using Advent2025;

namespace Tests;
public class Day11Tests : BaseTests<Day11>
{
    protected override string AcceptanceInput1 => "aaa: you hhh\r\nyou: bbb ccc\r\nbbb: ddd eee\r\nccc: ddd eee fff\r\nddd: ggg\r\neee: out\r\nfff: out\r\nggg: out\r\nhhh: ccc fff iii\r\niii: out";
    protected override string AcceptanceInput2 => "svr: aaa bbb\r\naaa: fft\r\nfft: ccc\r\nbbb: tty\r\ntty: ccc\r\nccc: ddd eee\r\nddd: hub\r\nhub: fff\r\neee: dac\r\ndac: fff\r\nfff: ggg hhh\r\nggg: out\r\nhhh: out";
    protected override object AcceptencePart1 => 5;
    protected override object AcceptencePart2 => 2L;
    protected override object ExpectedPart1 => 643;
    protected override object ExpectedPart2 => 417190406827152L;
    protected override int Day => 11;
}
