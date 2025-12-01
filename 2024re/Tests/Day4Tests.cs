namespace Tests;

using Advent2024;

public class Day4Tests : BaseTests<Day4>
{
    protected override string AcceptanceInput1 => "MMMSXXMASM\r\nMSAMXMSMSA\r\nAMXSXMAAMM\r\nMSAMASMSMX\r\nXMASAMXAMM\r\nXXAMMXXAMA\r\nSMSMSASXSS\r\nSAXAMASAAA\r\nMAMMMXMMMM\r\nMXMXAXMASX";
    protected override string AcceptanceInput2 => "MMMSXXMASM\r\nMSAMXMSMSA\r\nAMXSXMAAMM\r\nMSAMASMSMX\r\nXMASAMXAMM\r\nXXAMMXXAMA\r\nSMSMSASXSS\r\nSAXAMASAAA\r\nMAMMMXMMMM\r\nMXMXAXMASX";
    protected override object AcceptencePart1 => 18;
    protected override object ExpectedPart1 => 2543;
    protected override object AcceptencePart2 => 0;
    protected override object ExpectedPart2 => 0;
    protected override int Day => 4;
}
